namespace OAuth02Browser.Providers;

class YandexOAuth2Provider : IOAuthTokenProvider
{
	#region Private fields

	private readonly string _clientId;
	private readonly string _secret;
	private readonly string? _redirectUrl;

	private TaskCompletionSource<string>? _authTask;
	private CancellationTokenRegistration _cancellationTokenRegistration;

	#endregion

	#region ctor

	public YandexOAuth2Provider(string clientId, string secret, string? redirectUrl = null)
	{
		_clientId = clientId;
		_secret = secret;
		_redirectUrl = redirectUrl;
	}

	#endregion

	public async Task<TokenResult> GetTokenAsync(CancellationToken cancellationToken)
	{
		await Launcher.OpenAsync
		(
			new Uri
			(
				$"https://oauth.yandex.ru/authorize?response_type=token&client_id={_clientId}&redirect_uri={_redirectUrl}"
			)
		);

		try
		{
			_authTask = new TaskCompletionSource<string>();

			_cancellationTokenRegistration =
				cancellationToken.Register(() => _authTask.SetCanceled(_cancellationTokenRegistration.Token));

			var result = await _authTask.Task;

			return new TokenResult(true, result, null);
		}
		catch (OperationCanceledException)
		{
			return new TokenResult(false, null, null);
		}
		finally
		{
			await _cancellationTokenRegistration.DisposeAsync();
			_authTask = null;
		}
	}

	public Task<bool> SignOutAsync(CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public void EndAuth(string result)
	{
		_authTask?.SetResult(result);
	}

	public void Cancel()
	{
		_authTask?.SetCanceled(_cancellationTokenRegistration.Token);
	}
}