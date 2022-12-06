namespace OAuth02Browser;

public interface IOAuthTokenProvider
{
	Task<TokenResult> GetTokenAsync(CancellationToken cancellationToken);

	Task<bool> SignOutAsync(CancellationToken cancellationToken);
		
	void EndAuth(string? result);

	void Cancel();
}