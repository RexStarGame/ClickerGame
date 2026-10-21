using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClickerGame
{
    public partial class MainWindow : Window
    {
        private Game game = new Game();
        private AutoClick autoClick = new AutoClick();
        private AutoClickX2 autoClickX2 = new AutoClickX2();
        private DispatcherTimer displayTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            AutoClickButton.Content = $"Upgrade: AutoClick\nPrice: {autoClick.UpgradeCost.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"))} Clicks";

            AutoClickX2Button.Content = $"Powerup: AutoClickX2\nPrice: {autoClickX2.PowerupCost.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"))} Clicks";
            
            displayTimer.Interval = TimeSpan.FromSeconds(0.1);

            displayTimer.Tick += (sender, e) =>
            {
                TotalClicks.Text = game.TotalClicks.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"));
            };

            displayTimer.Start();

        }

        private void Clicker_Area(object sender, RoutedEventArgs e)
        {
            game.Click();

            TotalClicks.Text = game.TotalClicks.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"));
        }

        private void Powerup_AutoClickX2(object sender, RoutedEventArgs e)
        {
            bool success = game.BuyPowerup(autoClickX2);
            if (success)
            {
                autoClickX2.ActivateAutoClickX2(game, autoClick);
                TotalClicks.Text = game.TotalClicks.ToString();
                AutoClickX2Button.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("You don't have enough clicks!");
            }

        }

        private void Powerup_DoubleClick(object sender, RoutedEventArgs e)
        {

        }

        private void Upgrade_AutoClick(object sender, RoutedEventArgs e)
        {
            bool success = game.BuyUpgrade(autoClick);
            if (success)
            {
                autoClick.ActivateAutoClick(game);
                TotalClicks.Text = game.TotalClicks.ToString();
                AutoClickButton.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("You don't have enough clicks!");
            }

        }

        private void Upgrade_IncreaseClick(object sender, RoutedEventArgs e)
        {

        }
    }
}