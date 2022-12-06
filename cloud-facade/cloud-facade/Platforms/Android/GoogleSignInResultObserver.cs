using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Extensions;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using AndroidX.Lifecycle;
using cloud_facade.Services;

namespace cloud_facade;

class GoogleSignInResultObserver : DefaultLifecycleObserver
{
	#region Private fields

	private ActivityResultLauncher? _signInLauncher;
	private readonly Lazy<GoogleSignInClient> _signInClient = new(CreateSignClient, false);
	private TaskCompletionSource<ActivityResult?>? _signInTask;

	#endregion

	#region Properties

	public ActivityResultRegistry? Registry { get; set; }

	#endregion

	#region Private methods

	private static GoogleSignInClient CreateSignClient()
	{
		using var builder = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn);
		using var options = builder
			.RequestEmail()
			.RequestScopes(new Scope(Scopes.DriveFull))
			.Build();

		return GoogleSignIn.GetClient(Android.App.Application.Context, options);
	}

	#endregion

	public override void OnCreate(ILifecycleOwner owner)
	{
		_signInLauncher = Registry?.Register("", owner, new ActivityResultContracts.StartActivityForResult(),
			new ActivityResultCallback<ActivityResult>(r =>
			{
				_signInTask?.SetResult(r);

			}));
	}
	
	public async Task<string> GetTokenAsync(CancellationToken cancellationToken)
	{
		var intent = _signInClient.Value.SignInIntent;

		_signInTask = new TaskCompletionSource<ActivityResult?>();
		_signInLauncher?.Launch(intent);

		var result = await _signInTask.Task;
		
		var account = await GoogleSignIn.GetSignedInAccountFromIntent(result.Data);
				
		
		return string.Empty;
	}

	public async Task<bool> SignOutAsync(CancellationToken cancellationToken)
	{
		var result = await _signInClient.Value.SignOut();

		return true;
	}
}