using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolChemicals.Model
{
    public static class Units
    {
        public enum Model
        {
            US,
            Metric,
            Imperial
        }

        public enum Temperatures
        {
            Fahrenheit,
            Celsius,
        }

        public enum SizeUnits
        {
            Gallons,
            Liters,
            GallonsImperial
        }


        private static Temperatures _Temperature;
        public static Temperatures Temperature
        {
            get
            {
                return _Temperature;
            }
            set
            {
                _Temperature = value;
            }
        }


        private static Model _CurrentModel;
        public static Model CurrentModel
        {
            get { return _CurrentModel; }
            set
            {
                _CurrentModel = value;
                SetUnits(value);
            }
        }


        public static void SetUnits(Model model)
        {
            switch (model)
            {
                case Model.US:
                    _Temperature = Temperatures.Fahrenheit;

                    //   Tempurature = (int)(Tempurature - 32) * 5 / 9;
                    break;
                case Model.Metric:
                    _Temperature = Temperatures.Celsius;
                    //  Tempurature = (Tempurature * 9 / 5) + 32;
                    break;
                case Model.Imperial:
                    _Temperature = Temperatures.Fahrenheit;
                    //   Tempurature = (int)(Tempurature - 32) * 5 / 9;
                    break;
                default:
                    _Temperature = Temperatures.Fahrenheit;
                    //   Tempurature = (int)(Tempurature - 32) * 5 / 9;
                    break;
            }
        }

        //conversion routines

        public static int USToMetric(int value)
        {
            // Convert gallons to liters
            return (int)(value * 3.78541 + 0.5);
        }
        public static int USToImperial(int value)
        {
            // Convert gallons to liters
            return (int)(value * 0.832674 + 0.5);
        }
        public static int MetricToImperial(int value)
        {
            // Convert gallons to liters
            return (int)(value * .219969 + 0.5);
        }
        public static int MetricToUS(int value)
        {
            // Convert gallons to liters
            return (int)(value * 0.264172 + 0.5);
        }
        public static int ImperialToMetric(int value)
        {
            // Convert gallons to liters
            return (int)(value * .219969 + 0.5);
        }
        public static int ImperialToUS(int value)
        {
            // Convert gallons to liters
            return (int)(value * 4.54609 + 0.5);
        }
        public static int ConvertTempurature(int value)
        {
            // Convert tempurature to the target unit
            double temp;
            if (_Temperature == Temperatures.Fahrenheit)
                temp = (double)(value - 32) * 5 / 9 + .5;
            else
                temp = (double)value * (9.0 / 5.0) + 32;
            return (int)Math.Round(temp);
        }

        public static string ConvertGallons(double value)
        {
            // Convert gallons to the target unit
            if ((int)_CurrentModel == 1)
                return Math.Round(value * 3.78541, 0) + " Liters";
            else if ((int)_CurrentModel == 2)
                return Math.Round(value * .832674) + " Gallons";
            return value + " Gallons";
        }



        //Returns true gallons
        public static int GetGallons(int value = 0)
        {
            if (value == 0)
                return 0;
            if ((int)_CurrentModel == 1)
                return (int)(value / 3.78541 + .5); // Explicit cast added to fix CS0266  
            else if ((int)_CurrentModel == 2)
                return (int)(value * 1.20095 + .5); // Explicit cast added to fix CS0266  
            else
                return value;
        }
        public static string ConvertWeight(double oz)
        {
            double results;
            // Convert ounces to the target unit
            if ((int)_CurrentModel == 1)
            {
                results = oz * 28.3495; // Convert to grams
                if (results >= 1000)
                    return ConvertLbskg(results);
                else
                    return Math.Round(results) + " g";
            }
            if (oz < 10)
                return Math.Round(oz, 1) + " oz";

            return ConvertToLbsCups(oz);
        }

        public static string ConvertLbskg(double value)
        {
            // Convert pounds to the target unit
            if ((int)_CurrentModel == 1)
                return Math.Round(value / 1000, 1) + " kg";
            else
                return ConvertToLbsCups(value, true);
        }

        public static string ConvertVolume(double value)
        {
            // Convert ounces to the target unit
            if ((int)_CurrentModel == 1)
            {
                value *= 29.5735;
                if (value >= 1000)
                    return Math.Round(value / 1000, 1) + " L";
                else
                    return Math.Round(value += .5) + " mL";
            }
            else if ((int)_CurrentModel == 2)
                value *= 1.04084;
            if (value < 10)
                return Math.Round(value + .05) + "." + Math.Round(value * 10 + .5) % 10 + " oz";
            return ConvertToLbsCups(value, true);
        }

        private static string ConvertToLbsCups(double value, bool toCups = false)
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

    }
}
