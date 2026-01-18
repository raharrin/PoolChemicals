
namespace PoolChemicals.ViewModel
{
    public partial class WaterGuidelinesViewModel //: BaseViewModel
    {
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
