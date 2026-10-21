using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ClickerGame
{
    internal class ClassClicker
    {
        public int ClicksCurrency { set; get;  }

        public void AddClicks ()
        {
            ClicksCurrency++;
        }
    }
}
