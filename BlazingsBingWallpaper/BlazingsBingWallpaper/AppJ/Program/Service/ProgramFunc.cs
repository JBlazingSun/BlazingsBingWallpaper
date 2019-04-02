using System;
using System.Globalization;
using System.IO;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using BlazingsBingWallpaper.AppJ.Model;

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

        //以拉伸方式显示墙纸
        public void menuItemStretch_Click(object sender, EventArgs e)
        {
            
        }
        private string GetImageUrl(string getUrl)
        {
            string imageUrl= "";
            var Client = new WebClient();
            var Bytes = Client.DownloadData(getUrl);
            imageUrl = Encoding.UTF8.GetString(Bytes);
            return imageUrl;
        }

        public string GetImageAddr(string bingDomain)
        {
            return bingDomain + GetImageUrl(ResourcesMy.apiUrl);
        }

        public static void testFunc()
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(new Uri("https://cn.bing.com/th?id=OHR.Uranus_ZH-CN9689723562_1920x1080.jpg&rf=NorthMale_1920x1080.jpg", UriKind.Absolute), "F:\\" + DateTime.Today.ToLongDateString() + ".jpg");
        }
        public string strPath = "";
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
    }
}
