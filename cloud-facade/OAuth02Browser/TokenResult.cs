namespace OAuth02Browser;

public class TokenResult
{
	#region Properties

	public bool Success { get; }

	public string? Token { get; }

	public int? Expiry { get; }

	#endregion

	#region ctor

	internal TokenResult(bool success, string? token, int? expiry)
	{
		Success = success;
		Token = token;
		Expiry = expiry;
	}

	#endregion
}