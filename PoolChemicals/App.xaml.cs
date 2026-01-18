using PoolChemicals.Model;

namespace PoolChemicals
{
    public partial class App : Application
    {
 //       public static LogViewModel LogRepo { get; set; }
        //        public App(LogViewModel myLog)
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/VkR+XU9Ff1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3tSdEdlWXhaeXZXTmdcUU91XQ==");
            InitializeComponent();
//            LogRepo = myLog;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }



        //protected override Window Deactivate(IActivationState activationState)
        //{
        //    Window window = base.CreateWindow(activationState);

        //    window.Created += (s, e) =>
        //    {
        //        // Custom logic
        //    };

        //    return window;
        //}
    }
}