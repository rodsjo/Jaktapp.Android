using System;
using System.IO;
using System.Linq;
using Jaktapp.Tests;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace Jaktapp.Test
{
    [TestFixture(Platform.Android)]
    public class StartupTests
    {
        private IApp _app;
        private readonly Platform _platform;
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(20);

        public StartupTests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public void App_should_start_and_show_login()
        {
            //Arrange
            //https://docs.microsoft.com/en-us/appcenter/test-cloud/uitest/#using-the-repl
            //_app.Repl();

            //Act
            var loginBtn = _app.WaitForElement(v => v.Marked("LoginBtn"), "Timed out waiting for favorites tab", _timeout);

            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(loginBtn[0].Text));

            _app.Screenshot("Login screen");
        }
    }
}

