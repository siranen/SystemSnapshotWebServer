/*
 * SystemSnapshotWebServer
 * Author: Andrzej Piotrowski
 * 
 * http://SystemSnapshotWebServer.com/
 * 
 */

using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using SystemSnapshotWebServer.Core.Process;
using SystemSnapshotWebServer.GUI.Forms;

namespace SystemSnapshotWebServer.GUI
{
    public partial class FrmMain : Form
    {
        #region Properties
        /// <summary>
        /// Button list to be disabled and enabled.
        /// </summary>
        private readonly Button[] Buttons;

        public int seconds;
        public int minutes;
        public int hours;
        public bool paused;

        /// <summary>
        /// Gets the datetime when report generation process started
        /// </summary>
        public DateTime StartDateTime { get; private set; }

        /// <summary>
        /// Gets the datetime when report generation process ended
        /// </summary>
        public DateTime EndDateTime { get; private set; }

        public FrmServerOptions FrmServerOptions { get; private set; }

        #endregion

        #region Constructor
        public FrmMain()
        {
            InitializeComponent();

            Buttons = new[]
            {
                btnRebuildReport,
                btnOpenReport,
                btnOpenFolder,
                btnExit
            };
            tmClock.Tick += (sender, args) =>
            {
                lbStatus.Text = string.Format("Generating the report. Please wait... {0:0.##}s", Math.Round((DateTime.Now - StartDateTime).TotalSeconds));
            };

            Text += string.Format(" v{0}", ApplicationInfo.Version);

            notifyIcon.DoubleClick += delegate { ShowForm(); };

            if (ApplicationArguments.Instance.IsListenServer)
            {
                EnableListenServer();
            }

            //FrmServerOptions = new FrmServerOptions();
            //FrmServerOptions.ShowDialog();
        }
        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StartWorker();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (ApplicationArguments.Instance.IsListenServer)
            {
                e.Cancel = true;
                Hide();
                notifyIcon.BalloonTipTitle = "SystemSnapshotWebServer";
                notifyIcon.BalloonTipText = "The web server will keep running on the background.\nClick on this to show or close the program.";
                notifyIcon.ShowBalloonTip(5000);
            }
        }

        #endregion

        #region Events

