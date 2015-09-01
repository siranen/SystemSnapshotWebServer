﻿/*
 * SystemSnapshotWebServer
 * Author: Andrzej Piotrowski
 * 
 * http://SystemSnapshotWebServer.com/
 * 
 */
using System;
using System.IO;
using SystemSnapshotWebServer.Core.Process;
using SystemSnapshotWebServer.Properties;

namespace SystemSnapshotWebServer
{
    /// <summary>
    /// HTML Template
    /// </summary>
    public sealed class HtmlTemplate
    {
        #region Properties
        /// <summary>
        /// Gets the whole generated html
        /// </summary>
        public string TemplateHTML { get; private set; }

        /// <summary>
        /// Gets or sets the filename for the html file. .html will be appended.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets the last path for the generated file.
        /// </summary>
        public string LastSaveFilePath { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HtmlTemplate()
        {
            TemplateHTML = Resources.template;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Write in a placeholder variable into template.
        /// </summary>
        /// <param name="templateVar">Placeholder variable.</param>
        /// <param name="html">Html to write.</param>
        public void WriteFromVar(string templateVar, string html)
        {
            TemplateHTML = TemplateHTML.Replace(templateVar, html);
        }

        /// <summary>
        /// Write all generated HTML to a file and close the stream
        /// </summary>
        public void WriteToFile()
        {
            var defaultFilename = string.Format("SystemSnapshot_{0}.html", DateTime.Now).
                Replace(':', '-').
                Replace('/', '-').
                Replace(' ', '_');;
            var filename = Filename ?? defaultFilename;

            //filename += string.Format("_{0}.html", DateTime.Now).Replace(':', '-').Replace('/', '-').Replace(' ', '_');
#if !DEBUG
            string path = null;
            if (!string.IsNullOrEmpty(Filename))
            {
                // If is a directory then keep filename the default name and set the folder only.
                if (Directory.Exists(filename))
                {
                    path = filename;
                    filename = defaultFilename;
                }
                else // If is not a directory then get the path from the filename if any and append .html to the filename
                {
                    path = Path.GetDirectoryName(Filename);
                    if (!filename.EndsWith(".html"))
                        filename += ".html";
                }
            }

            // Last check for invalid path, if invalid set path as dekstop
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }


            filename = !string.IsNullOrEmpty(path) && Directory.Exists(path) ? Path.Combine(path, filename) : filename;
#endif
            using (var htmlWriter = new StreamWriter(filename))
            {
                htmlWriter.Write(TemplateHTML);
                htmlWriter.Close();
            }

            LastSaveFilePath = filename;
        }

        public static string NormalizeBigString(string text)
        {
            const uint maxLength = 50;
            if (text.Length < maxLength)
            {
                return text;
            }
            if (text.Split(' ').Length > 1)
                return text;


            while (text.Length > maxLength)
            {
                int mid = text.Length/2;
                text = text.Remove(mid);
            }

            text = text.Insert(text.Length / 2, "(...)");

            return text;
        }

        /// <summary>
        /// Show and select generated html file in explorer.
        /// </summary>
        public void ShowInExplorer()
        {
            if (string.IsNullOrEmpty(Program.HtmlTemplate.LastSaveFilePath)) return;
            ProcessManager.ShowInExplorer(Program.HtmlTemplate.LastSaveFilePath);
        }

        /// <summary>
        /// Show and select generated html file in explorer.
        /// </summary>
        public void OpenInDefaultBrowser()
        {
            if (string.IsNullOrEmpty(Program.HtmlTemplate.LastSaveFilePath)) return;
            ProcessManager.Open(Program.HtmlTemplate.LastSaveFilePath);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return TemplateHTML;
        }
        #endregion
    }
}
