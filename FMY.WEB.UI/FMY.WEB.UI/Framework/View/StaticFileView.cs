using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace FMY.WEB.UI.Framework.View
{
    public class StaticFileView : IView
    {
        public StaticFileView(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; set; }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            byte[] buffer;
            using (FileStream fs = new FileStream(this.FileName, FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
            }
            writer.Write(Encoding.UTF8.GetString(buffer));
        }
    }
}