        private void ButtonClick(object sender, EventArgs e)
        {
            
            if (sender == btnRebuildReport)
            {
                StartWorker();
                return;
            }
            if (sender == btnOpenReport)
            {
                if (!ApplicationArguments.Instance.IsListenServer)
                {
                    Program.HtmlTemplate.OpenInDefaultBrowser();
                    return;
                }

                
                var ip = string.Format("http://{0}:{1}", Equals(ApplicationArguments.Instance.ListenServerIPEndPoint.Address, IPAddress.Any)
                    ? "127.0.0.1"
                    : ApplicationArguments.Instance.ListenServerIPEndPoint.Address.ToString(), ApplicationArguments.Instance.ListenServerIPEndPoint.Port);

                ProcessManager.OpenLink(ip);

                return;
            }
            if (sender == btnOpenFolder)
            {
                Program.HtmlTemplate.ShowInExplorer();

                return;
            }

            if (sender == btnListenServer)
            {
                if (ReferenceEquals(FrmServerOptions, null))
                {
                    FrmServerOptions = new FrmServerOptions();
                }

                if (FrmServerOptions.ShowDialog() == DialogResult.OK)
                {
                    ApplicationArguments.Instance.ListenServerIPEndPoint = FrmServerOptions.IPEndPoint;
                    ApplicationArguments.Instance.ListenServerUpdateInterval = FrmServerOptions.UpdateInterval;
                    EnableListenServer();
                }

                return;
            }

            if (sender == btnExit || sender == cmTrayExit)
            {
                Application.Exit();
                return;
            }

            if (sender == cmTrayShow)
            {
                ShowForm();
                return;
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            Program.WriteTemplate();
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ButtonsSetEnabled(true);
            var location = Path.GetDirectoryName(Program.HtmlTemplate.LastSaveFilePath);
            /*if (string.IsNullOrEmpty(location))
            {
                location = Application.StartupPath;
            }*/
            if (!ApplicationArguments.Instance.IsListenServer)
            {
                lbFilename.Text = Path.GetFileName(Program.HtmlTemplate.LastSaveFilePath);
                lbLocation.Text = location;
            }
            EndDateTime = DateTime.Now;
            tmClock.Stop();
            lbStatus.Text = string.Format("Report completed in {0:0.##}s", (EndDateTime - StartDateTime).TotalSeconds);
            if (ApplicationArguments.Instance.IsListenServer)
            {
                tmUpdateInterval.Start();
            }
        }

        private void tmUpdateInterval_Tick(object sender, EventArgs e)
        {
            StartWorker();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Start the workerr thread for generate the report
        /// </summary>
        private void StartWorker()
        {
            if (bgWorker.IsBusy) return;
            tmUpdateInterval.Stop();
            ButtonsSetEnabled(false);
            StartDateTime = DateTime.Now;
            lbStatus.Text = @"Generating the report. Please wait...";
            tmClock.Start();
            bgWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Show the form if hidden, minimized or not active
        /// </summary>
        public void ShowForm()
        {
            if (!Visible)
                Show();
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            Activate();
        }

        /// <summary>
        /// Enable or disable form buttons
        /// </summary>
        /// <param name="enabled"></param>
        private void ButtonsSetEnabled(bool enabled = true)
        {
            if ((ApplicationArguments.Instance.IsListenServer && enabled) ||
                !ApplicationArguments.Instance.IsListenServer)
            {
                foreach (var button in Buttons)
                {
                    button.Enabled = enabled;
                }
            }
            if (enabled)
            {
                pbProgress.Style = ProgressBarStyle.Blocks;
                pbProgress.Enabled = false;
            }
            else
            {
                pbProgress.Style = ProgressBarStyle.Marquee;
                pbProgress.Enabled = true;
                if (!ApplicationArguments.Instance.IsListenServer)
                {
                    lbFilename.Text = @"...";
                    lbLocation.Text = @"Desktop";
                }
            }
        }

        /// <summary>
        /// Enable listen server and change the GUI
        /// </summary>
        public void EnableListenServer()
        {
            ApplicationArguments.Instance.IsListenServer = true;
            lbFilename.Text = string.Format("http://{0}", ApplicationArguments.Instance.ListenServerIPEndPoint);
            lbLocation.Text = Equals(ApplicationArguments.Instance.ListenServerIPEndPoint.Address, IPAddress.Loopback) ? "Host loopback" : "Internet";
            btnOpenFolder.Visible = false;
            btnListenServer.Enabled = false;
            btnListenServer.Text += @" (Started)";
            notifyIcon.BalloonTipText = "SystemSnapshotWebServer is now running as a listen server";
            notifyIcon.ShowBalloonTip(5000);
            tmUpdateInterval.Interval = (int) ApplicationArguments.Instance.ListenServerUpdateInterval * 1000;
            tmUpdateInterval.Start();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
               if (paused != true)
   {
      if ((lblHr.Text != "")&&(lblMin.Text != "") &&(lblSec.Text != 
           ""))
      {
         autoClock.Enabled = true;
         button1.Enabled = true;
         lblSec.Enabled = false;
         try
         {
         minutes = System.Convert.ToInt32(lblMin.Text);
         seconds = System.Convert.ToInt32(lblSec.Text);
         hours = System.Convert.ToInt32(lblHr.Text);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
      else
      {
         MessageBox.Show("Incomplete settings!");
      }
   }
   else
   {
      autoClock.Enabled = true;
   }

        }

        private void autoClock_Tick(object sender, EventArgs e)
        {

      // Verify if the time didn't pass.
      if ((minutes == 0) && (hours == 0) && (seconds == 0))
      {
         // If the time is over, clear all settings and fields.
         // Also, show the message, notifying that the time is over.
         autoClock.Enabled = false;
         button1.Enabled = false;
         lblSec.Clear();
         lblMin.Clear();
         lblHr.Enabled = true;
         lblSec.Enabled = true;
         lblMin.Enabled = true;
         lblHr.Enabled = true;
         lblHr.Text = "00";
         lblMin.Text = "00";
         lblSec.Text = "00";
      }
        }

       
    }
}

