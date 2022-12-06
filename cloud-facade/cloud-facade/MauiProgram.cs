using cloud_facade.IoCModules;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.LifecycleEvents;
using OAuth02Browser;

namespace cloud_facade;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp(Action<IServiceCollection> onPlatform)
	{
		var builder = MauiApp.CreateBuilder();
		
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.UseOAuth2(cfg =>
		{
			cfg.AddYandex
			(
				Properties.Resources.YaClientId,
				Properties.Resources.YaClientSecret,
				"cloudfd://cloud-facade.ru"
			);
		});

		builder.Services.UseViewModel();
		onPlatform(builder.Services);

		return builder.Build();
	}
}