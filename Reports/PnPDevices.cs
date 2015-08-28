﻿using System.Web.UI;
using SystemSnapshotWebServer.Core;

namespace SystemSnapshotWebServer.Reports
{
    public sealed class PnPDevices : Report
    {
        public const string TemplateVar = "<!--[PNPDEVICES]-->";

        public override string GetTemplateVar()
        {
            return TemplateVar;
        }

        protected override void Build()
        {
            if (SystemHelper.IsWindows)
            {
                Managers.DeviceManager.Update();
                HtmlWriter.AddAttribute(HtmlTextWriterAttribute.Class, TABLE_CLASS);
                HtmlWriter.RenderBeginTag(HtmlTextWriterTag.Table);

                HtmlWriter.RenderBeginTag(HtmlTextWriterTag.Thead);
                HtmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);

                HtmlWriter.RenderTag(HtmlTextWriterTag.Th, "#");
                HtmlWriter.RenderTag(HtmlTextWriterTag.Th, "Device ID");
                HtmlWriter.RenderTag(HtmlTextWriterTag.Th, "Description");
                HtmlWriter.RenderTag(HtmlTextWriterTag.Th, "Manufacturer");

                HtmlWriter.RenderEndTag(); // </tr>
                HtmlWriter.RenderEndTag(); // </thead>

                HtmlWriter.RenderBeginTag(HtmlTextWriterTag.Tbody);
            
                var i = 0;
                foreach (var device in Managers.DeviceManager)
                {
                    i++;
                    HtmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);

                    HtmlWriter.RenderTag(HtmlTextWriterTag.Td, HtmlTextWriterAttribute.Class, "index", i.ToString());
                    HtmlWriter.RenderTag(HtmlTextWriterTag.Td, HtmlTextWriterAttribute.Class, "deviceid", device.DeviceID);
                    HtmlWriter.RenderTag(HtmlTextWriterTag.Td, HtmlTextWriterAttribute.Class, "description", device.Description);
                    HtmlWriter.RenderTag(HtmlTextWriterTag.Td, HtmlTextWriterAttribute.Class, "manufacturer", device.Manufacturer);
                    HtmlWriter.RenderEndTag(); // </tr>
                }
                HtmlWriter.RenderEndTag(); // </tbody>
                HtmlWriter.RenderEndTag(); // </table>
            }
            else
            {
                WriteNotSupportedMsg();
            }
        }
    }
}
