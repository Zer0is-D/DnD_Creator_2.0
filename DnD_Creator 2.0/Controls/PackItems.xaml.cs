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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnD_Creator_2._0.Controls
{
    /// <summary>
    /// Логика взаимодействия для UserControl5.xaml
    /// </summary>
    public partial class PackItems : UserControl
    {
        Create_Hero hero;
        public Items items;

        public PackItems(Items items, Create_Hero hero, bool del_btn = true)
        {
            InitializeComponent();

            delete_btn.Visibility = (del_btn) ? Visibility.Visible : Visibility.Collapsed;

            itemName.Content = items.Name;
            itemWeight.Content = items.Weight + " фнт.";

            this.items = items;
            this.hero = hero;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hero.packWeight -= items.Weight;
            hero.packWeightLabel.Content = $"{hero.packWeight}/{hero.heroMaxWeight}";
            hero.backpackItems.Items.Remove(this);
        }
    }
}
