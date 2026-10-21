using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    internal class AutoClickX2 : Powerups
    {
        public AutoClickX2() : base(100)
        {
        }

        // This method activates the AutoClickX2 powerup
        public void ActivateAutoClickX2(Game game, AutoClick autoClick)
        {
            autoClick.SetSpeed(0.5);
        }
    }
}
