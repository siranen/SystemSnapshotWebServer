﻿using System;
using System.Globalization;

namespace SystemSnapshotWebServer.Reports
{
    public sealed class Title : Report
    {
        public const string TemplateVar = "<!--[TITLE]-->";

        public Title()
        {
            CanAsync = false;
        }

        public override string GetTemplateVar()
        {
            return TemplateVar;
        }

        protected override void Build()
        {
            HtmlWriter.Write("{0} - {1}", Environment.MachineName, DateTime.Now.ToString(CultureInfo.CurrentCulture));
        }
    }
}
