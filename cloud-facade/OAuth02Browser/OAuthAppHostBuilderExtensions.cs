using Microsoft.Maui.LifecycleEvents;

namespace OAuth02Browser;

public static class OAuthAppHostBuilderExtensions
{
	public static MauiAppBuilder UseOAuth2(this MauiAppBuilder builder, Action<IOAuth2BrowserConfig> onConfigure)
	{
		var manager = new OAuth2Manager();

		onConfigure?.Invoke(manager);

		builder.Services.AddSingleton(manager);

		builder.ConfigureLifecycleEvents(events =>
		{
#if __ANDROID__
			events.UseAndroidEvents();
#endif
		});

		return builder;
	}
}