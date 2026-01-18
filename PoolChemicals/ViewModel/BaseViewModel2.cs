

//using CommunityToolkit.Mvvm.ComponentModel;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;

//using Android.Test.Suitebuilder;
using PoolChemicals.Model;
using PoolChemicals.Validations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PoolChemicals.ViewModel
{

    public partial class BaseViewModel : ObservableValidator

    {
        public string AppPackageName => AppInfo.PackageName;
        public string AppName => AppInfo.Name;
        public string AppVersion => AppInfo.VersionString;
        public string AppBuild => AppInfo.BuildString;
        public bool FirstTimeRun = false;
        public static Student student = new("Jerry", "Smith");
        //
        //Settings Section
        //
        //   public ObservableCollection<TestInt> Tests { get; } = new();

        [ObservableProperty]
        public AppSettings settings = new();



        [ObservableProperty]
        private TestInt saltTest = new()
        {
            Name = "Salt",
            Lower = 2700,
            Upper = 3200,
            Target = 3100,
            Reading = 0,
            Results = ""
        };


        [ObservableProperty]
        public bool isValidataionValid = true;
        [ObservableProperty]
        private protected bool showInRange;

        //[ObservableProperty]
        //private protected int volume;
        //[ObservableProperty]
        //private protected int bleach;
        [ObservableProperty]
        private protected int bleachPickerIndex=1;
        [ObservableProperty]
        private protected string bleachPickerItem="6%";
        [ObservableProperty]
        private protected bool bleachVisible = true;
        [ObservableProperty]
        protected int chlorinePickerIndex;
        //[ObservableProperty]
        //private protected string chlorinePickerItem = "Bleach";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Settings.Volume))]
        protected double unitsMultiplyer;

        /*
        [ObservableProperty]
        private protected int unitPickerIndex;
        [ObservableProperty]
        private protected string? unitPickerItem;

        [ObservableProperty]
        private protected int boratePickerIndex;
        [ObservableProperty]
        private protected string? boratePickerItem;
        [ObservableProperty]
        private protected bool includeBorate;
        [ObservableProperty]
        private protected bool borateMeasureWeight;
        [ObservableProperty]
        private protected bool alkalineMeasureWeight;
        [ObservableProperty]
        private protected bool fCMeasureWeight;
        */
        [ObservableProperty]
        private protected int acidPickerIndex =2;
        //[ObservableProperty]
        //private protected string acidPickerItem = "31.45% - 20° Baumé";
        
        [ObservableProperty]
        private protected int pHLowerPickerIndex = 0;
        //[ObservableProperty]
        //private protected string pHLowerPickerItem="Muriatic Acid";
        [ObservableProperty]
        private protected int pHRaisePickerIndex=0;
        //[ObservableProperty]
        //private protected string pHRaisePickerItem="Soda Ash by Weight";
        //
        [ObservableProperty]
        int saltReading;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(SaltRange))]
        //[Between(nameof(SaltLower), nameof(SaltUpper), ErrorMessage = "SaltTarget must be between SaltLower and SaltUpper")]
        //private protected int saltTarget;
        //[ObservableProperty]        
        //[NotifyPropertyChangedFor(nameof(SaltRange))]
        //private protected int saltLower;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(SaltRange))]
        //private protected int saltUpper;
        //

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(PHRange))]
        //private protected double pHLower;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(PHRange))]
        //private protected double pHUpper;
        [ObservableProperty]
        private protected double pHReading;
        //[ObservableProperty]
        //[Between(nameof(PHLower),nameof(PHUpper),ErrorMessage = "pHTarget must be between pHLower and pHUpper!")]
        //private protected double pHTarget;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(AlkalineRange))]
        //private protected int alkalineLower;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(AlkalineRange))]
        //private protected int alkalineUpper;
        [ObservableProperty]
        private protected int alkalineReading;
        //[ObservableProperty]
        //private protected int alkalineTarget;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(CalciumRange))]
        //private protected int calciumLower;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(CalciumRange))]
        //private protected int calciumUpper;
        //[ObservableProperty]
        //private protected int calciumTarget;
        [ObservableProperty]
        private protected int calciumReading;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(CYARange))]
        //private protected int cYALower;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(CYARange))]
        //private protected int cYAUpper;
        //[ObservableProperty]
        //private protected int cYATarget;
        [ObservableProperty]
        private protected int cYAReading;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(BorateRange))]
        //private protected int borateLower;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(BorateRange))]
        //private protected int borateUpper;
        //[ObservableProperty]
        //private protected int borateTarget;
        [ObservableProperty]
        private protected int borateReading;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(FCRange))]
        //private protected double fCUpper;
        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(FCRange))]
        //private protected double fCLower;
        //[ObservableProperty]
        //private protected double fCTarget;
        [ObservableProperty]
        private protected double fCReading;
        [ObservableProperty]
        private protected bool fCMeasureIsVisible =false;
        //[ObservableProperty]
        //private protected int calciumRaisePickerIndex = 0;
        //[ObservableProperty]
        //private protected string calciumRaisePickerItem = "Calcium Chloride by Weight";
        [ObservableProperty]
        private protected int cYARaisePickerIndex = 0;
        //[ObservableProperty]
        //private protected string cYARaisePickerItem = "Stabalizer by Weight";


        [ObservableProperty]
        private protected int waterTemp = 70;


        private protected int oldUnit;
        private protected int measureUnit;
        //[ObservableProperty]
        //private protected string? sizeUnit;

        //[ObservableProperty]
        //private protected string? tempUnit;

        private protected string fcMeasure = "Weight";
        private protected string alkalineMeasure = "Weight";
        private protected string borateMeasure = "Weight";
        public string SaltRange => $"Range\r\n{Settings.SaltLower} - {Settings.SaltUpper}";
        public string FCRange => $"Range\r\n{Settings.FCLower} - {Settings.FCUpper}";
        public string PHRange => $"Range\r\n{Settings.PHLower} - {Settings.PHUpper}";
        public string AlkalineRange => $"Range\r\n{Settings.AlkalineLower} - {Settings.AlkalineUpper}";
        public string CalciumRange => $"Range\r\n{Settings.CalciumLower} - {Settings.CalciumUpper}";
        public string CYARange => $"Range\r\n{Settings.CYALower} - {Settings.CYAUpper}";
        public string BorateRange => $"Range\r\n{Settings.BorateLower} - {Settings.BorateUpper}";

        private protected double[,] chlorineValues =
        {
            { 0, 0 },
            { 6854.95, 0 },
            { 4149.03, 0.9351 },
            { 3565.44, 0.9352 },
            { 3936.84, 0.9352 },
            { 4828.12, 0.9352 },
            { 5422.41, 0.9352 },
            { 2637.5, 0.978 },
            { 7489.4, 0 }
        };

        private protected double[] borateValues =
        {
            849.271,
            1309.52,
            1111.69
        };

        private protected double[] acidValues =
        {
            2,
            1.11111,
            1,
            .909091,
            2.16897,
            1.08448
        };

        private protected BaseViewModel()
        { 
            // For example, you can set default values for properties or load data from a database
            // This is just a placeholder for any additional logic you want to implement
            _error = string.Empty;
            LoadSettings();
           // FirstTimeRunCheck();
            SaltTest.Lower = Settings.SaltLower;
            SaltTest.Reading = SaltReading+1000;

          //  Tests.Add(SaltTest);
        }

        //private void FirstTimeRunCheck()
        //{
        //    if (FirstTimeRun == false)
        //    {
        //        FirstTimeRun = true;
        //        Preferences.Set("FirstTimeRun", true);
        //        SaveSettings();
        //    }
        //}

        // Simplified collection initialization for `chlorineValues` and `borateValues` to address IDE0300 diagnostic code.

        [RelayCommand]
        private protected void RadioButtonChanged(string value)
        {
            string control;
            int index = value.IndexOf("-");

            control = value[..index];
            switch (control)
            {
                case "Alkaline":
                    
                    alkalineMeasure = value[(index + 1)..];
                    SettingsEvent?.Invoke("Alkaline","");
                    break;
                case "Borate":
                    borateMeasure = value[(index + 1)..];
                    SettingsEvent?.Invoke("Borate", "");
                    break;
                case "FC":
                    fcMeasure = value[(index + 1)..];
                    SettingsEvent?.Invoke("FC", "");
                    break;
            }

        }
        //
        [ObservableProperty]
        private protected string[] acidNames =
        {
            "15.7% - 10° Baumé",
            "28.3% - 18° Baumé",
            "31.45% - 20° Baumé",
            "34.6% - 22° Baumé",
            "14.5%",
            "29%",
        };

        //        [ObservableProperty]
        //       public static string? saltRange;
        //  [ObservableProperty]
        //  public static string? fCRange;
        //[ObservableProperty]
        //public static string? pHRange;
        //[ObservableProperty]
        //public static string? alkalineRange;
        //[ObservableProperty]
        //public static string? calciumRange;
        //[ObservableProperty]
        //public static string? cYARange;

        // This delegate defines the signature for the event handler
        private protected delegate void UpdateSettingsEvent(string control, string name);
        // This event is raised when the settings are updated
        private protected event UpdateSettingsEvent? SettingsEvent;

        //private protected async Task DisplayAlert(string title, string message, string cancel)
        //{
        //    // This method can be used to display an alert dialog
        //    // You can implement the logic to show an alert in your application
        //    // For example, using a platform-specific implementation or a library
        //    await Shell.Current.DisplayAlert("Alert", "You have been alerted", "OK");
        //}


        //12-22-25
        //partial void OnAcidPickerItemChanged(string value)
        //{
        //    // This method is called when the AcidPickerIndex property changes
        //    // You can add any additional logic here if needed
        //    // For example, you might want to log the change or perform some validation
        //    SettingsEvent?.Invoke("Acid", "string.Empty");            
        //}

        //partial void OnSaltTargetChanged(int value)
        //{
        //    SettingsEvent?.Invoke("Salt", "string.Empty");
        //}

        //partial void OnFCTargetChanged(double value)
        //{
        //    SettingsEvent?.Invoke("Chlorine", "string.Empty");
        //}

        //partial void OnPHTargetChanged(double value)
        //{
        //    SettingsEvent?.Invoke("PHAdjustment", "string.Empty");
        //}

        //partial void OnAlkalineTargetChanged(int value)
        //{
        //    SettingsEvent?.Invoke("Alkaline", "string.Empty");
        //}

        //partial void OnCalciumTargetChanged(int value)
        //{
        //    SettingsEvent?.Invoke("Calcium", "string.Empty");
        //}

        //partial void OnCYATargetChanged(int value)
        //{
        //    SettingsEvent?.Invoke("CYA", "string.Empty");
        //}

        //partial void OnBorateTargetChanged(int value)
        //{
        //    SettingsEvent?.Invoke("Borate", "string.Empty");
        //}
        //end 12-22-25

        partial void OnShowInRangeChanged(bool oldValue, bool newValue)
        {
            SettingsEvent?.Invoke("InRange", "string.Empty");
        }

        //12-22-25
        //        partial void OnBleachPickerItemChanged(string value)
        //        {
        //            // This method is called when the BleachPickerSelectedItem property changes
        //            // You can add any additional logic here if needed
        //            // For example, you might want to log the change or perform some validation
        //            //SettingsEvent?.Invoke("Bleach", "string.Empty");
        //            Bleach = int.Parse(value.TrimEnd('%'));
        //            SettingsEvent?.Invoke("Bleach", "string.Empty");
        //        }

        //        partial void OnVolumeChanged(int value)
        //        {
        //            // This method is called when the Volume property changes
        //            // You can add any additional logic here if needed
        //            // For example, you might want to log the change or perform some validation

        //            SettingsEvent?.Invoke("Volume", "string.Empty");
        //        }


        //        partial void OnChlorinePickerItemChanged(string value)
        //        {
        //            // This method is called when the ChlorinePickerSelection property changes
        //            // You can add any additional logic here if needed
        //            // For example, you might want to log the change or perform some validation
        //            SettingsEvent?.Invoke("Chlorine", "string.Empty");
        //        }
        //end 12-22-25
        partial void OnChlorinePickerIndexChanged(int value)
        {
            switch (value)
            {
                case 0:
                    BleachVisible = true;
                    FCMeasureIsVisible = false;
                    break;
                case 1:
                    BleachVisible = false;
                    FCMeasureIsVisible = false;
                    fcMeasure = "Weight";
                    break;
                default:
                    BleachVisible = false;
                    FCMeasureIsVisible = true;
                    break;
            }
        }
        partial void OnUnitPickerIndexChanged(int oldValue, int newValue)
        {
            // Handle the change in UnitPickerIndex here if needed
            // For example, you can update some properties or perform actions based on the selected index
            // This method is automatically generated by the ObservableProperty attribute

            oldUnit = oldValue;
            measureUnit = newValue;
            switch (newValue)
            {
                case 0: // U.S.
                    //UnitsMultiplyer = 1;
                    UnitPickerItem = "U.S.";
                    SizeUnit = "gallons";
                    TempUnit = "F";
                    if ( newValue == 2)
                    {
                        if (oldValue == 0)
                            Volume = (int)(Volume * 0.832674 + 0.5); // Convert to gallons
                        else if (oldValue == 1)
                            Volume = (int)(Volume * 0.219969 + 0.5); // Convert to gallons
                    }
                    else
                    {
                        if (oldValue == 1) // If previously Metric
                            Volume = (int)(Volume * 0.264172 + 0.5); // Convert to gallons
                        else if (oldValue == 2) // If previously Imperial
                            Volume = (int)(Volume * 1.20095 + 0.5); // Convert to gallons
                    }
                    if (oldValue == 1) // If previously Metric
                        WaterTemp = (int)(waterTemp * 9 / 5 + .5) + 32; // Convert Celsius to Fahrenheit
                    break;
                case 1: // Metric
                   // UnitsMultiplyer = 0.0295735; // Convert to liters
                    UnitPickerItem = "Metric";
                    SizeUnit= "liters";
                    TempUnit = "C";
                    if (oldValue == 0) // If previously U.S.
                        Volume = (int)(Volume * 3.78541 + 0.5);
                    else if (oldValue == 2) // If previously Imperial
                        Volume = (int)(Volume * 4.54609 + 0.5);
                    if (oldUnit != 1)
                        WaterTemp=(int)((waterTemp - 32) * 5 / 9 + .5); // Convert Fahrenheit to Celsius
                    break;
                default:
                    //UnitsMultiplyer = 1; // Default to U.S. if an unknown index is selected
                    UnitPickerItem = "Imperial";
                    SizeUnit = "gallons";
                    TempUnit = "F";
                    if (oldValue == 0) // If previously U.S.
                        Volume = (int)(Volume * 0.832674 + 0.5);
                    else if (oldValue == 1) // If previously Metric
                        Volume = (int)(Volume * .219969 + 0.5);
                    if (oldUnit == 1)
                        WaterTemp = (int)(waterTemp * 9 / 5 + .5) + 32; // Convert Fahrenheit to Celsius
                    break;
            }
            UpdateAll();
        }

        partial void OnIncludeBorateChanged(bool value)
        {            
            SettingsEvent?.Invoke("Borate", value.ToString());
        }
        partial void OnBoratePickerItemChanged(string? value)
        {
             SettingsEvent?.Invoke("Borate", "string.Empty");
        }

        partial void OnCYARaisePickerItemChanged(string value)
        {
            SettingsEvent?.Invoke("CYA", "string.Empty");
        }

        partial void OnCalciumRaisePickerItemChanged(string value)
        {
            SettingsEvent?.Invoke("Calcium", "string.Empty");
        }
        partial void OnPHRaisePickerItemChanged(string value)
        {
            SettingsEvent?.Invoke("pHAdjustment", "string.Empty");
        }

        partial void OnPHLowerPickerItemChanged(string value)
        {
            SettingsEvent?.Invoke("pHAdjustment", "string.Empty");
        }

        private protected void UpdateAll()
        {
            // This method can be used to update all related properties or perform actions when the unit picker index changes
            // For example, you might want to recalculate some values based on the new unit selection
            // This is just a placeholder for any additional logic you want to implement
            SettingsEvent?.Invoke("All", "string.Empty");
        }
        [ObservableProperty]
        string _error;
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

            //            return IsValid;
            //       }


            //       bool isValidText = ValidateTextName();


            //bool temp;
            //// Fix for CS1526: Added {} to properly initialize the IEnumerable<string> instance.
            //IEnumerable<string> propNames = new List<string>();
            //List<string> errText = new List<string>();
            //if (HasErrors)
            //{
            //    Error = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
            //    errText = [.. GetErrors().Select(e => e.ErrorMessage)];
            //}
            //else
            //    Error = string.Empty;
            //propNames = (IEnumerable<string>)GetErrors().SelectMany(p => p.MemberNames);


            // Fix for CS0103: Replaced 'MemberNames' with the correct logic to retrieve member names from validation errors.

          //  var errors = GetErrors()
            //    .Where(e => e.MemberNames.Any()) // Ensure MemberNames is not empty
            //    .SelectMany(e => e.MemberNames)
            //    .Distinct();
            //string TextError = string.Empty;

            //TextError = GetErrors()
            //    .Where(e => e.MemberNames.Any()) // Ensure MemberNames is not empty
            //    .ToDictionary(k => k.MemberNames.First(), v => v.ErrorMessage) ?? new Dictionary<string, string?>()
            //    .TryGetValue(nameof(Text), out string? error);

            // IsSaltTargetValid = GetErrors(nameof(SaltTarget)).Any();

            //IsSaltTargetValid = (GetErrors(nameof(SaltTarget))
            //    .Where(e => e.MemberNames.Any()) // Ensure MemberNames is not empty
            //    .ToDictionary(k => k.MemberNames.First(), v => v.ErrorMessage) ?? new Dictionary<string, string?>())
            //    .TryGetValue(nameof(SaltTarget), out var error2);
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

        //conversion routines
        private protected int GetGallons(int value = 0)
        {
            if (value == 0)
                value = Settings.Volume;
            if (Settings.UnitPickerIndex == 1)
                return (int)(value / 3.78541 + .5) ; // Explicit cast added to fix CS0266  
            else if (Settings.UnitPickerIndex == 2)
                return (int)(value * 1.20095 + .5); // Explicit cast added to fix CS0266  
            else
                return value;
        }
        private protected string ConvertWeight(double oz)
        {
            double results;
            // Convert ounces to the target unit
            if (Settings.UnitPickerIndex == 1)
            {
                results = oz * 28.3495; // Convert to grams
                if (results >= 1000)
                    return ConvertLbskg(results);
                else
                    return Math.Round(results) + " g";
            }
            if (oz < 10)
                return Math.Round(oz,1) + " oz";

            return ConvertToLbsCups(oz);
        }

        private protected string ConvertLbskg(double value)
        {
            // Convert pounds to the target unit
            if (Settings.UnitPickerIndex == 1)
                return Math.Round(value/1000,1) + " kg";
            else
                return  ConvertToLbsCups(value, true);
            //int lbs;
            //int oz;
            //int divisor = 16;

            //string myType = " lbs";
            //if (value < divisor)
            //{
            //    oz = (int)value;
            //    return oz.ToString() + " oz";
            //}
            //lbs = (int)value / divisor;
            //oz = (int)Math.Round(value % divisor, 0);
            //if (lbs > 0)
            //    results = lbs + myType;
            //if (oz > 0 && lbs < 10)
            //    results += " " + oz + " oz";
            //return results;
        }


        private protected string ConvertVolume(double value)
        {
            // Convert ounces to the target unit
            if (Settings.UnitPickerIndex == 1)
            {
                value *= 29.5735;
                if (value >= 1000)
                    return Math.Round(value / 1000,1) + " L";
                else
                    return Math.Round(value += .5) + " mL";
            }
            else if (Settings.UnitPickerIndex == 2)
                value *= 1.04084;
            if (value < 10)
                return Math.Round(value + .05) + "." + Math.Round(value * 10 + .5) % 10 + " oz";
            return ConvertToLbsCups(value,true);
        }

        private protected string ConvertToLbsCups(double value,bool toCups=false)
        {
            string results = "";
            int lbscups;
            int divisor = 16;
            int oz;
            string myType = " lbs";

            if (toCups)
            {
                divisor = 8;
                myType = " cups";
            }
            if (value < divisor)
            {
                oz = (int)value;
                return oz.ToString() + " oz";
            }
            lbscups = (int)value / divisor;
            oz = (int)Math.Round(value % divisor, 0);
            if (lbscups > 0)
                results = lbscups + myType;
            if (oz > 0 && lbscups < 10)
                results += " " + oz + " oz";
            return results;
        }

        private protected string ConvertGallons(double value)
        {
            // Convert gallons to the target unit
            if (Settings.UnitPickerIndex == 1)
                return Math.Round(value * 3.78541,0) + " Liters";
            else if (Settings.UnitPickerIndex == 2)
                return Math.Round(value * .832674) + " Gallons";
            return value + " Gallons";
        }

        private protected double ConvertFluids(double value, string toUnit)
        {
            double result = 0; 
            // Convert ounces to the target unit
            switch (toUnit)
            {
                case "oz":
                    return value;
                case "pt":
                    return value / 16; // Convert oz to pt
                case "qt":
                    return value / 32; // Convert oz to qt
                case "gal":
                    return value / 128; // Convert oz to gal
                case "L":
                    return value / 33.814; // Convert oz to L
            }
            return result; // Default return if no conversion is needed
        }



        private protected double ConvertGallons_old(double value, string toUnit)
        {
            
            double result = 0;
            // Convert gallons to the target unit
            switch (toUnit)
            {
                case "oz":
                    return value * 128; // Convert gal to oz
                case "pt":
                    return value * 8; // Convert gal to pt
                case "qt":
                    return value * 4; // Convert gal to qt
                case "gal":
                    return value / 1; // No conversion needed
                case "L":
                    return value * 3.78541; // Convert gal to L
                default:
                    break;
            }
            return result; // Default return if no conversion is needed
        }


        //partial void OnSaltRangeChanged(string? oldValue, string? newValue)
        //{
        //    SetProperty(ref saltRange, newValue);
        //}


        //partial void OnSaltUpperChanged(int oldValue, int newValue)
        //{
        //    if (newValue <= SaltLower)
        //    {
        //        SaltUpper = oldValue;
        //    }
        //    else if (newValue < SaltTarget)
        //    {
        //        SaltTarget = newValue;
        //    }

        //}




        [RelayCommand]
        private protected void ClearSettings()
        {
            Preferences.Clear();
            LoadSettings();
        }

        [RelayCommand]
        private protected void LoadSettings()
        {

            Settings.SaltUpper = Preferences.Get("SaltUpper", 3200);
            Settings.SaltLower = Preferences.Get("SaltLower", 2700);
            Settings.SaltTarget = Preferences.Get("SaltTarget", 3100);
            Settings.PHUpper = Preferences.Get("PHUpper", 7.6);
            Settings.PHLower = Preferences.Get("PHLower", 7.2);
            Settings.PHTarget = Preferences.Get("PHTarget", 7.4);
            Settings.AlkalineUpper = Preferences.Get("AlkalineUpper", 100);
            Settings.AlkalineLower = Preferences.Get("AlkalineLower", 80);
            Settings.AlkalineTarget = Preferences.Get("AlkalineTarget", 100);
            Settings.CalciumUpper = Preferences.Get("CalciumUpper", 400);
            Settings.CalciumLower = Preferences.Get("CalciumLower", 200);
            Settings.CalciumTarget = Preferences.Get("CalciumTarget", 300);
            Settings.CYAUpper = Preferences.Get("CYAUpper", 50);
            Settings.CYALower = Preferences.Get("CYALower", 30);
            Settings.CYATarget = Preferences.Get("CYATarget", 40);
            Settings.BorateUpper = Preferences.Get("BorateUpper", 50);
            Settings.BorateLower = Preferences.Get("BorateLower", 30);
            Settings.BorateTarget = Preferences.Get("BorateTarget", 40);
            Settings.FCUpper = Preferences.Get("FCUpper", 4.0);
            Settings.FCLower = Preferences.Get("FCLower", 2.0);
            Settings.FCTarget = Preferences.Get("FCTarget", 3.0);
            Settings.Volume = Preferences.Get("Volume", 10000);

            Settings.SizeUnit = Preferences.Get("SizeUnit", "gallons");
            Settings.TempUnit = Preferences.Get("TempUnit", "F");
            Settings.UnitPickerItem = Preferences.Get("MeasureUnits", "U.S.");
            Settings.UnitPickerIndex = Preferences.Get("MeasureUnitsIndex", 0);
            Settings.AcidPickerItem = Preferences.Get("AcidType", "31.45% - 20° Baumé");
            Settings.ChlorinePickerItem = Preferences.Get("Chlorine", "Bleach");
            Settings.Bleach = Preferences.Get("Bleach", 6);
            Settings.PHRaisePickerItem = Preferences.Get("PHRaisePicker", "Soda Ash by Weight");
            Settings.PHLowerPickerItem = Preferences.Get("PHLowerPicker", "Muriatic Acid");
            Settings.CalciumRaisePickerItem = Preferences.Get("CalciumRaise", "Calcium Chloride by Weight");
            Settings.CYARaisePickerItem = Preferences.Get("CYARaise", "Stabalizer by Weight");
            Settings.BoratePickerItem = Preferences.Get("BorateItem", "Borax");
            Settings.BoratePickerIndex = Preferences.Get("BorateIndex", 0);
            Settings.BorateMeasureWeight = Preferences.Get("BorateMeasure", true);
            Settings.IncludeBorate = Preferences.Get("IncludeBorate", false);
            Settings.AlkalineMeasureWeight = Preferences.Get("AlkalineMeasure", true);
            Settings.FCMeasureWeight = Preferences.Get("FCMeasure", true);
            Settings.FirstTimeRun = Preferences.Get("FirstTimeRun", false);


            //SaltUpper = Preferences.Get("SaltUpper", 3200);
            //SaltLower = Preferences.Get("SaltLower", 2700);
            //SaltTarget = Preferences.Get("SaltTarget", 3100);
            //PHUpper = Preferences.Get("PHUpper", 7.6);
            //PHLower = Preferences.Get("PHLower", 7.2);
            //PHTarget = Preferences.Get("PHTarget", 7.4);
            //AlkalineUpper = Preferences.Get("AlkalineUpper", 100);
            //AlkalineLower = Preferences.Get("AlkalineLower", 80);
            //AlkalineTarget = Preferences.Get("AlkalineTarget", 100);
            //CalciumUpper = Preferences.Get("CalciumUpper", 400);
            //CalciumLower = Preferences.Get("CalciumLower", 200);
            //CalciumTarget = Preferences.Get("CalciumTarget", 300);
            //CYAUpper = Preferences.Get("CYAUpper", 50);
            //CYALower = Preferences.Get("CYALower", 30);
            //CYATarget = Preferences.Get("CYATarget", 40);
            //BorateUpper = Preferences.Get("BorateUpper", 50);
            //BorateLower = Preferences.Get("BorateLower", 30);
            //BorateTarget = Preferences.Get("BorateTarget", 40);
            //FCUpper = Preferences.Get("FCUpper", 4.0);
            //FCLower = Preferences.Get("FCLower", 2.0);
            //FCTarget = Preferences.Get("FCTarget", 3.0);
            //Volume = Preferences.Get("Volume", 10000);

            //SizeUnit = Preferences.Get("SizeUnit", "gallons");
            //TempUnit = Preferences.Get("TempUnit", "F");
            //UnitPickerItem = Preferences.Get("MeasureUnits", "U.S.");
            //UnitPickerIndex = Preferences.Get("MeasureUnitsIndex", 0);
            //AcidPickerItem = Preferences.Get("AcidType", "31.45% - 20° Baumé");
            //ChlorinePickerItem = Preferences.Get("Chlorine","Bleach");
            //Bleach = Preferences.Get("Bleach", 6);
            //PHRaisePickerItem = Preferences.Get("PHRaisePicker", "Soda Ash by Weight");
            //PHLowerPickerItem = Preferences.Get("PHLowerPicker", "Muriatic Acid");
            //CalciumRaisePickerItem = Preferences.Get("CalciumRaise", "Calcium Chloride by Weight");
            //CYARaisePickerItem = Preferences.Get("CYARaise", "Stabalizer by Weight");
            //BoratePickerItem = Preferences.Get("BorateItem", "Borax");
            //BoratePickerIndex = Preferences.Get("BorateIndex", 0);
            //BorateMeasureWeight = Preferences.Get("BorateMeasure", true);
            //IncludeBorate = Preferences.Get("IncludeBorate", false);
            //AlkalineMeasureWeight = Preferences.Get("AlkalineMeasure", true);
            //FCMeasureWeight = Preferences.Get("FCMeasure", true);
            //FirstTimeRun = Preferences.Get("FirstTimeRun", false);
        }


        [RelayCommand]
        private protected void SaveSettings()
        {
            Preferences.Set("SaltLower", Settings.SaltLower);
            Preferences.Set("SaltUpper", Settings.SaltUpper);
            Preferences.Set("SaltTarget", Settings.SaltTarget);
            Preferences.Set("PHLower", Settings.PHLower);
            Preferences.Set("PHUpper", Settings.PHUpper);
            Preferences.Set("PHTarget", Settings.PHTarget);
            Preferences.Set("AlkalineLower", Settings.AlkalineLower);
            Preferences.Set("AlkalineUpper", Settings.AlkalineUpper);
            Preferences.Set("AlkalinityTarget", Settings.AlkalineTarget);
            Preferences.Set("CalciumLower", Settings.CalciumLower);
            Preferences.Set("CalciumUpper", Settings.CalciumUpper);
            Preferences.Set("CalciumTarget", Settings.CalciumTarget);
            Preferences.Set("CYALower", Settings.CYALower);
            Preferences.Set("CYAUpper", Settings.CYAUpper);
            Preferences.Set("CYATarget", Settings.CYATarget);
            Preferences.Set("FCUpper", Settings.FCUpper);
            Preferences.Set("FCLower", Settings.FCLower);
            Preferences.Set("FCTarget", Settings.FCTarget);
            Preferences.Set("Volume", GetGallons());

            Preferences.Set("SizeUnit", Settings.SizeUnit);
            Preferences.Set("TempUnit", Settings.TempUnit);
            Preferences.Set("MeasureUnits", Settings.UnitPickerItem);
            Preferences.Set("MeasureUnitsIndex", Settings.UnitPickerIndex);
            Preferences.Set("AcidType", Settings.AcidPickerItem);
            Preferences.Set("Chlorine", Settings.ChlorinePickerItem);
            Preferences.Set("Bleach", Settings.Bleach);
            Preferences.Set("PHRaisepicker", Settings.PHRaisePickerItem);
            Preferences.Set("PHLowerPicker", Settings.PHLowerPickerItem);
            Preferences.Set("CalciumRaise", Settings.CalciumRaisePickerItem);
            Preferences.Set("CYARaise", Settings.CYARaisePickerItem);
            Preferences.Set("BorateItem", Settings.BoratePickerItem);
            Preferences.Set("BorateIndex", Settings.BoratePickerIndex);
            Preferences.Set("BorateMeasure", Settings.BorateMeasureWeight);
            Preferences.Set("IncludeBorate", Settings.IncludeBorate);
            Preferences.Set("AlkalineMeasure", Settings.AlkalineMeasureWeight);
            Preferences.Set("FCMeasure", Settings.FCMeasureWeight);
        }
    }
}
