using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace ClickerGame
{
    internal class AutoClick : Upgrades
    {
        private DispatcherTimer timer;
        public bool IsPurchased { get; private set; } = false; 
        public AutoClick() : base(1000)
        {

        }
        public void ActivateAutoClick(Game game)
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
                game.Click();
            };

            timer.Start();
        }
    }
}