using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMY.Consoles.StaticResource
{
    public class Upload
    {
        public static void DoUpload()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploadOne1.txt");

            //定义_webClient对象
            WebClient _webClient = new WebClient();
            //使用Windows登录方式
            _webClient.Credentials = CredentialCache.DefaultCredentials;// new NetworkCredential("test", "123");
            //上传的链接地址（文件服务器）            
            Uri _uri = new Uri(@"http://static.fmy.com/");
            byte[] responseArray=_webClient.UploadFile(_uri, path);
            string msg = Encoding.GetEncoding("gb2312").GetString(responseArray);
            //注册上传进度事件通知
            _webClient.UploadProgressChanged += _webClient_UploadProgressChanged;
            //注册上传完成事件通知
            _webClient.UploadFileCompleted += _webClient_UploadFileCompleted;
            //异步从D盘上传文件到服务器
            
            _webClient.UploadFileAsync(_uri,path);
            //Console.ReadKey();
        }

        private static void _webClient_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            Console.WriteLine("Upload Completed...");
        }

        //下载进度事件处理程序
        private static void _webClient_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.ProgressPercentage}:{e.BytesSent}/{e.TotalBytesToSend}");
        }
    }
}
