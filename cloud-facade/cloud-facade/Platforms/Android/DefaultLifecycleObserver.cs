using AndroidX.Lifecycle;
using Java.Interop;
using Object = Java.Lang.Object;

namespace cloud_facade;

public class DefaultLifecycleObserver : Object, ILifecycleObserver
{
	[Export, Lifecycle.Event.OnCreate]
	public virtual void OnCreate(ILifecycleOwner owner)
	{
		
	}

	[Export, Lifecycle.Event.OnDestroy]
	public virtual void OnDestroy(ILifecycleOwner owner)
	{
		
	}

	[Export, Lifecycle.Event.OnPause]
	public virtual void OnPause(ILifecycleOwner owner)
	{
		
	}

	[Export, Lifecycle.Event.OnResume]
	public virtual void OnResume(ILifecycleOwner owner)
	{
		
	}

	[Export, Lifecycle.Event.OnStart]
	public virtual  void OnStart(ILifecycleOwner owner)
	{
		
	}

	[Export, Lifecycle.Event.OnStop]
	public virtual void OnStop(ILifecycleOwner owner)
	{
		
	}
}