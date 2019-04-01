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
            var bingImageRoot = (BingImageRoot)JsonConvert.DeserializeObject(apiIamgeUrl, typeof(BingImageRoot));

            Assert.That(bingImageRoot?.images?[0].url , Does.Contain(@"orthMale_1920x1080"));
        }



        public class address

        {

            public string city;

            public string province;
        }
    }
}