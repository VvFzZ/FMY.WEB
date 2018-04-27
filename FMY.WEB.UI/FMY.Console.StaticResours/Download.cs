using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;

namespace FMY.Consoles.StaticResours
{
    public class Download
    {
        public static void DoDownload()
        {
            //定义_webClient对象
            WebClient _webClient = new WebClient();
            //使用默认的凭据——读取的时候，只需默认凭据就可以
            _webClient.Credentials = CredentialCache.DefaultCredentials;
            //下载的链接地址（文件服务器）
            Uri _uri = new Uri(@"http://static.fmy.com/uploadOne.txt");
            //注册下载进度事件通知
            _webClient.DownloadProgressChanged += _webClient_DownloadProgressChanged;
            //注册下载完成事件通知
            _webClient.DownloadFileCompleted += _webClient_DownloadFileCompleted;
            //异步下载到D盘
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploadOne.txt");
            _webClient.DownloadFileAsync(_uri, path);

            Console.ReadKey();
        }

        public static void Select()
        {
            SortedList<string, ServerFileAttributes> _results = GetContents(@"http://static.fmy.com", true);
            //在控制台输出文件（或目录）信息：
            foreach (var _r in _results)
            {
                Console.WriteLine($"{_r.Key}:\r\nName:{_r.Value.Name}\r\nIsFolder:{_r.Value.IsFolder}");
                Console.WriteLine($"Value:{_r.Value.Url}\r\nLastModified:{_r.Value.LastModified}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        //定义每个文件或目录的属性
        struct ServerFileAttributes
        {
            public string Name;
            public bool IsFolder;
            public string Url;
            public DateTime LastModified;
        }

        //将文件或目录列出来
        static SortedList<string, ServerFileAttributes> GetContents(string serverUrl, bool deep)
        {
            HttpWebRequest _httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
            _httpWebRequest.Headers.Add("Translate: f");
            _httpWebRequest.Credentials = CredentialCache.DefaultCredentials;

            string _requestString = @"<?xml version=""1.0"" encoding=""utf-8""?>" +
                  @"<a:propfind xmlns:a=""DAV:"">" +
                  "<a:prop>" +
                  "<a:displayname/>" +
                  "<a:iscollection/>" +
                  "<a:getlastmodified/>" +
                  "</a:prop>" +
                  "</a:propfind>";

            _httpWebRequest.Method = "PROPFIND";
            if (deep == true)
                _httpWebRequest.Headers.Add("Depth: infinity");
            else
                _httpWebRequest.Headers.Add("Depth: 1");
            _httpWebRequest.ContentLength = _requestString.Length;
            _httpWebRequest.ContentType = "text/xml";

            Stream _requestStream = _httpWebRequest.GetRequestStream();
            _requestStream.Write(Encoding.ASCII.GetBytes(_requestString), 0, Encoding.ASCII.GetBytes(_requestString).Length);
            _requestStream.Close();

            HttpWebResponse _httpWebResponse;
            StreamReader _streamReader;
            try
            {
                _httpWebResponse = (HttpWebResponse)_httpWebRequest.GetResponse();
                _streamReader = new StreamReader(_httpWebResponse.GetResponseStream());
            }
            catch (WebException ex)
            {
                throw ex;
            }

            StringBuilder _stringBuilder = new StringBuilder();

            char[] _chars = new char[1024];
            int _bytesRead = 0;

            _bytesRead = _streamReader.Read(_chars, 0, 1024);

            while (_bytesRead > 0)
            {
                _stringBuilder.Append(_chars, 0, _bytesRead);
                _bytesRead = _streamReader.Read(_chars, 0, 1024);
            }
            _streamReader.Close();

            XmlDocument _xmlDocument = new XmlDocument();
            _xmlDocument.LoadXml(_stringBuilder.ToString());

            XmlNamespaceManager _xmlNamespaceManager = new XmlNamespaceManager(_xmlDocument.NameTable);
            _xmlNamespaceManager.AddNamespace("a", "DAV:");

            XmlNodeList _nameList = _xmlDocument.SelectNodes("//a:prop/a:displayname", _xmlNamespaceManager);
            XmlNodeList _isFolderList = _xmlDocument.SelectNodes("//a:prop/a:iscollection", _xmlNamespaceManager);
            XmlNodeList _lastModifyList = _xmlDocument.SelectNodes("//a:prop/a:getlastmodified", _xmlNamespaceManager);
            XmlNodeList _hrefList = _xmlDocument.SelectNodes("//a:href", _xmlNamespaceManager);

            SortedList<string, ServerFileAttributes> _sortedListResult = new SortedList<string, ServerFileAttributes>();
            ServerFileAttributes _serverFileAttributes;

            for (int i = 0; i < _nameList.Count; i++)
            {
                if (_hrefList[i].InnerText.ToLower(new CultureInfo("en-US")).TrimEnd(new char[] { '/' }) != serverUrl.ToLower(new CultureInfo("en-US")).TrimEnd(new char[] { '/' }))
                {
                    _serverFileAttributes = new ServerFileAttributes();
                    _serverFileAttributes.Name = _nameList[i].InnerText;
                    _serverFileAttributes.IsFolder = Convert.ToBoolean(Convert.ToInt32(_isFolderList[i].InnerText));
                    _serverFileAttributes.Url = _hrefList[i].InnerText;
                    _serverFileAttributes.LastModified = Convert.ToDateTime(_lastModifyList[i].InnerText);
                    _sortedListResult.Add(_serverFileAttributes.Url, _serverFileAttributes);
                }
            }
            return _sortedListResult;
        }
        //下载完成事件处理程序
        private static void _webClient_DownloadFileCompleted(
            object sender
            , System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download Completed...");
        }

        //下载进度事件处理程序
        private static void _webClient_DownloadProgressChanged(
            object sender
            , DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.ProgressPercentage}:{e.BytesReceived}/{e.TotalBytesToReceive}");
        }
    }
}
