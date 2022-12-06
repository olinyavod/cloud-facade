namespace cloud_facade.Extensions;

public static class IoCExtensions
{
	public static TService? Resolve<TService>(this object _) => (TService?) IPlatformApplication
		.Current
		?.Services
		?.GetService(typeof(TService));

	public static IServiceScope CreateScope(this object _) => ServiceProviderServiceExtensions.CreateScope
	(
		IPlatformApplication.Current!.Services
	);

	public static AsyncServiceScope CreateAsyncScope(this object _) => ServiceProviderServiceExtensions.CreateAsyncScope
	(
		IPlatformApplication.Current!.Services
	);
}