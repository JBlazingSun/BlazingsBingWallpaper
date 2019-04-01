using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BlazingsBingWallpaper
{
    public class ProgramFunc
    {
        string imageApi = "bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        //以拉伸方式显示墙纸
        public void menuItemStretch_Click(object sender, System.EventArgs e)
        {
            
        }
        public string GetIamgeUrl()
        {
            string imageUrl= "https://cn.bing.com"; 

            return imageUrl;
        }

        public string GetImageApiAddr()
        {
            string addr = "";

            return addr;
        }
    }
}
