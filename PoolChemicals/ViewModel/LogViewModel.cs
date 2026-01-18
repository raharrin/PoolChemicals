using PoolChemicals.Model;
using SQLite;
//using static Android.Provider.Contacts;

namespace PoolChemicals.ViewModel
{
    public partial class LogViewModel(MainLogic logic) : BaseViewModel
    {

       // public  DateTime MinDate { get; } = new DateTime(2000, 1, 1);
       // public  DateTime MaxDate { get; } = new DateTime(2100, 12, 31);
       // public DateTime CurDate { get; } = new DateTime(2100, 12, 31);
       // public string StatusMessage { get; set; } = "";
       // string _dbPath = FileAccessHelper.GetLocalFilePath("poolLog.db3");
        // TODO: Add variable for the SQLite connection

        private AppSettings settings;
        private MainLogic Logic = logic;
    }
}
