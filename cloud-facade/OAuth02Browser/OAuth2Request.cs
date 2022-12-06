namespace OAuth02Browser;

public static class OAuth2Request
{
	public static Task<TokenResult> GetTokenAsync(OAuth2Providers provider, CancellationToken cancellationToken = default)
	{
		var manager = IPlatformApplication.Current?.Services.GetService<OAuth2Manager>();

		if (manager == null)
			throw new InvalidOperationException("Use builder.UseOAuth() methods for regitration.");

		return manager.GetTokenAsync(provider.ToString(), cancellationToken);
	}

	public static Task<bool> SignOutAsync(OAuth2Providers provider, string token, CancellationToken cancellationToken = default)
	{
		return Task.FromResult(false);
	}
}