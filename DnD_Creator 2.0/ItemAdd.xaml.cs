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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class ItemAdd : Window
    {
        Create_Hero hero;
        DnDEntities entities = new DnDEntities();
        public ItemAdd(Create_Hero hero)
        {
            InitializeComponent();

            foreach (var item in entities.Items)
            {
                PackItems pack = new PackItems(item, hero, false);
                itemList.Items.Add(pack);
            }

            this.hero = hero;
        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {
            foreach (var item in entities.Items)
            {
                if (item.ID - 1 == itemList.SelectedIndex)
                {
                    if (item.Weight + hero.packWeight <= hero.heroMaxWeight)
                    {
                        hero.packWeight += item.Weight;

                        PackItems pack = new PackItems(item, hero);
                        hero.backpackItems.Items.Add(pack);
                        hero.items.Add(item);
                        hero.packWeightLabel.Content = $"{hero.packWeight}/{hero.heroMaxWeight}";
                    }
                    else
                        MessageBox.Show($"В переполнены! Макс. {hero.heroMaxWeight}!");
                }
            }
        }

        private void Back_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
