using Xamarin.UITest;

namespace Jaktapp.Tests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                // relative path from 'Jaktapp.Test/bin/<Debug/Release>/Jaktapp.Test.dll'
                // The uploaded apk to appcenter shall be a Release-build, to be as close to prod-app as possible
                return ConfigureApp
                    .Android
                    .ApkFile("../../../Jaktapp/bin/Release/jaktlag.rodsjodev.no.apk")
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

