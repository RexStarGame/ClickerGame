using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    internal class ClassClickPower
    {
        public double ClickPowerUp {  get; set; }
        public double UpgradePrice { get; set; } = 2;
        public double UpgradeCountClicks { get; set; }
        public void UpgradeClicks()
        {
            ClickPowerUp += 0.2;
            UpgradeCountClicks++;
        }
    }
}
