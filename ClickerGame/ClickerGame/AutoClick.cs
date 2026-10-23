using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ClickerGame
{
    internal class AutoClick : Upgrades
    {
        // DispatcherTimer to handle auto-clicking
        private DispatcherTimer timer;
        // Property to indicate whether the auto-click upgrade has been purchased
        public bool IsPurchased { get; private set; } = false;
        // Constructor to initialize the auto-click upgrade with a cost of 1200
        public AutoClick() : base(1200)
        {

        }
        // Method to activate auto-clicking
        public void ActivateAutoClick(ClassClicker classClicker, ClassClickPower classClickPower)
        {
            if (timer != null)
            {
                return;
            }

            IsPurchased = true;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += (sender, e) =>
            {
                classClicker.AddClicks(classClickPower.ClickPowerUp);  
            };

            timer.Start();
        }
        // Method to set the speed of auto-clicking
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