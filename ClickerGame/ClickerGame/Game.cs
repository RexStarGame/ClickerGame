using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    public class Game
    {
        public int Currency { get; private set; } = 0;

        public int Clicks { get; private set; } = 1;

        public void Click()
        {
            Currency += Clicks;
        }
    }
}