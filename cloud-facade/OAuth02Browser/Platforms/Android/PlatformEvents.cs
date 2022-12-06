using Android.Content;
using Microsoft.Maui.LifecycleEvents;

namespace OAuth02Browser;

// All the code in this file is only included on Android.
public static class PlatformEvents
{
	public static void UseAndroidEvents(this ILifecycleBuilder events)
	{
		events.AddAndroid(cfg =>
		{
			cfg.OnNewIntent((activity, intent) =>
			{
				if (intent!.Categories?.Contains(Intent.CategoryBrowsable) != true
				    || intent!.Action != Intent.ActionView
				    || intent?.DataString is not { } dataString)
					return;

				var oauth2Manager = IPlatformApplication.Current?.Services.GetService<OAuth2Manager>();

				oauth2Manager?.SetResult(dataString);
			});

			cfg.OnResume(a =>
			{
				var oauth2Manager = IPlatformApplication.Current?.Services.GetService<OAuth2Manager>();

				oauth2Manager?.Cancel();
			});
		});
	}
}