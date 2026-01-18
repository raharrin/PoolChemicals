//using PoolChemicals.ViewModel;

using static System.Net.Mime.MediaTypeNames;

namespace PoolChemicals.View;

public partial class SettingsPage : ContentPage
{
    //ViewModel.MainViewModel vm = new MainViewModel(); 
    public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}
