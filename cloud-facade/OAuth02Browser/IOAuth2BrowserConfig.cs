namespace OAuth02Browser;

public interface IOAuth2BrowserConfig
{
	void AddProvider(string providerName, IOAuthTokenProvider provider);
}