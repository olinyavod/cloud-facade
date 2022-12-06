using Android.Accounts;
using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Runtime;
using AndroidX.Activity.Result;
using cloud_facade.Platforms.Android.IoCModules;
using Application = Android.App.Application;

namespace cloud_facade;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
		
	}

	protected override MauiApp CreateMauiApp()
	{
		return MauiProgram.CreateMauiApp(services =>
		{
			services.UseAndroidServices();
		});
	}
}