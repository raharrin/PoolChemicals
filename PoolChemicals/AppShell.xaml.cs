using PoolChemicals.View;

namespace PoolChemicals
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(WaterGuidelinesPage), typeof(WaterGuidelinesPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(LogPage), typeof(LogPage));
            Routing.RegisterRoute(nameof(PoolPage), typeof(PoolPage));
        }
    }
}
