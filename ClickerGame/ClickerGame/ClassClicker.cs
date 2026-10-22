using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ClickerGame
{
    public class ClassClicker
    {
        public double ClicksCurrency { set; get;  }
        //ClassClicker classClicker = new ClassClicker();
        public void AddClicks(double extraPowerClicks)
        {
            ClicksCurrency += 1 + extraPowerClicks;
        }
    }
}
