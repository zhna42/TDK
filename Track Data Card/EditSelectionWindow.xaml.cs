using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Track_Data_Card.lib.export;

namespace Track_Data_Card
{
    /// <summary>
    /// Логика взаимодействия для EditSelectionWindow.xaml
    /// </summary>
    public partial class EditSelectionWindow : Window
    {
        List<AudioFiles> main;
        List<AudioFiles> copy;
        List<int> id;
        public EditSelectionWindow(List<int> i, List<AudioFiles> m, List<AudioFiles> c)
        {
            InitializeComponent();
            main = m;
            copy = c;
            id = i;
        }

        bool isUse1 = false, isUse2 = false, isUse3 = false;
        private void use1(object sender, RoutedEventArgs e)
        {
            isUse1 = !isUse1;
        }
        private void use2(object sender, RoutedEventArgs e)
        {
            isUse2 = !isUse3;
        }
        private void use3(object sender, RoutedEventArgs e)
        {
            isUse3 = !isUse3;
        }
        private void ok(object sender, RoutedEventArgs e)
        {
            Object objCategory = category.SelectedItem;
            Object objVersion = version.SelectedItem;
            string c = "";
            string v = "";
            if (objCategory != null)
                c = objCategory.ToString();
            if (objVersion != null)
                v = objVersion.ToString();

            foreach (int i in id)
            {
                //main[copy[i].id]
                if (isUse1)
                    main[copy[i].id].yearInt = Convert.ToUInt32(year.Text, 10);
                if (isUse2 && c != "")
                    main[copy[i].id].category = c;
                if (isUse3 && v != "")
                    main[copy[i].id].version = v;
                if (isUse1 || isUse2)
                    main[copy[i].id].tegs.Save();
            }
            this.Close();
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
