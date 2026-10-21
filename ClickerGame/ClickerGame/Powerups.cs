using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    public class Powerups
    {
        public int PowerupCost { get; private set; }

        public TimeSpan Duration { get; private set; }

        public Powerups(int cost)
        {
            PowerupCost = cost;
            Duration = TimeSpan.FromMinutes(5);
        }
    }
}