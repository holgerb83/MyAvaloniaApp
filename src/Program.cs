using Avalonia;

namespace MyAvaloniaApp
{
    internal static class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UseDirect2D1()
                .UsePlatformDetect()
                .With(new SkiaOptions { MaxGpuResourceSizeBytes = 8096000 })
                .With(new Win32PlatformOptions { AllowEglInitialization = true })
                .LogToTrace();
    }
}
