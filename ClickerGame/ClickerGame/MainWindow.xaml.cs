using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClickerGame
{
    public partial class MainWindow : Window
    {
        ClassClicker classClicker = new ClassClicker(); // opretter et object af klassen ClassClicker
        ClassClickPower classClickPower = new ClassClickPower();

        Random random = new Random();
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken;

        private bool pressed = false;
        private AutoClick autoClick = new AutoClick();
        private AutoClickX2 autoClickX2 = new AutoClickX2();
        private DispatcherTimer displayTimer = new DispatcherTimer();
        private DispatcherTimer powerupTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            cancellationToken = cancellationTokenSource.Token;
            UpgradeClickButton.Content = $"Upgrade: {classClickPower.UpgradePrice} Clicks";

            AutoClickButton.Content = $"Upgrade: AutoClick\nPrice: {autoClick.UpgradeCost.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"))} Clicks";

            AutoClickX2Button.Content = $"Powerup: AutoClickX2\nPrice: {autoClickX2.PowerupCost.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"))} Clicks";
            
            displayTimer.Interval = TimeSpan.FromSeconds(0.1);

            displayTimer.Tick += (sender, e) =>
            {
                TotalClicks.Text = classClicker.ClicksCurrency.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"));
            };

            displayTimer.Start();

            powerupTimer.Interval = autoClickX2.Duration;

            powerupTimer.Tick += (sender, e) =>
            {
                autoClick.SetSpeed(1);
                AutoClickX2Button.IsEnabled = true;
                powerupTimer.Stop();
            };
        }

        private void MovingText()
        {
            TextBlock earnedCurrencyText = new TextBlock
            {
                Text = $"+{1 + classClickPower.ClickPowerUp:0.##}",
                FontSize = 20
            };

            MovingTextCanvas.Children.Add(earnedCurrencyText);

            Canvas.SetLeft(earnedCurrencyText, 80);
            Canvas.SetTop(earnedCurrencyText, 100);

            DoubleAnimation move = new DoubleAnimation(100, 0, TimeSpan.FromSeconds(1));
            DoubleAnimation fade = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));

            earnedCurrencyText.BeginAnimation(Canvas.TopProperty, move);
            earnedCurrencyText.BeginAnimation(UIElement.OpacityProperty, fade);

            fade.Completed += (s, e) => MovingTextCanvas.Children.Remove(earnedCurrencyText);
        }

        private void Clicker_Area(object sender, RoutedEventArgs e)
        {
            classClicker.AddClicks(classClickPower.ClickPowerUp);
            TotalClicks.Text = classClicker.ClicksCurrency.ToString();

            MovingText();
        }

        private void Powerup_AutoClickX2(object sender, RoutedEventArgs e)
        {
            if(classClicker.ClicksCurrency >= autoClickX2.PowerupCost) // ser om du råd til det.
            {
                classClicker.ClicksCurrency -= autoClickX2.PowerupCost;
                /*
            if (!autoClick.IsPurchased)
            {
                MessageBox.Show("You must buy AutoClick first!");
            }
            else if (!game.BuyPowerup(autoClickX2))
            {
                MessageBox.Show("You don't have enough Clicks!");
            }
            else
            {
                autoClickX2.ActivateAutoClickX2(game, autoClick);
                AutoClickX2Button.IsEnabled = false;
                powerupTimer.Start();
            }
            */
            }
        }

        private void Powerup_DoubleClick(object sender, RoutedEventArgs e)
        {

        }

        private void Upgrade_AutoClick(object sender, RoutedEventArgs e)
        {
            /*
            if (!game.BuyUpgrade(autoClick))
            {
                MessageBox.Show("You don't have enough Clicks!");
            }
            else
            {
                autoClick.ActivateAutoClick(game);
                AutoClickButton.IsEnabled = false;
            }
            */
        }

        private void Upgrade_IncreaseClick(object sender, RoutedEventArgs e)
        {
            if(classClicker.ClicksCurrency >= classClickPower.UpgradePrice)
            {
                classClicker.ClicksCurrency -= classClickPower.UpgradePrice;
                classClickPower.UpgradeClicks();
                TotalClicks.Text = classClicker.ClicksCurrency.ToString("0.##");
          
                if(classClickPower.UpgradeCountClicks >= 50)
                {
                    classClickPower.UpgradePrice += 150;
                }
                else if (classClickPower.UpgradeCountClicks >= 10)
                {
                    classClickPower.UpgradePrice += 50;
                }
                else
                {
                    classClickPower.UpgradePrice += 10;
                }
                UpgradeClickButton.Content = $"Upgrade: {classClickPower.UpgradePrice} Clicks";

                // kunne bruge en switch expression istedet til dette vis det skulle se pænere ud.. men  jeg skal lige læse lidt videre på det.
            }
        }
    }
}