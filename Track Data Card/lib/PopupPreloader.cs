using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Track_Data_Card.lib
{
    class PopupPreloader
    {
        public Grid popup { get; set; }
        public Label label { get; set; }

        public void displayNan()
        {
            popup.Visibility = System.Windows.Visibility.Hidden;
        }
        public void displayBlock(string str)
        {
            popup.Visibility = System.Windows.Visibility.Visible;
            label.Content = str;
        }
    }
}
