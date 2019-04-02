using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BlazingsBingWallpaper.AppJ.Model;
using BlazingsBingWallpaper.AppJ.Program.Service;

namespace BlazingsBingWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            var programFunc = ProgramFunc.GetInstance();
            var imageAddr = programFunc.GetImageAddr(ResourcesMy.cnBingCom);

        }
    }
}
