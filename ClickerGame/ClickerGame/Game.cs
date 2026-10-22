using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    public class Game
    {

        public double ClicksCurrency { set; get; }

        public void AddClicks(double extraPowerClicks)
        {
            ClicksCurrency += 1 + extraPowerClicks;
        }
    }
}
/*
public bool BuyUpgrade(Upgrades upgrade)
{
    if (TotalClicks >= upgrade.UpgradeCost)
    {
        TotalClicks -= upgrade.UpgradeCost;
        return true;
    }
    return false;
}

public bool BuyPowerup(Powerups powerup)
{
    if (TotalClicks >= powerup.PowerupCost)
    {
        TotalClicks -= powerup.PowerupCost;
        return true;
    }
    return false;
}
}
}
*/