using System;
using System.Globalization;
using System.IO;
using System.Media;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using BlazingsBingWallpaper.AppJ.Model;
using Newtonsoft.Json;

namespace BlazingsBingWallpaper.AppJ.Program.Service
{
    public class ProgramFunc
    {
        private ProgramFunc()
        {
        }
        private static ProgramFunc programFunc = new ProgramFunc();

        public static ProgramFunc GetInstance()
        {
            return programFunc;
        }
        private string GetImageUrl(string getUrl)
        {
            string imageUrl= "";
            var Client = new WebClient();
            var Bytes = Client.DownloadData(getUrl);
            imageUrl = Encoding.UTF8.GetString(Bytes);
            var bingImageRoot = (BingImageRoot)JsonConvert.DeserializeObject(imageUrl, typeof(BingImageRoot));
            imageUrl = bingImageRoot.images[0].url;
            return imageUrl;
        }

        public string GetImageAddr(string bingDomain)
        {
            return bingDomain + GetImageUrl(ResourcesMy.apiUrl);
        }

        public bool DownloadFile(string fileUrl,string localFileName)
        {
            var fileLocalPath = Path.Combine(ResourcesMy.tempFoder, localFileName);
            WebClient wc = new WebClient();
            wc.DownloadFile(new Uri(fileUrl, UriKind.Absolute), fileLocalPath);
            if (File.Exists(fileLocalPath))
            {
                return true;
            }
            return false;
        }
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
            int uAction,
            int uParam,
            string lpvParam,
            int fuWinIni
        );
        public void setWallpaper(string Path)
        {
            if (File.Exists(Path))
            {
                SystemParametersInfo(20, 0, Path, 0x2); // 0x1 | 0x2 
                
            }
        }

        public bool TestNetWork(string url)
        {
            Ping ping = new Ping();
            try
            {
                int timeout = 3; //设置超时时间
                PingReply pr = ping.Send(url, timeout);
                if (pr.Status == IPStatus.Success)
                    return true;
                if (pr.Status == IPStatus.TimedOut)
                    return false;

            }
            catch (Exception)
            {
                MessageBox.Show("没有网络连接");
            }
            return false;
        }
    }
}
