using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    internal class AutoClick : Upgrades
    {
        public AutoClick() : base(1000)
        {
            UpgradeCost = 1000;
        }
        public void ActivateAutoClick(Game game)
        {
            // Logic to activate auto-clicking
            // For example, you could start a timer that calls game.Click() at regular intervals
        }
    }
}