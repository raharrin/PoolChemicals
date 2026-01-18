

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
        [ObservableProperty]
        bool isValid=true;
        protected BaseViewModel()
        {
 
        }
    }
}
