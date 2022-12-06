namespace cloud_facade.Services;

class AppSettings : IAppSettings
{
	#region Properties

	public string? YandexToken
	{
		get => Preferences.Get(nameof(YandexToken), string.Empty);
		set => Preferences.Set(nameof(YandexToken), value);
	}

	public DateTime YandexTokenDate
	{
		get => Preferences.Get(nameof(YandexTokenDate), DateTime.MinValue);
		set => Preferences.Set(nameof(YandexTokenDate), value);
	}

	public long YandexExpiry
	{
		get => Preferences.Get(nameof(YandexExpiry), 0);
		set => Preferences.Set(nameof(YandexExpiry), value);
	}

	#endregion
}