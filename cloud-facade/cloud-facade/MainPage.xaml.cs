namespace cloud_facade;

public partial class MainPage : ContentPage
{
	private MainViewModel _mainViewModel;

	public MainPage()
	{
		InitializeComponent();
	}


	protected override void OnHandlerChanged()
	{
		base.OnHandlerChanged();
		
		_mainViewModel = Handler!.MauiContext!.Services.GetService<MainViewModel>();

		BindingContext = _mainViewModel;
	}
}