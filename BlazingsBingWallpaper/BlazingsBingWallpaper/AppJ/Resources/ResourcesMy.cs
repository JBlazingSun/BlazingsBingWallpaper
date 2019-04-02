using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingsBingWallpaper.AppJ.Model
{
    public static class ResourcesMy
    {
        static ResourcesMy()
        {
            tempFoder = Path.GetTempPath();
        }

        public static string apiUrl = @"https://bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";
        public static string cnBingCom = @"https://cn.bing.com";
        public static string tempFoder = @"";
    }
}
