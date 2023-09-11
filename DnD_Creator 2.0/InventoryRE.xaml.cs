using DnD_Creator_2._0.Controls;
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

namespace DnD_Creator_2._0
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class InventoryRE : Window
    {
        public InventoryRE(Create_Hero hero)
        {
            InitializeComponent();

            foreach (var item in hero.items)
            {
                PackItems pack = new PackItems(item, hero);
                inventery.Items.Add(pack);
            }
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
             
        }
    }
}
