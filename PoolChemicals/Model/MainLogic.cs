using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoolChemicals.Model;

namespace PoolChemicals.Model
{
    public partial class MainLogic : ObservableValidator //BindableObject
    {

        //public delegate void UpdateSettingsEvent(string control, string name);

        // This event is raised when the settings are updated
        //public static event UpdateSettingsEvent? OnSettingsEvent;
        private Database db = new Database();
        public static LogTable logTable = new LogTable();
        public string? Note;
        [ObservableProperty]
        public string fCMeasure = "Weight";
        [ObservableProperty]
        public string alkalineMeasure = "Weight";
        [ObservableProperty]
        public string borateMeasure = "Weight";
        #region Property Salt
        //Salt
        [ObservableProperty]
        string? saltResults;

        [ObservableProperty]
        int saltReading;
        [ObservableProperty]
        int saltColumnSpan = 1;
        #endregion

        #region Property FC
        [ObservableProperty]
        double fCReading;
        [ObservableProperty]
        bool fCIsVisible;
        [ObservableProperty]
        string? fCResults;
        #endregion

        #region Property pH
        [ObservableProperty]
        double pHReading;
        [ObservableProperty]
        string? pHPickerItem;
        [ObservableProperty]
        string? pHAdjustment;
        //[ObservableProperty]
        //int pHLowerPickerIndex = 0;
        //[ObservableProperty]
        //int pHRaisePickerIndex = 0;

       // double sodaAshWeight;
       // double sodaAshVolume;
       // double boraxWeight;
       // double boraxVolume;


        #endregion

        #region Property Alkaline
        //Alkalinity
        [ObservableProperty]
        int alkalineReading;
        [ObservableProperty]
        string? bakingSodaAdd;
        [ObservableProperty]
        string? alkalineNote;
        #endregion

        #region Property Calcium
        [ObservableProperty]
        int calciumReading;
        [ObservableProperty]
        string? calciumResults;
        [ObservableProperty]
        int calciumResultsSpan = 1;
        [ObservableProperty]
        Color calciumWarning = Colors.White;
        #endregion

        #region Property CYA
        [ObservableProperty]
        int cYAReading;
        [ObservableProperty]
        string? cYAResults;
        #endregion

        #region Property Borate
        [ObservableProperty]
        int borateReading;
        [ObservableProperty]
        string? borateResults;
        [ObservableProperty]
        string? borateNote;
        #endregion

        [ObservableProperty]
        bool saltIsVisible;
        [ObservableProperty]
        Color saltWarning = Colors.White;
        [ObservableProperty]
        Color pHWarning = Colors.White;
        [ObservableProperty]
        bool pHPickerIsVisible;
        [ObservableProperty]
        bool fCNoteIsVisible;

        //public bool FCMeasureIsVisible { get; set; } = false;
        [ObservableProperty]
        bool pHIsVisible;
        [ObservableProperty]
        bool pHRaiseIsVisible;
        [ObservableProperty]
        bool pHLowerIsVisible;
        [ObservableProperty]
        bool alkalineIsVisible;
        [ObservableProperty]
        bool alkalineNoteIsVisible;
        [ObservableProperty]
        Color alkalineWarning = Colors.White;
        [ObservableProperty]
        bool calciumIsVisible;
        [ObservableProperty]
        bool calciumHighIsVisible;
        [ObservableProperty]
        bool cYAIsVisible;
        [ObservableProperty]
        bool cYANotesIsVisible;
        [ObservableProperty]
        Color cYAWarning = Colors.White;
        [ObservableProperty]
        bool borateIsVisible;
        [ObservableProperty]
        bool showInRange;

        //  double[] saturationArray = new double[3];
        [ObservableProperty]
        double saturationIndex;
        [ObservableProperty]
        double saturationIndexTarget;
        [ObservableProperty]
        int chlorinePickerIndex;
        [ObservableProperty]
        bool bleachVisible = true;
        [ObservableProperty]
        public bool fCMeasureIsVisible;
       // double byVolume;
 
       // double byWeight;

        [ObservableProperty]
        Color saturationBackground = Colors.White;


       // public int WaterTemp { get; set; }

        int[] freshWater = new int[4];
        protected enum FreshWaterEnum
        {
            Salt = 0,
            Calcium = 1,
            CYA = 2,
            Borate = 3
        }

