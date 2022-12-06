namespace cloud_facade.IoCModules;

static class ViewModelsModule
{
	public static void UseViewModel(this IServiceCollection services)
	{
		services.AddTransient<MainViewModel>();
	}
}