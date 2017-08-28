using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FMY.WEB.Comm.Tools.ConfigTools
{
    public class CustomConfigSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            RobsunPara para = new RobsunPara();

            foreach (XmlNode xn in section.ChildNodes)
            {
                switch (xn.Name)
                {
                    case "path":
                        para.Path = xn.SelectSingleNode("@value").InnerText;
                        break;
                    case "companyName":
                        para.CompanyName = xn.SelectSingleNode("@value").InnerText;
                        break;
                    case "isPrivate":
                        para.IsPrivate = bool.Parse(xn.SelectSingleNode("@attribute").InnerText);
                        break;
                    case "Test":
                        string str = xn.SelectSingleNode("item").Name + xn.SelectSingleNode("item").Value;
                        break;
                }
            }

            return para;
        }
    }

    public class RobsunPara
    {
        private string _path = "";
        private string _companyName = "";
        private bool _isPrivate = false;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public bool IsPrivate
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
        }
    }
}
