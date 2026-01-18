
namespace PoolChemicals.View;

public partial class EmailPage : ContentPage
{
    private EmailViewModel viewModel;// = new();
    public EmailPage(EmailViewModel vm) // was main
	{
		InitializeComponent();
        viewModel = vm;
        BindingContext = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Load data specific to this page
        viewModel.CompileData();
    }
}