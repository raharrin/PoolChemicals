using PoolChemicals.Model;
using System.Collections.Generic;

namespace PoolChemicals.View;


public partial class LogPage : ContentPage
{
    public static LogTable logTable = new LogTable();
    public static DateTime MinDate { get; } = new DateTime(2000, 1, 1);
    public static DateTime MaxDate { get; } = new DateTime(2100, 12, 31);
    private Database db = new Database();
    private LogViewModel viewModel;// = new();
    public LogPage(LogViewModel vm)
	{
		InitializeComponent();
        viewModel = vm;
        //GetMinMaxDates();
        BindingContext = vm;
    }

    private protected void ViewResults(object sender, EventArgs args)
    {
        string status;
        logList.IsVisible = false;
        List<LogTable> log = db.GetAllLogs();//App.LogRepo.GetAllLogs();// App.LogRepo.GetAllLogs();
        logList.ItemsSource = log;
        if (log.Count>0)
            logList.IsVisible = true;
    }



    private void AddData(object sender, EventArgs e)
    {
        Random ri = new Random();
        Random rd = new Random();

        string status;
        DateTime myday = DateTime.Now;
        logTable = new LogTable();
        logTable.Volume = 10000;

        status = db.DeleteAll();// App.LogRepo.DeleteAll();
        
        for (int i = 0; i <= 10; i++)
        {
            logTable.Tempurature = ri.Next(70, 90);
            logTable.SaturationIndex = Math.Round(rd.NextDouble() * (1.0 - (-.750)) + (-.750),2); // between -1 and 1
            logTable.Salt = ri.Next(2500, 3300);
            logTable.FC = ri.Next(1, 5);
            logTable.PH = Math.Round(rd.NextDouble() * (8.4 - 7.0) + 7.0,1); // between 6.5 and 8.0
            logTable.Alkaline = ri.Next(60, 100);
            logTable.Calcium = ri.Next(200, 500);
            logTable.CYA = ri.Next(0, 90);
            logTable.Borate = 0;
            logTable.Date = myday;

            status = db.AddNewLog(logTable); //App.LogRepo.AddNewLog(logTable);
            if (status != "Success")
            //DisplayAlert("Success", "Log added successfully", "OK");
            //            else
            {
                DisplayAlert("Error", status, "OK");
                status = "Failed";
                break;
            }
            myday = myday.AddDays(-1);
        }
    }



    private void DeleteLog(object sender, EventArgs e)
    {
        string status;
        LogTable? record = new LogTable();
        Button? srcButton = sender as Button;
        record = srcButton.BindingContext as LogTable;
        if (sender != null)
        {
            status = db.DeleteRecord(record.Id); //App.LogRepo.DeleteRecord(record.Id);


            // logList.ClearValue(ItemsView.ItemsSourceProperty);
            List<LogTable> log = db.GetAllLogs();// App.LogRepo.GetAllLogs();
            logList.ItemsSource = log;
            
        }
        else
        {
            status = "Please select a log to delete";
            DisplayAlert("Error", status, "OK");
            return;
        }
    }
}