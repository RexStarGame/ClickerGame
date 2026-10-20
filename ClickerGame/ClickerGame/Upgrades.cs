using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    internal class Upgrades
    {
        protected int UpgradeCost { get; set; }

        public Upgrades(int cost)
        {
            UpgradeCost = cost;
        }
    }
}