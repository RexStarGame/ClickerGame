using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ClickerGame
{
    internal class ClassClicker
    {
        public double ClicksCurrency { set; get;  }

        public void AddClicks(double extraPowerClicks)
        {
            ClicksCurrency += 1 + extraPowerClicks;
        }
    }
}
