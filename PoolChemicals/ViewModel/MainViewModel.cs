using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
using PoolChemicals.Model;
using PoolChemicals.View;
using Syncfusion.Maui.Inputs;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace PoolChemicals.ViewModel

{
    public partial class MainViewModel : BaseViewModel //ObservableValidator
    {

        public string AppPackageName => AppInfo.PackageName;
        public string AppName => AppInfo.Name;
        public string AppVersion => AppInfo.VersionString;
        public string AppBuild => AppInfo.BuildString;


        [ObservableProperty]
        public List<Units.Model> standardUnits = Enum.GetValues(typeof(Units.Model)).Cast<Units.Model>().ToList();

        [ObservableProperty]
        public bool isValidataionValid = true;



        [ObservableProperty]
        protected double unitsMultiplyer;


 
        private protected int oldUnit;
        private protected int measureUnit;
        [ObservableProperty]
        private protected string? sizeUnit;

        [ObservableProperty]
        private protected string? tempUnit;




        [ObservableProperty]
        public AppSettings settings;
        [ObservableProperty]
        public MainLogic logic;


        public MainViewModel(MainLogic _logic, AppSettings _settings)
        {
           Settings = _settings;
            Logic = _logic;
            AppSettings.OnSettingsEvent += SettingsEvent;
        }


        private void SettingsEvent(string control, string name)
        {
            // Handle the settings event here
            Debug.WriteLine($"SettingsEvent triggered for control: {control}, name: {name}");
        }



        //[RelayCommand]
        //async Task GoToEmail(TestInt tests)
        //{
        //    if (tests == null)
        //        return;

        //    await Shell.Current.GoToAsync(nameof(EmailPage), true, new Dictionary<string, object>
        //{
        //    {"TestInt", tests }
        //});
        //}




        //Move to base class
        public ICommand AlertCommand => new Command<string>(OnAlertCommandExecuted);
        private void OnAlertCommandExecuted(string parameter)
        {

            DisplayAlert("Alert");
        }

        private void DisplayAlert(string Text)
        {
            AppShell.Current.DisplayAlert("Alert", Text, "OK");
        }


        [RelayCommand]
        async Task WaterGuidelines()
        {
            await Shell.Current.GoToAsync($"{nameof(WaterGuidelinesPage)}");
        }

        [RelayCommand]
        private async Task Targets()
        {
            await Shell.Current.GoToAsync($"{nameof(SettingsPage)}");
        }
        ///From BaseViewModel

        //


        // protected virtual void OnSettingsEvent(string control, string name)
        // {
        //  SettingsEvent?.Invoke(control, name);
        // }



        //partial void OnSaltReadingChanged(int value)
        //{
        //    Logic.UpdateControl("Salt", "string.Empty");
        //    //SettingsEvent?.Invoke("Salt", "string.Empty");
        //}











        [ObservableProperty]
        string? _error;
        [ObservableProperty]
        private List<string?> errors = new();
        [ObservableProperty]
        private List<string?> prop = new();
        [ObservableProperty]
        private bool isValid = true;
        [ObservableProperty]
        bool _isSaltTargetValid;
        [RelayCommand]
        public void Validate()
        {
            Errors.Clear();
            ValidateAllProperties();
            Errors = GetErrors().Select(e => e.ErrorMessage).ToList();
            Prop = GetErrors().Select(p => p.MemberNames.FirstOrDefault()).ToList();

            IsValid = !HasErrors;

        }
        // With the corrected code:

        private protected double LookUpChlorineType(int value)
        {
            switch (value)
            {
                case 1:
                    return 0.9351;
                case 2:
                    return 0.9352;
                case 3:
                    return 0.9352;
                case 4:
                    return 0.9352;
                case 5:
                    return 0.9352;
                case 6:
                    return 0.978;
                default:
                    return 0;
            }
        }
        private protected double LookUpChlorine(int value)
        {
            switch (value)
            {
                case 0:
                    return 6854.95;
                case 1:
                    return 4149.03;
                case 2:
                    return 3565.44;
                case 3:
                    return 3936.84;
                case 4:
                    return 4828.12;
                case 5:
                    return 5422.41;
                case 6:
                    return 2637.5;
                default:
                    return 7489.4;

            }
        }


        [RelayCommand]
        private protected void ClearSettings()
        {
            Preferences.Clear();
            // LoadSettings();
        }

    }
}
