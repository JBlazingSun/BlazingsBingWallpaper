using NUnit.Framework;
using BlazingsBingWallpaper.AppJ.Program.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        private ProgramFunc programFunc;
        private string localImageFileName;
        public ProgramFuncTests()
        {
            programFunc = ProgramFunc.GetInstance();
            localImageFileName = DateTime.Now.ToLongDateString()+Guid.NewGuid() + ".jpg";
        }
        [OneTimeTearDown]
        public void MyOneTimeTearDown()
        {
            var fileLocalPath = Path.Combine(ResourcesMy.tempFoder, localImageFileName);
            if (File.Exists(fileLocalPath))
            {
                File.Delete(fileLocalPath);
                if (File.Exists(fileLocalPath))
                {
                    Assert.Fail("删除文件失败");
                }
            }
        }

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
            Assert.That(apiIamgeUrl, Does.Contain(@"1920x1080"));
        }
        [Test()]
        [Ignore("")]
        public void setWallpaperTest()
        {
            programFunc.setWallpaper(@"F:\1.jpg");
        }
        [Test()]
        [Ignore("")]
        public void setWallpaperTest2()
        {
            programFunc.setWallpaper(@"F:\2.jpg");
        }

        [Test()]
        public void TestNetWorkTest()
        {
            var testNetWork = programFunc.TestNetWork(@"114.114.114.114");
            Assert.That(testNetWork, Is.True);
        }

        [Test]
        public void DownloadFileTest()
        {
            var imageAddr = programFunc.GetImageAddr(ResourcesMy.cnBingCom);
            var condition  = programFunc.DownloadFile(imageAddr, localImageFileName);
            Assert.That(condition,Is.True);
        }
        
    }
}