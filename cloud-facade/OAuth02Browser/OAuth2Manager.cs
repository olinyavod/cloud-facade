using OAuth02Browser.Providers;

namespace OAuth02Browser;

class OAuth2Manager : IOAuth2BrowserConfig
{
	#region Private fields

	private readonly Dictionary<string, IOAuthTokenProvider> _providersMap = new();

	private IOAuthTokenProvider _provider;

	#endregion

	#region Public methods

	public void AddProvider(string providerName, IOAuthTokenProvider provider)
	{
		_providersMap[providerName] = provider;
	}

	#endregion

	public Task<TokenResult> GetTokenAsync(string providerName, CancellationToken cancellationToken)
	{
		if (!_providersMap.TryGetValue(providerName, out var provider))
			throw new ArgumentException($"Provider {providerName} not registered.", nameof(providerName));

		_provider = provider;

		return provider.GetTokenAsync(cancellationToken);
	}

	public void SetResult(string? result)=> _provider?.EndAuth(result);

	public void Cancel() => _provider?.Cancel();

}

public static class OAuth2BrowserConfigExtensions
{
	public static IOAuth2BrowserConfig AddYandex
	(
		this IOAuth2BrowserConfig config,
		string clientId,
		string secret,
		string? redirectUrl = null
	)
	{
		config.AddProvider(nameof(OAuth2Providers.Yandex), new YandexOAuth2Provider(clientId, secret, redirectUrl));
		return config;
	}
} 