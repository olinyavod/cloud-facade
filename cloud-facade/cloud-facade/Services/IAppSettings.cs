namespace cloud_facade.Services;

interface IAppSettings
{
	#region Properties

	string? YandexToken { get; set; }

	DateTime YandexTokenDate { get; set; }

	public long YandexExpiry { get; set; }

	#endregion
}