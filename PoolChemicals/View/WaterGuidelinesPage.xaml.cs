using PoolChemicals.ViewModel;

namespace PoolChemicals.View;

public partial class WaterGuidelinesPage : ContentPage
{
	public WaterGuidelinesPage(WaterGuidelinesViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}