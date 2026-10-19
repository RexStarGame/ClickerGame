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

namespace ClickerGame
{
    public partial class MainWindow : Window
    {
        private Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Clicker_Area(object sender, RoutedEventArgs e)
        {
            game.Click();

            CurrencyText.Text = game.Currency.ToString();
        }

        private void Powerup_Speed(object sender, RoutedEventArgs e)
        {

        }

        private void Powerup_DoubleClick(object sender, RoutedEventArgs e)
        {

        }

        private void Upgrade_AutoClick(object sender, RoutedEventArgs e)
        {

        }

        private void Upgrade_IncreaseClick(object sender, RoutedEventArgs e)
        {

        }
    }
}