using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    public class ClassClickPower : Upgrades
    {
        public double ClickPowerUp {  get; set; }
        public double UpgradeCountClicks { get; set; }
        public ClassClickPower() : base(2)
        {
        }
        public void UpgradeClicks()
        {
            ClickPowerUp += 0.2;
           
            UpgradeCountClicks++;
        }
    }
}