        int water = 0;
        public AppSettings Settings ;// { get; }
        public MainLogic(AppSettings settings) 
        {
            //settings = new AppSettings();
            Settings = settings;
            Settings.LoadPreferences();
            AppSettings.OnSettingsEvent += UpdateControl;
            //settings.OnSettingsEvent += UpdateControl;
            // ReadDeviceDisplay();
            SaltReading = Settings.SaltTarget;
            FCReading = Settings.FCTarget;
            PHReading = Settings.PHTarget;
            AlkalineReading = Settings.AlkalineTarget;
            CalciumReading = Settings.CalciumTarget;
            CYAReading = Settings.CYATarget;
            BorateReading = Settings.BorateTarget;
            CalculateSaturation();
        }
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
                    FCMeasure = "Weight";
                    break;
                default:
                    BleachVisible = false;
                    FCMeasureIsVisible = true;
                    break;
            }
        }
        partial void OnSaltReadingChanged(int value)
        {
            _ = EnterSalt();
        }
        partial void OnFCReadingChanged(double value)
        {
            _ = EnterFC();
        }
        partial void OnPHReadingChanged(double value)
        {
            _ = EnterPH();
        }
        partial void OnAlkalineReadingChanged(int value)
        {
            _ = EnterAlkaline();
        }
        partial void OnCalciumReadingChanged(int value)
        {
            _ = EnterCalcium();
        }
        partial void OnCYAReadingChanged(int value)
        {
            _ = EnterCYA();
        }
        partial void OnBorateReadingChanged(int value)
        {
            _ = EnterBorate();
        }

        partial void OnShowInRangeChanged(bool oldValue, bool newValue)
        {
            UpdateControl("InRange", "string.Empty");
            //SettingsEvent?.Invoke("InRange", "string.Empty");
        }

        // Move to base
        //private void ReadDeviceDisplay()
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //    sb.AppendLine($"Pixel width: {DeviceDisplay.Current.MainDisplayInfo.Width} / Pixel Height: {DeviceDisplay.Current.MainDisplayInfo.Height}");
        //    sb.AppendLine($"Density: {DeviceDisplay.Current.MainDisplayInfo.Density}");
        //    sb.AppendLine($"Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
        //    sb.AppendLine($"Rotation: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
        //    sb.AppendLine($"Refresh Rate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");

        //    Debug.WriteLine(sb.ToString());
        //}

        public void UpdateControl(string control, string arg)
        {
            switch (control)
            {
                case "Salt":
                    CalculateSalt();
                    break;
                case "Chlorine":
                    CalculateFC();
                    break;
                case "Volume":
                case "All":
                    CalculateAll();
                    break;
                case "pHAdjustment":
                case "Acid":
                    CalculatePH();
                    break;
                case "Bleach":
                    CalculateFC();
                    break;
                case "Alkaline":
                    CalculateAlkaline();
                    break;
                case "Calcium":
                    CalculateCalcium();
                    break;
                case "CYA":
                    CalculateCYA();
                    break;
                case "FC":
                    CalculateFC();
                    break;
                case "Borate":
                    if (arg == "True")
                        BorateNote = " and Borate of " + BorateReading + ",";
                    else if (arg == "False")
                        BorateNote = ",";
                    else
                        CalculateBorate();
                    break;
                case "InRange":
                    ClearResults();
                    break;
            }
//             Validate(); // Raise event to execute in base class
        }

        private int ReplaceWater(int reading, int target)
        {
            double results;
            results = Math.Round((1 - (double)target / reading) * Units.GetGallons(Settings.Volume), 0);
            return (int)results;
        }

        private void ClearResults()
        {
            CalculateAll();
        }
        [RelayCommand]
        private void CalculateAll()
        {
            if (SaltReading > 0)
                _ = EnterSalt();
            if (FCReading > 0)
                _ = EnterFC();
            if (CalciumReading > 0)
                _ = EnterCalcium();
            if (PHReading > 0)
                _ = EnterPH();
            if (AlkalineReading > 0)
                _ = EnterAlkaline();
            if (CYAReading > 0)
                _ = EnterCYA();
            if (BorateReading > 0)
                _ = EnterBorate();
            CalculateSaturation();
        }
        [RelayCommand]
        private async Task EnterSalt()
        {
            await Task.Delay(10);
            SaltIsVisible = false;
            //SaltWarning = Colors.White;
            //SaltResults = "";
            freshWater[(int)FreshWaterEnum.Salt] = 0;
            if (SaltReading < 0)
            {
                //DisplayAlert("Salt must be >= 0");
                SaltReading = 0;
            }
            else if (SaltReading >= Settings.SaltLower && SaltReading <= Settings.SaltUpper && SaltReading != Settings.SaltTarget)
            {
                 if (ShowInRange)
                CalculateSalt();
            }
            else if (SaltReading != Settings.SaltTarget)

                CalculateSalt();

            UpdateFreshWater();
            CalculateSaturation();
        }

        private void CalculateSalt()
        {
            //no dependants
            string results;
            //double[] units = { 7468.64, 0.0283495 };
            SaltIsVisible = false;
            if (SaltReading < Settings.SaltTarget)
            {
                results = Units.ConvertWeight((Settings.SaltTarget - SaltReading) * Units.GetGallons(Settings.Volume) / 7468.64);

                SaltResults = "Add " + results + " of Salt.";
                SaltIsVisible = true;
                freshWater[(int)FreshWaterEnum.Salt] = 0; // Updated to use generic Enum.Parse<TEnum>
            }
            else if (SaltReading > Settings.SaltTarget)
            {
                water = ReplaceWater(SaltReading, Settings.SaltTarget);
                freshWater[(int)FreshWaterEnum.Salt] = water; // Updated to use generic Enum.Parse<TEnum>
                UpdateFreshWater();
            }
            else
                freshWater[(int)FreshWaterEnum.Salt] = 0; // Updated to use generic Enum.Parse<TEnum>
        }

        private void UpdateFreshWater()
        {
            string astrek = "";
            string[] waterVolume = [" Gallons", " Liters", " Gallons"];
            int max = freshWater.Max();
            if (freshWater[(int)FreshWaterEnum.Salt] > 0)
            {
                if (freshWater[(int)FreshWaterEnum.Salt] < max)
                    astrek = "*";
                SaltResults = "Replace " + Units.ConvertGallons(freshWater.Max()) + " with fresh water" + astrek;
                SaltIsVisible = true;
            }

            astrek = "";
            if (freshWater[(int)FreshWaterEnum.Calcium] > 0)
            {
                if (freshWater[(int)FreshWaterEnum.Calcium] < max)
                    astrek = "*";
                CalciumResults = "Replace " + freshWater.Max() + " gallons with fresh water." + astrek;
                CalciumIsVisible = true;
            }
            //else
            //    CalciumIsVisible = false;

            astrek = "";
            if (freshWater[(int)FreshWaterEnum.CYA] > 0)
            {
                if (freshWater[(int)FreshWaterEnum.CYA] < max)
                    astrek = "*";
                CYAResults = "Replace " + freshWater.Max() + " gallons with fresh water." + astrek;
                CYAIsVisible = true;
            }
            //else
            //    CYAIsVisible = false;

            astrek = "";
            if (freshWater[(int)FreshWaterEnum.Borate] > 0)
            {
                if (freshWater[(int)FreshWaterEnum.Borate] < max)
                    astrek = "*";
                BorateResults = "Replace " + freshWater.Max() + " gallons with fresh water." + astrek;
                BorateIsVisible = true;
            }
            //else
            //    BorateIsVisible = false;
        }

        [RelayCommand]
        private async Task EnterFC()
        {
            await Task.Delay(10);
            FCIsVisible = false;
            //FCCIsVisible = false;
            if (FCReading < 0)
            {
                DisplayAlert("Entry can't be less than 0");
                FCReading = 0;
                return;
            }
            else if (FCReading >= Settings.FCLower && FCReading <= Settings.FCUpper && FCReading != Settings.FCTarget)
            {
                if (ShowInRange)
                CalculateFC();
            }
            else if (FCReading != Settings.FCTarget)
                CalculateFC();
            CalculateSaturation();
        }
        private void CalculateFC()
        {
            //no dependants
            double diff;
            double ratio = 1;
            double results;

            FCNoteIsVisible = false;
            diff = Settings.FCTarget - FCReading;

            if (ChlorinePickerIndex == 0)
            {
                if (Settings.Bleach > 9)
                    ratio = 1.02 - .008 * Settings.Bleach;
                results = diff * Units.GetGallons(Settings.Volume) / ((75.71 * Settings.Bleach + .746 * Settings.Bleach * Settings.Bleach) * ratio);
                if (results > 0)
                {
                    FCResults = "Add " + Units.ConvertVolume(results) + " of " + Settings.Bleach + "% bleach.";
                    FCIsVisible = true;
                }
            }
            else
            {
                results = diff * Units.GetGallons(Settings.Volume) / Settings.chlorineValues[ChlorinePickerIndex, 0];
                if (FCMeasure == "Weight")
                    FCResults = "Add " + Units.ConvertWeight(results) + " by " + FCMeasure + " of " + Settings.ChlorinePickerItem + ".";
                else
                {
                    results *= Settings.chlorineValues[ChlorinePickerIndex, 1];
                    FCResults = "Add " + Units.ConvertVolume(results) + " by " + FCMeasure + " of " + Settings.ChlorinePickerItem + ".";
                }

                FCIsVisible = true;
                if (ChlorinePickerIndex <= 2)
                    FCNoteIsVisible = true;
            }
        }


        [RelayCommand]
        private async Task EnterPH()
        {
            await Task.Delay(10);
            PHIsVisible = false;
            PHRaiseIsVisible = false;
            PHLowerIsVisible = false;

            if (PHReading < 0 || PHReading > 14)
            {
                DisplayAlert("pH must be between 0 and 14");
                PHReading = 0;
                return;
            }
            else if (PHReading >= Settings.PHLower && PHReading <= Settings.PHUpper && PHReading != Settings.PHTarget)
            {
                if (ShowInRange)
                    CalculatePH();
            }
            else if (PHReading != Settings.PHTarget)
                CalculatePH();
            CalculateSaturation();
        }
        private void CalculatePH()
        {
            //dependant on alkalinity and borate

            double delta;
            double drops;
            double diff;
            double temp;
            double adj;
            double extra;
            diff = (PHReading + Settings.PHTarget) / 2;
            drops = (PHReading - Settings.PHTarget) / .2;
            delta = (Settings.PHTarget - PHReading) * Units.GetGallons(Settings.Volume);
            temp = (PHReading + Settings.PHTarget) / 2;
            adj = (192.1626 + -60.1221 * temp + 6.0752 * Math.Pow(temp, 2) + -.1943 * Math.Pow(temp, 3)) * (AlkalineReading + 13.91) / 114.6;
            extra = (-5.476259 + 2.414292 * temp + -0.355882 * Math.Pow(temp, 2) + 0.01755 * Math.Pow(temp, 3)) * BorateReading;
            extra *= delta;
            delta *= adj;
            PHIsVisible = false;
            PHRaiseIsVisible = false;
            PHLowerIsVisible = false;
            if (PHReading < Settings.PHTarget && AlkalineReading <= Settings.AlkalineTarget)
            {
                PHRaiseIsVisible = true;
                switch (Settings.PHRaisePickerIndex)
                {
                    case 0: // Soda Ash by Weight
                        temp = (delta / 218.68) + (extra / 218.68);
                        PHAdjustment = "Add " + Units.ConvertWeight(temp) + " of Sodium Carbonate.";
                        break;
                    case 1: // Soda Ash by Volume
                        temp = ((delta / 218.68) + (extra / 218.68)) * .8715;
                        PHAdjustment = "Add " + Units.ConvertVolume(temp) + " of Sodium Carbonate.";
                        break;
                    case 2: // Borax by Weight
                        temp = (delta / 110.05) + (extra / 110.05);
                        PHAdjustment = "Add " + Units.ConvertWeight(temp) + " of Borax.";
                        break;
                    case 3: // Borax by Volume
                        temp = ((delta / 110.05) + (extra / 110.05)) * .9586;
                        PHAdjustment = "Add " + Units.ConvertVolume(temp) + " of Borax.";
                        break;
                }
                if (Settings.IncludeBorate)
                    BorateNote = " and Borate of " + BorateReading + "\r\n";
                else
                    BorateNote = "\r\n";
                //PHIsVisible = true;
            }
            else if (PHReading > Settings.PHTarget)
            {
                switch (Settings.PHLowerPickerIndex)
                {
                    case 0:
                        temp = (delta / -240.15 * Settings.acidValues[Settings.AcidPickerIndex]) +
                        (extra / -240.15 * Settings.acidValues[Settings.AcidPickerIndex]);
                        PHAdjustment = "Add " + Units.ConvertVolume(temp) + " of " + Settings.AcidPickerItem;
                        break;
                    case 1:
                        temp = (delta / -178.66) + (extra / -178.66);
                        PHAdjustment = "Add " + Units.ConvertWeight(temp) + " of " + Settings.AcidPickerItem;
                        break;
                    case 2:
                        temp = ((delta / -178.66) + (extra / -178.66)) * .6657;
                        PHAdjustment = "Add " + Units.ConvertVolume(temp) + " of " + Settings.AcidPickerItem;
                        break;
                }
                // PHIsVisible = true;
                PHLowerIsVisible = true;
            }
           // else
           // {
           //     PHAdjustment = "Lowering Alkalinty will raise your pH.";
           // }
            PHIsVisible = true;
        }

        //not using??? Check original
        //partial void OnPHPickerItemChanged(string? value)
        //{
        //    if (pHPicker == null)
        //        return;
        //    CalculatePH();
        //}

        private void DisplayAlert(string Text)
        {
            AppShell.Current.DisplayAlert("Alert", Text, "OK");
        }

        [RelayCommand]
        private protected void LogResults()
        {
            string status;
            CalculateAll();
            status = db.AddNewLog(1, Settings.Volume, Settings.WaterTemp, SaturationIndex, SaltReading, FCReading, PHReading, AlkalineReading, CalciumReading, CYAReading, BorateReading);
            if (status != "")
            {
                DisplayAlert(status);
            }
            else
            {
                DisplayAlert("Log added successfully.");
            }
        }

        [RelayCommand]
        private protected void ViewResults()
        {
            //LogViewModel logRepo = new(); // App.LogRepo;
            // string status;
         //   List<LogTable> log = logRepo.GetAllLogs(); //App.LogRepo.GetAllLogs();

        }
        [RelayCommand]
        private async Task EnterAlkaline()
        {
            // EnterAlkaline();
            await Task.Delay(10);
            AlkalineIsVisible = false;
            AlkalineNoteIsVisible = false;
           // if (AlkalineReading < 0 || AlkalineReading > 200)
           // {
                //DisplayAlert("Alkaline must be between 0 and 200");
           //     AlkalineReading = 0;
           // }
           // else
           if (AlkalineReading >= Settings.AlkalineLower && AlkalineReading <= Settings.AlkalineUpper && AlkalineReading != Settings.AlkalineTarget)
            {
                if (ShowInRange)
                    CalculateAlkaline();
            }
            else if (AlkalineReading != Settings.AlkalineTarget)
                CalculateAlkaline();
            if (PHReading > 0)
                _ = EnterPH();
            CalculateSaturation();
        }
        private void CalculateAlkaline()
        {
            //no dependants
            double diff;
            double results;
            diff = (Settings.AlkalineTarget - AlkalineReading);
            AlkalineNoteIsVisible = true;
            if (diff > 0)

            {
                results = diff * Units.GetGallons(Settings.Volume) / 4259.15;
                if (AlkalineMeasure == "Volume")
                {
                    results = diff * Units.GetGallons(Settings.Volume) / 4259.15 * .7988; // convert to volume     
                    BakingSodaAdd = "Add " + Units.ConvertVolume(results) + " of Baking Soda";
                }
                else
                    BakingSodaAdd = "Add " + Units.ConvertWeight(results) + " of Baking Soda";

                AlkalineIsVisible = true;
                AlkalineNote = "Note: Adding Baking Soda will slightly raise your pH.";
            }
            else if (diff < 0)
            {
                AlkalineNote = "To lower Alkalinity, reduce pH to 7.0-7.2 with acid and then aerate to increase pH.";
            }
            else
                AlkalineNoteIsVisible = false;
            CalculateSaturation();
        }

        [RelayCommand]
        private async Task EnterCalcium()
        {
            await Task.Delay(10);
            CalciumIsVisible = false;
            CalciumHighIsVisible = false;
            freshWater[(int)FreshWaterEnum.Calcium] = 0;
            CalciumResults = null;
            if (CalciumReading < 0 || CalciumReading > 900)
            {
                DisplayAlert("Calcium must be between 0 and 900");
                CalciumReading = 0;
            }
            else if (CalciumReading >= Settings.CalciumLower && CalciumReading <= Settings.CalciumUpper && CalciumReading != Settings.CalciumTarget)
            {
                if (ShowInRange)
                    CalculateCalcium();
            }
            else if (CalciumReading != Settings.CalciumTarget)
                CalculateCalcium();
            CalculateSaturation();
            UpdateFreshWater();
        }

        private void CalculateCalcium()
        {
            //no dependants
            double diff;
            double temp;
            int water;
            int calciumPicker = 1;
            string results;

            freshWater[(int)FreshWaterEnum.Calcium] = 0; // Updated to use generic Enum.Parse<TEnum>
            diff = (CalciumReading - Settings.CalciumTarget);

            if (diff < 0)
            {
                temp = (Settings.CalciumTarget - CalciumReading) * Units.GetGallons(Settings.Volume);
                switch (Settings.CalciumRaisePickerIndex)
                {
                    case 0:
                        temp = temp / 6754.11 / calciumPicker;
                        results = Units.ConvertWeight(temp);
                        CalciumResults = "Add " + results + " of Calcium Chloride.";
                        break;
                    case 1:
                        temp = temp / 6754.11 * 0.7988; // convert to volume
                        results = Units.ConvertVolume(temp);
                        CalciumResults = "Add " + results + " of Calcium Chloride.";
                        break;
                    case 2:
                        temp /= 5098.82 / calciumPicker;
                        results = Units.ConvertWeight(temp);
                        CalciumResults = "Add " + results + " of Calcium Chloride Dihydrate.";
                        break;
                    case 3:
                        temp /= 5098.82 * 1.148; // convert to volume
                        results = Units.ConvertVolume(temp);
                        CalciumResults = "Add " + results + " of Calcium Chloride Dihydrate.";
                        break;
                }
                CalciumIsVisible = true;
            }
            else
            {
                water = ReplaceWater(CalciumReading, Settings.CalciumTarget);
                freshWater[(int)FreshWaterEnum.Calcium] = water; // Updated to use generic Enum.Parse<TEnum>
                UpdateFreshWater();
            }
        }





        [RelayCommand]
        private async Task EnterCYA()
        {
            await Task.Delay(10);
            CYAIsVisible = false;
            CYANotesIsVisible = false;
            CYAResults = null;
            freshWater[(int)FreshWaterEnum.CYA] = 0;
            if (CYAReading < 0 || CYAReading > 100)
            {
                DisplayAlert("CYA must be between 0 and 100");
                CYAReading = 0;
            }
            else if (CYAReading >= Settings.CYALower && CYAReading <= Settings.CYAUpper && CYAReading != Settings.CYATarget)
            {
                if (ShowInRange)
                    CalculateCYA();
            }
            else if (CYAReading != Settings.CYATarget)
                CalculateCYA();
            CalculateSaturation();
            UpdateFreshWater();
        }

        private void CalculateCYA()
        {
            //no dependants
            double temp;
            string results;
            CYAResults = null;
            CYAIsVisible = false;
            CYANotesIsVisible = false;
            if (CYAReading < Settings.CYATarget)
            {
                switch (Settings.CYARaisePickerIndex)
                {
                    case 0:
                        temp = (Settings.CYATarget - CYAReading) * Units.GetGallons(Settings.Volume) / 7489.51;
                        results = Units.ConvertWeight(temp);
                        CYAResults = "Add " + results + " of Stabilizer.";
                        break;
                    case 1:
                        temp = (Settings.CYATarget - CYAReading) * Units.GetGallons(Settings.Volume) / 7489.51 * 1.042;
                        results = Units.ConvertVolume(temp);
                        CYAResults = "Add " + results + " of Stabilizer.";
                        break;
                    case 2:
                        temp = (Settings.CYATarget - CYAReading) * Units.GetGallons(Settings.Volume) / 2890;
                        results = Units.ConvertVolume(temp);
                        CYAResults = "Add " + results + " of Liquid Stabilizer.";
                        break;
                }
                CYANotesIsVisible = true;
            }
            else
            {
                water = ReplaceWater(CYAReading, Settings.CYATarget);
                freshWater[(int)FreshWaterEnum.CYA] = water; // Updated to use generic Enum.Parse<TEnum>
                UpdateFreshWater();
            }
            if (CYAResults != "")
                CYAIsVisible = true;

        }

        [RelayCommand]
        private async Task EnterBorate()
        {
            await Task.Delay(10);
            BorateIsVisible = false;
            // BorateNoteIsVisible = false;
            BorateResults = null;
            freshWater[(int)FreshWaterEnum.Borate] = 0;
            if (BorateReading < 0 || BorateReading > 100)
            {
                DisplayAlert("Borate must be between 0 and 100");
                BorateReading = 0;
            }
            else if (BorateReading >= Settings.BorateLower && BorateReading <= Settings.BorateUpper && BorateReading != Settings.BorateTarget)
            {
                if (ShowInRange)
                    CalculateBorate();
            }
            else if (BorateReading != Settings.BorateTarget)
                CalculateBorate();
            if (PHReading > 0)
                CalculatePH();
            CalculateSaturation();
        }

        private void CalculateBorate()
        {
            //no dependants
            double temp;
            string results;
            double[,] values =
            {
                    // volume, acid
                    { .9586, .4765 },
                    { 1.075,0 },
                    { 0.5296, 0.624 }
                };
            //int index=0;
            //if (BorateMeasure == "Volume") index = 1;
            if (BorateReading < Settings.BorateTarget)
            {
                temp = (Settings.BorateTarget - BorateReading) * Units.GetGallons(Settings.Volume) / Settings.borateValues[Settings.BoratePickerIndex];

                if (BorateMeasure == "Weight")
                {
                    results = Units.ConvertWeight(temp);
                    BorateResults = "Add " + results + " by weight of " + Settings.BoratePickerItem;
                }
                else
                {
                    results = Units.ConvertVolume(temp * values[Settings.BoratePickerIndex, 0]);
                    BorateResults = "Add " + results + " by volume of " + Settings.BoratePickerItem;
                }
                //      BorateResults2 = "Add " + Math.Round(temp * values[index, 1], 0) + " oz of 31.45% muriatic acid to compensate for pH increase.";
                if (Settings.BoratePickerIndex != 1)
                {
                    results = Units.ConvertVolume(temp * values[Settings.BoratePickerIndex, 1]);
                    BorateResults += "\r\nAdd " + results + " of 31.45% Muriatic Acid to compensate for pH increase.";
                }
            }
            else
            {
                water = ReplaceWater(BorateReading, Settings.BorateTarget);
                freshWater[(int)FreshWaterEnum.Borate] = water; // Updated to use generic Enum.Parse<TEnum>
                UpdateFreshWater();
            }

            BorateIsVisible = true;
        }


        [RelayCommand]
        private async Task EnterWaterTemp()
        {
            await Task.Delay(10);
            SaturationIndex = 0;
            if (Settings.WaterTemp < 32 || Settings.WaterTemp > 100)
            {
                Settings.WaterTemp = 50;
                return;
            }

            CalculateSaturation();
        }
        [RelayCommand]
        private void CalculateSaturation()
        {
            double carbAlk;
            double extra_NaCL;
            double Ionic;
            double Borate = 0;
            double CSI;
            int temp = Settings.WaterTemp;
            if (Settings.StandardIndex != 1)
                temp = (int)((Settings.WaterTemp - 32) * 5 / 9 + .5);
            // Target SI
            carbAlk = Settings.AlkalineTarget - .38772 * Settings.CYATarget / (1 + Math.Pow(10, 6.83 - Settings.PHTarget)) - 4.63 * Borate / (1 + Math.Pow(10, 9.11 - Settings.PHTarget));
            // CarbAlk = TA - 0.38772 * CYA               / (1 + Math.pow(10, 6.83 - PH))        - 4.63 * Borate / (1 + Math.pow(10, 9.11 - PH));
            extra_NaCL = Settings.SaltTarget - 1.1678 * Settings.CalciumTarget;
            if (extra_NaCL < 0)
                extra_NaCL = 0;
            Ionic = (1.5 * Settings.CalciumTarget + 1 * Settings.AlkalineTarget) / 50045 + extra_NaCL / 58440;
            //                    (1.5 * CH             + 1 * TA)              / 50045 + extra_NaCl / 58440;
            CSI = Settings.PHTarget - 11.67 + Math.Log(Settings.CalciumTarget) / Math.Log(10) + Math.Log(carbAlk) / Math.Log(10) - 2.56 * Math.Sqrt(Ionic) / (1 + 1.65 * Math.Sqrt(Ionic)) - 1412.5 / (temp + 273.15) + 4.7375;
            if (!double.IsNaN((CSI * 100 + .5) / 100))
                SaturationIndexTarget = Math.Round((CSI * 100 + .5) / 100, 2);
            else
                SaturationIndexTarget = 0;
            //Current SI
            carbAlk = AlkalineReading - .38772 * CYAReading / (1 + Math.Pow(10, 6.83 - PHReading)) - 4.63 * Borate / (1 + Math.Pow(10, 9.11 - PHReading));
            // CarbAlk = TA - 0.38772 * CYA               / (1 + Math.pow(10, 6.83 - PH))        - 4.63 * Borate / (1 + Math.pow(10, 9.11 - PH));
            extra_NaCL = SaltReading - 1.1678 * CalciumReading;
            if (extra_NaCL < 0)
                extra_NaCL = 0;
            Ionic = (1.5 * CalciumReading + 1 * AlkalineReading) / 50045 + extra_NaCL / 58440;
            //                    (1.5 * CH             + 1 * TA)              / 50045 + extra_NaCl / 58440;
            CSI = PHReading - 11.67 + Math.Log(CalciumReading) / Math.Log(10) + Math.Log(carbAlk) / Math.Log(10) - 2.56 * Math.Sqrt(Ionic) / (1 + 1.65 * Math.Sqrt(Ionic)) - 1412.5 / (temp + 273.15) + 4.7375;
            SaturationIndex = Math.Round((CSI * 100 + .5) / 100, 2);
            //SaturationIndex = Math.Round(PHReading + saturationArray[0] + saturationArray[1] + saturationArray[2] - 12.1, 2);
            if (double.IsPositiveInfinity(SaturationIndex) || double.IsNegativeInfinity(SaturationIndex)) return;
            if (SaturationIndex >= .50 || SaturationIndex <= -.50)
                SaturationBackground = Colors.PaleVioletRed;
            else if (SaturationIndex >= .25 || SaturationIndex <= -.25)
                SaturationBackground = Colors.Yellow;
            else
                SaturationBackground = Colors.White;

            carbAlk = Settings.AlkalineTarget - .38772 * Settings.CYATarget / (1 + Math.Pow(10, 6.83 - Settings.PHTarget)) - 4.63 * Borate / (1 + Math.Pow(10, 9.11 - Settings.PHTarget));
            // CarbAlk = TA - 0.38772 * CYA               / (1 + Math.pow(10, 6.83 - PH))        - 4.63 * Borate / (1 + Math.pow(10, 9.11 - PH));
            extra_NaCL = Settings.SaltTarget - 1.1678 * Settings.CalciumTarget;
            if (extra_NaCL < 0)
                extra_NaCL = 0;
            Ionic = (1.5 * Settings.CalciumTarget + 1 * Settings.AlkalineTarget) / 50045 + extra_NaCL / 58440;
            //                    (1.5 * CH             + 1 * TA)              / 50045 + extra_NaCl / 58440;
            CSI = Settings.PHTarget - 11.67 + Math.Log(Settings.CalciumTarget) / Math.Log(10) + Math.Log(carbAlk) / Math.Log(10) - 2.56 * Math.Sqrt(Ionic) / (1 + 1.65 * Math.Sqrt(Ionic)) - 1412.5 / (temp + 273.15) + 4.7375;
            if (!double.IsNaN((CSI * 100 + .5) / 100))
                SaturationIndexTarget = Math.Round((CSI * 100 + .5) / 100, 2);
            else
                SaturationIndexTarget = 0;
        }
        [RelayCommand]
        private protected void RadioButtonChanged(string value)
        {
            string control;
            int index = value.IndexOf("-");

            control = value[..index];
            switch (control)
            {
                case "Alkaline":
                    AlkalineMeasure = value[(index + 1)..];
                    // SettingsEvent?.Invoke("Alkaline","");
                    break;
                case "Borate":
                    BorateMeasure = value[(index + 1)..];
                    //SettingsEvent?.Invoke("Borate", "");
                    break;
                case "FC":
                    FCMeasure = value[(index + 1)..];
                    //SettingsEvent?.Invoke("FC", "");
                    break;
            }

        }


    }
}

