using PoolChemicals.Model;
using PoolChemicals.View;
using System.Text;

namespace PoolChemicals.ViewModel
{
    //   [QueryProperty(nameof(Tests), "Tests")]

  //  public AppSettings Settings = new(); //{ get; }

    public partial class EmailViewModel : BaseViewModel
    {

        [ObservableProperty]
        string emailBody;
        [ObservableProperty]
        bool sendData;


        private protected AppSettings Settings;
        private protected MainLogic Logic;
        public EmailViewModel(MainLogic logic,AppSettings settings)
        {
            Settings = settings;
            Logic = logic;
            CompileData();
            SendData = true;
          //  _ = SendIt();
        }


        [RelayCommand]
        private protected async Task SendIt()
        {
            if (Email.Default.IsComposeSupported)
            {
                string subject = "Pool Readings";
               
                string[] recipients = ["raharrin@gmail.com"];
                //if (SendData)
                //    EmailBody = CompileData();
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = EmailBody,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = [.. recipients]
                };
                await Email.Default.ComposeAsync(message);
            }
        }
        [RelayCommand]
        public void ClearEditor()
        {
            EmailBody="";

        }

        [RelayCommand]
        public void CompileData()
        {
            StringBuilder sb = new();// StringBuilder();
            //sb.AppendLine("Pool Chemicals Data");
            sb.AppendLine("Pool Test Readings");
            sb.AppendLine("Date: " + DateTime.Now);
           // sb.AppendLine("Time: " + DateTime.Now.ToString("t"));
            sb.AppendLine("Volume: " + Settings.Volume);
            sb.AppendLine("Water Tempurature: " + Settings.WaterTemp);
            sb.AppendLine("Saturation Index: " + Logic.SaturationIndex);
            sb.AppendLine("Saturation Index Target: " + Logic.SaturationIndexTarget);

            sb.Append("Salt: " + Logic.SaltReading);
            if (Logic.SaltResults != null)
                 sb.Append (" - " + Logic.SaltResults);
            sb.AppendLine();
            sb.Append("Free Chlorine: " + Logic.FCReading);
            if (Logic.FCResults != null) 
                sb.Append(" - " + Logic.FCResults);
            sb.AppendLine();
            sb.Append("pH: " + Logic.PHReading);
            if (Logic.PHAdjustment != null) 
                sb.Append(" - " + Logic.PHAdjustment);
            sb.AppendLine();
            sb.Append("Alkalinity: " + Logic.AlkalineReading);
            if (Logic.BakingSodaAdd != null) 
                sb.Append(" - " + Logic.BakingSodaAdd);
            sb.AppendLine();
            sb.Append("Calcium: " + Logic.CalciumReading);
                if (Logic.CalciumResults != null) 
                sb.Append(" - " + Logic.CalciumResults);
            sb.AppendLine();
            sb.Append("Cyanuric Acid: " + Logic.CYAReading);
            if (Logic.CYAResults != null) 
                sb.Append(" - " + Logic.CYAResults);
            sb.AppendLine();
            if (Settings.IncludeBorate)
            {
                sb.Append("Borate: " + Logic.BorateReading);
                if (Logic.BorateResults != null)
                    sb.Append(" - " + Logic.BorateResults);
                sb.AppendLine();
            }
            EmailBody = sb.ToString();
            //return EmailBody;
        }
    }
}
