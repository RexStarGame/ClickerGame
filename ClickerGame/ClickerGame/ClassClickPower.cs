using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    public class ClassClickPower
    {
        public double ClickPowerUp {  get; set; }
        public double UpgradePrice { get; set; } = 2;
        public double UpgradeCountClicks { get; set; }

        public double CurrentPowwerUp { get; set; } = 0; 
        public void UpgradeClicks()
        {
            ClickPowerUp += 0.2;
           
            UpgradeCountClicks++;
        }
        public void Test()
        {
            ClickPowerUp = CurrentPowwerUp;
        }
    }
}
