using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazingsBingWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            testFunc();

        }

        public static void testFunc()
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(new Uri("https://cn.bing.com/th?id=OHR.Uranus_ZH-CN9689723562_1920x1080.jpg&rf=NorthMale_1920x1080.jpg", UriKind.Absolute), "F:\\"+DateTime.Today.ToLongDateString() + ".jpg");
        }
    }
}
