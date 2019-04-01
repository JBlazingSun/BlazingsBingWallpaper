using NUnit.Framework;
using BlazingsBingWallpaper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazingsBingWallpaper.AppJ.Model;
using Newtonsoft.Json;

namespace BlazingsBingWallpaper.Tests
{
    [TestFixture()]
    public class ProgramFuncTests
    {
        [Test()]
        public void GetIamgeUrlTest()
        {
            var programFunc = new ProgramFunc();
            var apiIamgeUrl = programFunc.GetIamgeUrl(new ResourcesMy().getApiUrl);
            var bingImageApi = JsonConvert.DeserializeObject<bingImageApi>(apiIamgeUrl);
            Assert.That(bingImageApi, Does.Contain("orthMale_1920x1080"));
        }
    }
}