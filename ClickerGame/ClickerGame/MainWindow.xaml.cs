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
            UpgradeClickButton.Content = $"Upgrade: Increase Clicks\nPrice: {classClickPower.UpgradePrice.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"))} Clicks";

            AutoClickButton.Content = $"Upgrade: AutoClick\nPrice: {autoClick.UpgradeCost.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"))} Clicks";

            AutoClickX2Button.Content = $"Powerup: AutoClickX2\nPrice: {autoClickX2.PowerupCost.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"))} Clicks";
            
            displayTimer.Interval = TimeSpan.FromSeconds(0.1);

            displayTimer.Tick += (sender, e) =>
            {
                TotalClicks.Text = classClicker.ClicksCurrency.ToString("0.0");
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

        public void MovingText()
        {
            TextBlock earnedCurrencyText = new TextBlock
            {
                Text = $"+{1 + classClickPower.ClickPowerUp:0.##}",
                FontSize = 30
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

        public void Clicker_Area(object sender, RoutedEventArgs e)
        {
            classClicker.AddClicks(classClickPower.ClickPowerUp);
            MovingText();
        }

        private void Powerup_AutoClickX2(object sender, RoutedEventArgs e)
        {
            if (!autoClick.IsPurchased)
            {
                MessageBox.Show("You must buy AutoClick first!");
                return;
            }
            if (classClicker.ClicksCurrency < autoClickX2.PowerupCost && autoClick.IsPurchased)
            {
                MessageBox.Show("You don't have enough Clicks!");
                return;
            }

            classClicker.ClicksCurrency -= autoClickX2.PowerupCost;

            autoClickX2.ActivateAutoClickX2(autoClick);
            AutoClickX2Button.IsEnabled = false;
            powerupTimer.Start();
        }  

        private void Powerup_DoubleClick(object sender, RoutedEventArgs e)
        {

        }

        private void Upgrade_AutoClick(object sender, RoutedEventArgs e)
        {
           
            if (classClicker.ClicksCurrency < autoClick.UpgradeCost)
            {
                MessageBox.Show("You don't have enough Clicks!");
               
            }
            else if (classClicker.ClicksCurrency >= autoClick.UpgradeCost)
            {
                classClicker.ClicksCurrency -= autoClick.UpgradeCost;
                autoClick.ActivateAutoClick(classClicker, classClickPower);
                AutoClickButton.IsEnabled = false;
            }
        }
        private void Upgrade_IncreaseClick(object sender, RoutedEventArgs e)
        {
            if(classClicker.ClicksCurrency >= classClickPower.UpgradePrice)
            {
                classClicker.ClicksCurrency -= classClickPower.UpgradePrice;
                classClickPower.UpgradeClicks();
          
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
            UpgradeClickButton.Content = $"Upgrade: Increase Clicks\nPrice: {classClickPower.UpgradePrice.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("da-DK"))} Clicks";

                // kunne bruge en switch expression istedet til dette vis det skulle se pænere ud..
            }
        }
    }
}