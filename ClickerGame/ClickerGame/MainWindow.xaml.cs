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

namespace ClickerGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassClicker classClicker = new ClassClicker(); // opretter et object af klassen ClassClicker
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken;

        private bool pressed = false;
        public MainWindow()
        {
            InitializeComponent();
            cancellationToken = cancellationTokenSource.Token;
        }
        private void Clicker_Button(object sender, RoutedEventArgs e)
        {
            classClicker.AddClicks(); 
            TotalCookiesText.Text = classClicker.ClicksCurrency.ToString();

            MovingText();
        }

        private void MovingText()
        {
            TextBlock earnedCurrencyText = new TextBlock
            {
                Text = "+1",
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