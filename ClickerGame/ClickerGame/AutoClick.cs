using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace ClickerGame
{
    internal class AutoClick : Upgrades
    {
        private DispatcherTimer timer;
        public bool IsPurchased { get; private set; } = false;
       
        public AutoClick() : base(10)
        {
        }

        public void ActivateAutoClick(ClassClicker classClicker)
        {
            MainWindow mainWindow = new MainWindow();
            ClassClickPower classClickPower = new ClassClickPower();
            if (timer != null)
            {
                return;
            }

            IsPurchased = true;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (sender, e) =>
            {
                classClicker.AddClicks(classClickPower.CurrentPowwerUp);  
            };

            timer.Start();
        }

        public void SetSpeed(double seconds)
        {
            if (timer == null)
            {
                return;
            }

            timer.Interval = TimeSpan.FromSeconds(seconds);
        }
    }
}