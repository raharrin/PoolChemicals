using Microsoft.Extensions.Logging;
using PoolChemicals.ViewModel;
using PoolChemicals.View;
using Microsoft.Maui.LifecycleEvents;
using CommunityToolkit.Maui;
using PoolChemicals.Model;

namespace PoolChemicals;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JGaF5cXGpCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWH1ccHVWQmhcWUF+VkNWYEs");
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .UseMauiCommunityToolkit() 
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
//        builder.ConfigureLifecycleEvents(AppLifecycle => {
//#if WINDOWS
//        AppLifecycle
//         .AddWindows(windows =>
//           windows.OnClosed((app, args) => {
//             app.ExtendsContentIntoTitleBar = false;
//           }));
//#else#if ANDROID
//            AppLifecycle.AddAndroid(android => android
//               .OnDestroy((activity) => BackPressed()));
//#endif
//        });


#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<LogViewModel>();// s => ActivatorUtilities.CreateInstance<LogViewModel>(s, dbPath));
        builder.Services.AddSingleton<BaseViewModel>();
        builder.Services.AddSingleton<WaterGuidelinesViewModel>();
        builder.Services.AddSingleton<EmailViewModel>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();

        //    builder.Services.AddSingleton<WaterGuidelinesPage>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainLogic>();
        builder.Services.AddSingleton<AppSettings>();
        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddSingleton<LogPage>();
        builder.Services.AddSingleton<PoolPage>();
        builder.Services.AddSingleton<EmailPage>();
        //Models
        builder.Services.AddSingleton<AppSettings>();
        builder.Services.AddSingleton<MainLogic>();



        builder.Services.AddSingleton(Preferences.Default);
        return builder.Build();
	}
}
