using AndroidX.Activity.Result;
using Object = Java.Lang.Object;

namespace cloud_facade;

class ActivityResultCallback<TResult> : Object, IActivityResultCallback
	where TResult : class
{
	private readonly Action<TResult?> _onResult;

	public ActivityResultCallback(Action<TResult?> onResult)
	{
		_onResult = onResult;
	}

	public void OnActivityResult(Object result)
	{
		_onResult?.Invoke(result as TResult);
	}
}