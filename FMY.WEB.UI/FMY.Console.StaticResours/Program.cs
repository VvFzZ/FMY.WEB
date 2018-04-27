using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FMY.Consoles.StaticResource
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Success
                //Download.Select();
                //Success
                //Download.DoDownload();

                //Error 405
                //Upload.DoUpload();
            }
            catch (Exception ex)
            {
                throw;
            }
            
            Console.ReadKey();
        }
        
    }
}
