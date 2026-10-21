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

        // This method activates the AutoClickX2 powerup, which doubles the speed of the AutoClick feature in the game.
        public void ActivateAutoClickX2(Game game, AutoClick autoClick)
        {
            autoClick.SetSpeed(0.5);
        }
    }
}
