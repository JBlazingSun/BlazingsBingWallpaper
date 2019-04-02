using NUnit.Framework;
using BlazingsBingWallpaper.AppJ.Program.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlazingsBingWallpaper.AppJ.Model;
using Newtonsoft.Json;

namespace BlazingsBingWallpaper.AppJ.Program.Service.Tests
{
    [TestFixture()]
    public class ProgramFuncTests
    {
        //如果要测试私有静态方法，则需要修改 BindingFlags 。 例子只用于实例方法
        private MethodInfo GetPrivateMethod(object methodClass, string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                Assert.Fail("methodName cannot be null or whitespace");
            var method = methodClass.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (method == null)
                Assert.Fail($"{methodName} method not found");
            return method;
        }
        [Test()]
        public void GetIamgeUrlTest()
        {
            var programFunc = GetPrivateMethod(ProgramFunc.GetInstance(), @"GetImageUrl");
            var apiIamgeUrl = programFunc.Invoke(ProgramFunc.GetInstance(), new object[] { ResourcesMy.apiUrl });
            var bingImageRoot = (BingImageRoot)JsonConvert.DeserializeObject((string)apiIamgeUrl, typeof(BingImageRoot));
            Assert.That(bingImageRoot?.images?[0].url, Does.Contain(@"orthMale_1920x1080"));
        }
        [Test()]
        public void setWallpaperTest()
        {
            Assert.Fail();
        }
    }
}