using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlazingsBingWallpaper.AppJ.Model;
using BlazingsBingWallpaper.AppJ.Program.Service;

namespace BlazingsBingWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.hideConsole();
            var programFunc = ProgramFunc.GetInstance();

            //if (!programFunc.TestNetWork(@"114.114.114.114"))
            //{
            //    MessageBox.Show("网络连接失败,请重新打开程序");
            //    return;
            //}
            //else
            //{
            //    programFunc.ConsoleWriteLineShow("网络正常");
            //}

            var imageAddr = programFunc.GetImageAddr(ResourcesMy.cnBingCom);
            programFunc.ConsoleWriteLineShow(imageAddr);
            var fileName = DateTime.Now.ToLongDateString() + Guid.NewGuid() + ".jpg";
            programFunc.ConsoleWriteLineShow(fileName);
            if (programFunc.DownloadFile(imageAddr,fileName))
            {
                programFunc.setWallpaper(Path.Combine(Path.GetTempPath(),fileName));

                programFunc.ConsoleWriteLineShow("设置壁纸");

                Thread.Sleep(1*1000);
                var deleteFile = Path.Combine(Path.GetTempPath(), fileName);
                programFunc.DeleteDownLoadFile(deleteFile);

                programFunc.ConsoleWriteLineShow("删除下载文件");
            }
        }
    }
}
