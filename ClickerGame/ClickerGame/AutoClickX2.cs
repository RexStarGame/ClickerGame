using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    internal class AutoClickX2 : Powerups
    {
        // Constructor for the AutoClickX2 class that initializes the power-up with a cost of 500 clicks.
        public AutoClickX2() : base(500)
        {
        }
        // Sets the speed of the AutoClick instance to 0.5 seconds per click.
        public void ActivateAutoClickX2(AutoClick autoClick)
        {
            autoClick.SetSpeed(0.5);
        }
    }
}
