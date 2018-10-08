using System;
using System.Net;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FMY.WEB.UnitTest.IbatisDao
{
    [TestClass]
    public class StaticWebTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //定义_webClient对象
            WebClient _webClient = new WebClient();
            //使用默认的凭据——读取的时候，只需默认凭据就可以
            _webClient.Credentials = CredentialCache.DefaultCredentials;
            //下载的链接地址（文件服务器）
            Uri _uri = new Uri(@"http://static.fmy.com/sql1.txt");
            //注册下载进度事件通知
            _webClient.DownloadProgressChanged += _webClient_DownloadProgressChanged;
            //注册下载完成事件通知
            _webClient.DownloadFileCompleted += _webClient_DownloadFileCompleted;
            //异步下载到D盘
            string path = Path.Combine( AppDomain.CurrentDomain.BaseDirectory,"sql1.txt");
            _webClient.DownloadFileAsync(_uri, path);
            Console.ReadKey();
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
