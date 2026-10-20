using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    public class Game
    {
        public int TotalClicks { get; private set; } = 0;

        public int ClickValue { get; private set; } = 1;

        public void Click()
        {
            TotalClicks += ClickValue;
        }

        public bool BuyUpgrade(Upgrades upgrade)
        {
            if (TotalClicks >= upgrade.UpgradeCost)
            {
                TotalClicks -= upgrade.UpgradeCost;
                return true;
            }
            return false;
        }
    }
}