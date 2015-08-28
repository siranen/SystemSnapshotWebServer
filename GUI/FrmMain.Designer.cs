namespace SystemSnapshotWebServer.GUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnExit = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnRebuildReport = new System.Windows.Forms.Button();
            this.lbLead = new System.Windows.Forms.Label();
            this.lbFilename = new System.Windows.Forms.Label();
            this.lbLocationT = new System.Windows.Forms.Label();
            this.lbFilenameT = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.btnOpenReport = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbStatusT = new System.Windows.Forms.Label();
            this.tmClock = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmTrayShow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.btnListenServer = new System.Windows.Forms.Button();
            this.tmUpdateInterval = new System.Windows.Forms.Timer(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Enabled = false;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(388, 302);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 74);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // pbProgress
            // 
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbProgress.Location = new System.Drawing.Point(0, 383);
            this.pbProgress.MarqueeAnimationSpeed = 10;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(502, 23);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProgress.TabIndex = 2;
            // 
            // btnRebuildReport
            // 
            this.btnRebuildReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRebuildReport.Enabled = false;
            this.btnRebuildReport.Image = global::SystemSnapshotWebServer.Properties.Resources.refresh;
            this.btnRebuildReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRebuildReport.Location = new System.Drawing.Point(12, 302);
            this.btnRebuildReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnRebuildReport.Name = "btnRebuildReport";
            this.btnRebuildReport.Size = new System.Drawing.Size(250, 33);
            this.btnRebuildReport.TabIndex = 3;
            this.btnRebuildReport.Text = "Rebuild report";
            this.btnRebuildReport.UseVisualStyleBackColor = true;
            this.btnRebuildReport.Click += new System.EventHandler(this.ButtonClick);
            // 
            // lbLead
            // 
            this.lbLead.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbLead.Location = new System.Drawing.Point(12, 9);
            this.lbLead.Name = "lbLead";
            this.lbLead.Size = new System.Drawing.Size(476, 73);
            this.lbLead.TabIndex = 4;
            this.lbLead.Text = "Collect the computer and system info at a given time in order to track issues or " +
    "problems.\r\n\r\n";
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Location = new System.Drawing.Point(94, 92);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(17, 16);
            this.lbFilename.TabIndex = 5;
            this.lbFilename.Text = "...";
            // 
            // lbLocationT
            // 
            this.lbLocationT.AutoSize = true;
            this.lbLocationT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocationT.Location = new System.Drawing.Point(12, 116);
            this.lbLocationT.Name = "lbLocationT";
            this.lbLocationT.Size = new System.Drawing.Size(71, 16);
            this.lbLocationT.TabIndex = 6;
            this.lbLocationT.Text = "Location:";
            // 
            // lbFilenameT
            // 
            this.lbFilenameT.AutoSize = true;
            this.lbFilenameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilenameT.Location = new System.Drawing.Point(12, 92);
            this.lbFilenameT.Name = "lbFilenameT";
            this.lbFilenameT.Size = new System.Drawing.Size(76, 16);
            this.lbFilenameT.TabIndex = 7;
            this.lbFilenameT.Text = "Filename:";
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(85, 116);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(59, 16);
            this.lbLocation.TabIndex = 8;
            this.lbLocation.Text = "Desktop";
            // 
            // btnOpenReport
            // 
            this.btnOpenReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenReport.Enabled = false;
            this.btnOpenReport.Image = global::SystemSnapshotWebServer.Properties.Resources.open;
            this.btnOpenReport.Location = new System.Drawing.Point(460, 92);
            this.btnOpenReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenReport.Name = "btnOpenReport";
            this.btnOpenReport.Size = new System.Drawing.Size(28, 24);
            this.btnOpenReport.TabIndex = 9;
            this.tooltip.SetToolTip(this.btnOpenReport, "Open generated report in browser");
            this.btnOpenReport.UseVisualStyleBackColor = true;
            this.btnOpenReport.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Enabled = false;
            this.btnOpenFolder.Image = global::SystemSnapshotWebServer.Properties.Resources.folder_open;
            this.btnOpenFolder.Location = new System.Drawing.Point(460, 116);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(28, 24);
            this.btnOpenFolder.TabIndex = 10;
            this.tooltip.SetToolTip(this.btnOpenFolder, "Show generated report in explorer");
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.ButtonClick);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(85, 141);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(29, 16);
            this.lbStatus.TabIndex = 13;
            this.lbStatus.Text = "???";
            // 
            // lbStatusT
            // 
            this.lbStatusT.AutoSize = true;
            this.lbStatusT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusT.Location = new System.Drawing.Point(12, 141);
            this.lbStatusT.Name = "lbStatusT";
            this.lbStatusT.Size = new System.Drawing.Size(55, 16);
            this.lbStatusT.TabIndex = 12;
            this.lbStatusT.Text = "Status:";
            // 
            // tmClock
            // 
            this.tmClock.Interval = 1000;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SystemSnapshotWebServer";
            this.notifyIcon.Visible = true;
            // 
            // cmTray
            // 
            this.cmTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTrayShow,
            this.cmTrayExit});
            this.cmTray.Name = "cmTray";
            this.cmTray.Size = new System.Drawing.Size(104, 48);
            // 
            // cmTrayShow
            // 
            this.cmTrayShow.Image = global::SystemSnapshotWebServer.Properties.Resources.eye;
            this.cmTrayShow.Name = "cmTrayShow";
            this.cmTrayShow.Size = new System.Drawing.Size(103, 22);
            this.cmTrayShow.Text = "&Show";
            this.cmTrayShow.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmTrayExit
            // 
            this.cmTrayExit.Image = global::SystemSnapshotWebServer.Properties.Resources.exit;
            this.cmTrayExit.Name = "cmTrayExit";
            this.cmTrayExit.Size = new System.Drawing.Size(103, 22);
            this.cmTrayExit.Text = "&Exit";
            this.cmTrayExit.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnListenServer
            // 
            this.btnListenServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListenServer.Image = global::SystemSnapshotWebServer.Properties.Resources.cloud;
            this.btnListenServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListenServer.Location = new System.Drawing.Point(12, 343);
            this.btnListenServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnListenServer.Name = "btnListenServer";
            this.btnListenServer.Size = new System.Drawing.Size(250, 33);
            this.btnListenServer.TabIndex = 15;
            this.btnListenServer.Text = "Listen server";
            this.tooltip.SetToolTip(this.btnListenServer, "Create a local web server and display live information about this machine on the " +
        "internet.");
            this.btnListenServer.UseVisualStyleBackColor = true;
            this.btnListenServer.Click += new System.EventHandler(this.ButtonClick);
            // 
            // tmUpdateInterval
            // 
            this.tmUpdateInterval.Tick += new System.EventHandler(this.tmUpdateInterval_Tick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 177);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(96, 177);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 17;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Anen"});
            this.listBox1.Location = new System.Drawing.Point(15, 206);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(156, 84);
            this.listBox1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 33);
            this.button1.TabIndex = 19;
            this.button1.Text = "Time";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 33);
            this.button2.TabIndex = 20;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 406);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnListenServer);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbStatusT);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnOpenReport);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.lbFilenameT);
            this.Controls.Add(this.lbLocationT);
            this.Controls.Add(this.lbFilename);
            this.Controls.Add(this.lbLead);
            this.Controls.Add(this.btnRebuildReport);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "SystemSnapshotWebServer";
            this.cmTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Button btnRebuildReport;
        private System.Windows.Forms.Label lbLead;
        private System.Windows.Forms.Label lbFilename;
        private System.Windows.Forms.Label lbLocationT;
        private System.Windows.Forms.Label lbFilenameT;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Button btnOpenReport;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbStatusT;
        private System.Windows.Forms.Timer tmClock;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmTray;
        private System.Windows.Forms.ToolStripMenuItem cmTrayExit;
        private System.Windows.Forms.ToolStripMenuItem cmTrayShow;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Button btnListenServer;
        private System.Windows.Forms.Timer tmUpdateInterval;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

