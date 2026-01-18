//using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolChemicals.Model
{
    // Change base class from ObservableObject to ObservableValidator to support validation attributes
    public partial class AppSettings : ObservableValidator
    {
        public delegate void UpdateSettingsEvent(string control, string name);

        // This event is raised when the settings are updated
        public static event UpdateSettingsEvent? OnSettingsEvent;


        private bool isLoading = true;
        private bool isBusy = false;
        public AppSettings()
        {
            //LoadPreferences();
            // MainLogic.OnSettingsEvent += 
        }

        public void LoadPreferences()
        {
            // Preferences.Clear();
            Volume = Preferences.Get("Volume", 10000);
            Standard = Preferences.Get("MeasureUnits", "US");
            StandardIndex = Preferences.Get("MeasureUnitsIndex", 0);
            AcidPickerItem = Preferences.Get("AcidType", "31.45% - 20° Baumé");
            SaltUpper = Preferences.Get("SaltUpper", 3200);
            SaltLower = Preferences.Get("SaltLower", 2700);
            SaltTarget = Preferences.Get("SaltTarget", 3100);
            FCUpper = Preferences.Get("FCUpper", 4.0);
            FCLower = Preferences.Get("FCLower", 2.0);
            FCTarget = Preferences.Get("FCTarget", 3.0);
            ChlorinePickerItem = Preferences.Get("Chlorine", "Bleach");
            Bleach = Preferences.Get("Bleach", 6);
            FCMeasureWeight = Preferences.Get("FCMeasure", true);
            PHUpper = Preferences.Get("PHUpper", 7.6);
            PHLower = Preferences.Get("PHLower", 7.2);
            PHTarget = Preferences.Get("PHTarget", 7.4);
            PHRaisePickerItem = Preferences.Get("PHRaisePicker", "Soda Ash by Weight");
            PHLowerPickerItem = Preferences.Get("PHLowerPicker", "Muriatic Acid");
            AlkalineUpper = Preferences.Get("AlkalineUpper", 100);
            AlkalineLower = Preferences.Get("AlkalineLower", 80);
            AlkalineTarget = Preferences.Get("AlkalineTarget", 100);
            AlkalineMeasureWeight = Preferences.Get("AlkalineMeasure", true);
            CalciumUpper = Preferences.Get("CalciumUpper", 400);
            CalciumLower = Preferences.Get("CalciumLower", 200);
            CalciumTarget = Preferences.Get("CalciumTarget", 300);
            CalciumRaisePickerItem = Preferences.Get("CalciumRaise", "Calcium Chloride by Weight");
            CYAUpper = Preferences.Get("CYAUpper", 50);
            CYALower = Preferences.Get("CYALower", 30);
            CYATarget = Preferences.Get("CYATarget", 40);
            CYARaisePickerItem = Preferences.Get("CYARaise", "Stabalizer by Weight");
            BorateLower = Preferences.Get("BorateLower", 30);
            BorateUpper = Preferences.Get("BorateUpper", 50);
            BorateTarget = Preferences.Get("BorateTarget", 40);
            BoratePickerItem = Preferences.Get("BorateItem", "Borax");
            BoratePickerIndex = Preferences.Get("BorateIndex", 0);
            BorateMeasureWeight = Preferences.Get("BorateMeasure", true);
            IncludeBorate = Preferences.Get("IncludeBorate", false);

            SizeUnit = Preferences.Get("SizeUnit", "Gallons");
            TempUnit = Preferences.Get("TempUnit", "F");

            FirstTimeRun = Preferences.Get("FirstTimeRun", false);
            WaterTemp = 75;
            isLoading = false;
        }
        [RelayCommand]
        private async void ResetSettings()
        {
            bool answer = await AppShell.Current.DisplayAlert("Alert", "Reset settings to default values?", "Yes", "No");
            if (!answer)
                return;
            Preferences.Clear();
            isLoading = true;
            LoadPreferences();
        }
        [RelayCommand]
        private protected void SaveSettings()
        {
            Preferences.Set("Volume", Units.GetGallons(Volume));
            Preferences.Set("MeasureUnits", Standard);
            Preferences.Set("MeasureUnitsIndex", StandardIndex);
            Preferences.Set("AcidType", AcidPickerItem);
            Preferences.Set("SaltLower", SaltLower);
            Preferences.Set("SaltUpper", SaltUpper);
            Preferences.Set("SaltTarget", SaltTarget);
            Preferences.Set("FCUpper", FCUpper);
            Preferences.Set("FCLower", FCLower);
            Preferences.Set("FCTarget", FCTarget);
            Preferences.Set("Chlorine", ChlorinePickerItem);
            Preferences.Set("Bleach", Bleach);
            Preferences.Set("FCMeasure", FCMeasureWeight);
            Preferences.Set("PHLower", PHLower);
            Preferences.Set("PHUpper", PHUpper);
            Preferences.Set("PHTarget", PHTarget);
            Preferences.Set("PHRaisepicker", PHRaisePickerItem);
            Preferences.Set("PHLowerPicker", PHLowerPickerItem);
            Preferences.Set("AlkalineLower", AlkalineLower);
            Preferences.Set("AlkalineUpper", AlkalineUpper);
            Preferences.Set("AlkalinityTarget", AlkalineTarget);
            Preferences.Set("AlkalineMeasure", AlkalineMeasureWeight);
            Preferences.Set("CalciumLower", CalciumLower);
            Preferences.Set("CalciumUpper", CalciumUpper);
            Preferences.Set("CalciumTarget", CalciumTarget);
            Preferences.Set("CalciumRaise", CalciumRaisePickerItem);
            Preferences.Set("CYALower", CYALower);
            Preferences.Set("CYAUpper", CYAUpper);
            Preferences.Set("CYATarget", CYATarget);
            Preferences.Set("CYARaise", CYARaisePickerItem);
            Preferences.Set("BorateLower", BorateLower);
            Preferences.Set("BorateUpper", BorateUpper);
            Preferences.Set("BorateTarget", BorateTarget);
            Preferences.Set("BorateMeasure", BorateMeasureWeight);

            Preferences.Set("BorateItem", BoratePickerItem);
            Preferences.Set("BorateIndex", BoratePickerIndex);
            Preferences.Set("IncludeBorate", IncludeBorate);

            Preferences.Set("TempUnit", TempUnit);
            Preferences.Set("SizeUnit", SizeUnit);








        }

        // This delegate defines the signature for the event handler
        //private protected delegate void UpdateSettingsEvent(string control, string name);
        // This event is raised when the settings are updated
        //private protected event UpdateSettingsEvent? SettingsEvent;

        [ObservableProperty]
        private int saltUpper;

        [ObservableProperty]
        private int saltLower;
        [ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(SaltRange))]
        [Between(nameof(SaltLower), nameof(SaltUpper), ErrorMessage = "SaltTarget must be between SaltLower and SaltUpper")]

        private int saltTarget;
        [ObservableProperty]
        private double pHUpper;
        [ObservableProperty]
        private double pHLower;
        [ObservableProperty]
        [Between(nameof(PHLower), nameof(PHUpper), ErrorMessage = "pHTarget must be between pHLower and pHUpper!")]
        private double pHTarget;
        [ObservableProperty]
        private double fCUpper;
        [ObservableProperty]
        private double fCLower;
        [ObservableProperty]
        private double fCTarget;
        [ObservableProperty]
        private int alkalineUpper;
        [ObservableProperty]
        private int alkalineLower;
        [ObservableProperty]
        private int alkalineTarget;
        [ObservableProperty]
        private int calciumUpper;
        [ObservableProperty]
        private int calciumLower;

        [ObservableProperty]
        private int calciumTarget;
        [ObservableProperty]
        private int cYAUpper;
        [ObservableProperty]
        private int cYALower;
        [ObservableProperty]
        private int cYATarget;
        [ObservableProperty]
        private int borateUpper;
        [ObservableProperty]
        private int borateLower;
        [ObservableProperty]
        private int borateTarget;
        [ObservableProperty]
        // [NotifyPropertyChangedFor(nameof(Volume))]
        private int volume;
        [ObservableProperty]
        private string? sizeUnit;
        [ObservableProperty]
        private string? tempUnit;
        [ObservableProperty]
        private string? standard;
        [ObservableProperty]
        private int standardIndex;
        [ObservableProperty]
        private string acidPickerItem = "31.45% - 20° Baumé";
        [ObservableProperty]
        private string chlorinePickerItem = "Bleach";
        [ObservableProperty]
        private int bleach;
        [ObservableProperty]
        private string pHRaisePickerItem = "Soda Ash by Weight";
        [ObservableProperty]
        private string pHLowerPickerItem = "Muriatic Acid";
        [ObservableProperty]
        private string calciumRaisePickerItem = "Calcium Chloride by Weight";
        [ObservableProperty]
        private int calciumRaisePickerIndex;
        [ObservableProperty]
        private string? boratePickerItem;
        [ObservableProperty]
        private int boratePickerIndex;
        [ObservableProperty]
        private bool borateMeasureWeight;
        [ObservableProperty]
        private bool includeBorate;
        [ObservableProperty]
        private bool alkalineMeasureWeight;
        [ObservableProperty]
        private bool fCMeasureWeight;
        [ObservableProperty]
        private bool firstTimeRun;
        [ObservableProperty]
        private string cYARaisePickerItem = "Stabalizer by Weight";
        [ObservableProperty]
        private int pHRaisePickerIndex;
        [ObservableProperty]
        private int pHLowerPickerIndex;
        [ObservableProperty]
        private int waterTemp;

        [ObservableProperty]
        int chlorinePickerIndex = 0;
        [ObservableProperty]
        int cYARaisePickerIndex = 0;
        [ObservableProperty]
        string[] chlorineType =
        {
            "Bleach",
            "Trichlor",
            "Dichlor",
            "Cal-hypo 48%",
            "Cal-hypo 53%",
            "Cal-hypo 65%",
            "Cal-hypo 73%",
            "Lithium-hypo",
            "Chlorine gas"
        };
        [ObservableProperty]
        int bleachPickerIndex = 1;
        [ObservableProperty]
        string bleachPickerItem = "6%";
        [ObservableProperty]
        string[] bleachPercent =
        {
            "5%",
            "6%",
            "7%",
            "8%",
            "9%",
            "10%",
            "11%",
            "12%",
            "13%",
            "14%",
            "15%"
        };

        [ObservableProperty]
        string[] acidNames =
        {
            "15.7% - 10° Baumé",
            "28.3% - 18° Baumé",
            "31.45% - 20° Baumé",
            "34.6% - 22° Baumé",
            "14.5%",
            "29%",
        };
        public double[] acidValues =
        {
            2,
            1.11111,
            1,
            .909091,
            2.16897,
            1.08448
        };
        [ObservableProperty]
        int acidPickerIndex = 2;

        public double[,] chlorineValues =
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

        public double[] borateValues =
        {
            849.271,
            1309.52,
            1111.69
        };



        //partial void OnSaltTargetChanged(int value)
        //{
        //    throw new NotImplementedException();
        //}



        partial void OnVolumeChanged(int value)
        {
            if (!isLoading && !isBusy) OnSettingsEvent?.Invoke("Volume", "string.Empty");
        }
        partial void OnAcidPickerItemChanged(string value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("Acid", "string.Empty");
        }
        partial void OnFCTargetChanged(double value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("Chlorine", "string.Empty");
        }

        partial void OnPHTargetChanged(double value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("PHAdjustment", "string.Empty");
        }

        partial void OnAlkalineTargetChanged(int value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("Alkaline", "string.Empty");
        }

        partial void OnCalciumTargetChanged(int value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("Calcium", "string.Empty");
        }

        partial void OnCYATargetChanged(int value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("CYA", "string.Empty");
        }

        partial void OnBorateTargetChanged(int value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("Borate", "string.Empty");
        }

        partial void OnChlorinePickerItemChanged(string value)
        {
            // This method is called when the ChlorinePickerSelection property changes
            // You can add any additional logic here if needed
            // For example, you might want to log the change or perform some validation
            if (!isLoading) OnSettingsEvent?.Invoke("Chlorine", "string.Empty");
        }

        partial void OnIncludeBorateChanged(bool value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("Borate", value.ToString());
        }
        partial void OnBoratePickerItemChanged(string? value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("Borate", "string.Empty");
        }

        partial void OnCYARaisePickerItemChanged(string value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("CYA", "string.Empty");
        }

        partial void OnCalciumRaisePickerItemChanged(string value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("Calcium", "string.Empty");
        }
        partial void OnPHRaisePickerItemChanged(string value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("pHAdjustment", "string.Empty");
        }

        partial void OnPHLowerPickerItemChanged(string value)
        {
            if (!isLoading) OnSettingsEvent?.Invoke("pHAdjustment", "string.Empty");

        }
        partial void OnBleachPickerItemChanged(string value)
        {
            // This method is called when the BleachPickerSelectedItem property changes
            // You can add any additional logic here if needed
            // For example, you might want to log the change or perform some validation
            //SettingsEvent?.Invoke("Bleach", "string.Empty");
            Bleach = int.Parse(value.TrimEnd('%'));
            // SettingsEvent?.Invoke("Bleach", "string.Empty");
        }
        partial void OnStandardIndexChanged(int oldValue, int newValue)
        {
            // Handle the change in UnitPickerIndex here if needed
            // For example, you can update some properties or perform actions based on the selected index
            // This method is automatically generated by the ObservableProperty attribute
            //oldUnit = oldValue;
            //measureUnit = newValue;
            //Units.CurrentModel = (Units.Model)newValue;

            Standard = Enum.GetName(typeof(Units.Model), newValue) ?? string.Empty;
            SizeUnit = Enum.GetName(typeof(Units.SizeUnits), newValue) ?? string.Empty;
            TempUnit = Enum.GetName(typeof(Units.Temperatures), newValue) ?? string.Empty;
            if (!isLoading)
            {
                switch (newValue)
                {
                    case 0: // U.S.
                        if (oldValue == 1) // If previously Metric
                            Volume = Units.MetricToUS(Volume);
                        else
                            Volume = Units.ImperialToUS(Volume);

                        if (oldValue == 1) // If previously Metric
                            WaterTemp = Units.ConvertTempurature(WaterTemp);
                        //WaterTemp = (int)(WaterTemp * 9 / 5 + .5) + 32; // Convert Celsius to Fahrenheit
                        break;
                    case 1: // Metric
                        if (oldValue == 0) // If previously Metric
                            Volume = Units.USToMetric(Volume);
                        else
                            Volume = Units.ImperialToMetric(Volume);

                        if (oldValue != 1) // If previously Metric
                            WaterTemp = Units.ConvertTempurature(WaterTemp);
                        break;
                    default:
                        if (oldValue == 0) // If previously Metric
                            Volume = Units.USToImperial(Volume);
                        else
                            Volume = Units.MetricToImperial(Volume);

                        if (oldValue == 1) // If previously Metric
                            WaterTemp = Units.ConvertTempurature(WaterTemp);
                        break;
                }
                // OnSettingsEvent?.Invoke("All", "string.Empty");
            }
            //            UpdateAll();
        }

    }
}
