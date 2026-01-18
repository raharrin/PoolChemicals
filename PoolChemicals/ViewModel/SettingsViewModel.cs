
using Microsoft.Maui;
using PoolChemicals.Model;
using PoolChemicals.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace PoolChemicals.ViewModel
{
    public partial class SettingsViewModel : BaseViewModel
    {

        //// This delegate defines the signature for the event handler
        //public delegate void UpdateSettingsEvent(string control, string name);
        //// This event is raised when the settings are updated
        //public event UpdateSettingsEvent? SettingsEvent;
        [ObservableProperty]
        public AppSettings settings;
        //[ObservableProperty]
        public MainLogic Logic;
        [ObservableProperty]
        public List<string> standardUnits = [];

        public SettingsViewModel(MainLogic _logic, AppSettings _settings)// : base()
        {
            Settings = _settings;
            Logic = _logic;
            // The following simplfies getting the names of the
            // enum values as strings
            // StandardUnits = Enum.GetNames(typeof(Units.Model)).ToList();
            // StandardUnits = Enum.GetNames<Units.Model>().ToList();
            StandardUnits = [.. Enum.GetNames<Units.Model>()];
        }

        //[RelayCommand]
        //async Task GoBack()
        //{
        //    await Shell.Current.GoToAsync("..");
        //}

    }
}
