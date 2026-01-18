
//using Microsoft.Maui.Graphics;
//using PoolChemicals.ViewModel;
//using System.Runtime.InteropServices;
//using System.Text.RegularExpressions;


using Syncfusion.Maui.Inputs;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PoolChemicals
{

    public partial class MainPage : ContentPage
    {

        IList<string> volumeList { get; } = new List<string>
           {
               "oz", "pt", "qt", "gal", "L"
           };
        IList<string> weightList { get; } = new List<string>
           {
               "oz", "lbs"
           };
        public MainPage(MainViewModel vm)
        {
            InitializeComponent(); // Ensure this method is correctly generated in the XAML.g.cs file
            BindingContext = vm;

         //   vm.ListEvent += ChangeList;
        }

        //protected override void OnNavigatedTo(NavigatedToEventArgs args)
        //{
        //    ((MainViewModel)BindingContext).LoadData();
        //    base.OnNavigatedTo(args);

        //}
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void LinearShapePointer_ValueChangeCompleted(object sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
        {
            Debug.WriteLine($"Value changed: {e.Value}"); // Debugging output to check value changes
        }

        private void LinearShapePointer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.WriteLine($"Property changed: {e.PropertyName}"); // Debugging output to check property changes
        }


        //private void SfNumericEntry_ValueChanged_1(object sender, NumericEntryValueChangedEventArgs e)
        //{
        //    var oldValue = e.OldValue;
        //    var newValue = e.NewValue;            
        //}
//        ValueChanged="SfNumericEntry_ValueChanged_1"
        //private void ChangeList(string control, string changeList)
        //{
        //    if (changeList == "volume")
        //    {
        //        switch (control)
        //        {
        //            case "pH":
        //                //PHPickerList.ItemsSource = (System.Collections.IList)volumeList;
        //                break;
        //            case "Alkaline":
        //         //       AlkalinePickerList.ItemsSource = (System.Collections.IList)volumeList;
        //                break;
        //        }
        //    }
        //    else if (changeList == "weight")
        //    {
        //        switch (control)
        //        {
        //            case "pH":
        //               // PHPickerList.ItemsSource = (System.Collections.IList)weightList;
        //                break;
        //            case "Alkaline":
        //               // AlkalinePickerList.ItemsSource = (System.Collections.IList)weightList;
        //                break;
        //        }
        //    }
        //}
    }
}
