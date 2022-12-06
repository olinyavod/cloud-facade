using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using cloud_facade.Extensions;

namespace cloud_facade;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new [] {Intent.ActionView}, Categories = new [] {Intent.CategoryDefault, Intent.CategoryBrowsable}, DataScheme = "cloudfd")]
public class MainActivity : MauiAppCompatActivity
{
	protected override void OnCreate(Bundle? savedInstanceState)
	{
		//var googleSignInResultObserver = this.Resolve<GoogleSignInResultObserver>()!;

		//googleSignInResultObserver.Registry = ActivityResultRegistry;
		//Lifecycle.AddObserver(googleSignInResultObserver);

		base.OnCreate(savedInstanceState);
	}

	protected override void OnNewIntent(Intent? intent)
	{
		base.OnNewIntent(intent);
	}

	protected override void OnResume()
	{
		base.OnResume();
	}
}