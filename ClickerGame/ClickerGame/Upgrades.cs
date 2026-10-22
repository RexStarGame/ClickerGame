using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    public class Upgrades
    {
        public int UpgradeCost { get; private set; }
        public double UpgradePrice { get; set; } = 2;


        public Upgrades(int cost)
        {
            UpgradeCost = cost;
        }
    }
}