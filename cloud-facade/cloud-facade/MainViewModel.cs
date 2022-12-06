using cloud_facade.Extensions;
using cloud_facade.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OAuth02Browser;

namespace cloud_facade;

[INotifyPropertyChanged]
public partial class MainViewModel
{
	[ObservableProperty]
	private string? _title;
	

	public MainViewModel()
	{
		
	}

	[RelayCommand]
	private void OnChangeTheme()
	{
		App.Current.UserAppTheme = App.Current.UserAppTheme == AppTheme.Dark
			? AppTheme.Light
			: AppTheme.Dark;
	}

	[RelayCommand(AllowConcurrentExecutions = true)]
	private async Task OnAuthToGoogle()
	{
		var token = await OAuth2Request.GetTokenAsync(OAuth2Providers.Google);
	}

	[RelayCommand(AllowConcurrentExecutions = true)]
	private async Task OnGoogleSignOut()
	{
		await OAuth2Request.SignOutAsync(OAuth2Providers.Google, "");
	}

	[RelayCommand(AllowConcurrentExecutions = true)]
	private async Task OnYandexSignIn()
	{
		try
		{
			var token = await OAuth2Request.GetTokenAsync(OAuth2Providers.Yandex);
		}
		catch (Exception ex)
		{

		}
	}

}