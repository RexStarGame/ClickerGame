using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    public class Upgrades
    {
        public int UpgradeCost { get; set; }

        public Upgrades(int cost)
        {
            UpgradeCost = cost;
        }
    }
}