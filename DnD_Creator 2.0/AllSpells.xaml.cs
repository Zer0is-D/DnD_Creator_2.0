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
    public partial class AllSpells : Window
    {
        DnDEntities entities = new DnDEntities();
        Spells spell;
        public AllSpells()
        {
            InitializeComponent();

            foreach (var item in entities.Spells)
            {
                ListSpell.Children.Add(new ButtonAdapter(item));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string select = (Lvl.SelectedItem as ComboBoxItem).Content.ToString();
            if (select == "Все")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells)
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "0")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 0))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "1")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 1))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "2")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 2))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "3")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 3))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "4")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 4))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "5")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 5))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "6")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 6))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "7")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 7))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "8")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 8))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
            if (select == "9")
            {
                ListSpell.Children.Clear();
                foreach (var item in entities.Spells.Where(x => x.Lvl == 9))
                {
                    ListSpell.Children.Add(new ButtonAdapter(item));
                }
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string select = (classSP.SelectedItem as ComboBoxItem).Content.ToString();
            switch (select)
            {
                case "Все":
                    ListSpell.Children.Clear();
                    foreach (var item in entities.Spells)
                    {
                        ListSpell.Children.Add(new ButtonAdapter(spell));
                    }
                    break;
                case "Бард":
                    ListSpell.Children.Clear();
                    foreach (var item in entities.SpellClass.Where(x => x.ClassID == 2).Select(x=>x.SpellID))
                    {
                        Spells spell = entities.Spells.Find(item);

                        ListSpell.Children.Add(new ButtonAdapter(spell));
                    }
                    break;
                case "Жрец":
                    ListSpell.Children.Clear();
                    foreach (var item in entities.SpellClass.Where(x => x.ClassID == 3).Select(x => x.SpellID))
                    {
                        Spells spell = entities.Spells.Find(item);

                        ListSpell.Children.Add(new ButtonAdapter(spell));
                    }
                    break;
                case "Друид":
                    ListSpell.Children.Clear();
                    foreach (var item in entities.SpellClass.Where(x => x.ClassID == 4).Select(x => x.SpellID))
                    {
                        Spells spell = entities.Spells.Find(item);

                        ListSpell.Children.Add(new ButtonAdapter(spell));
                    }
                    break;
                case "Чародей":
                    ListSpell.Children.Clear();
                    foreach (var item in entities.SpellClass.Where(x => x.ClassID == 10).Select(x => x.SpellID))
                    {
                        Spells spell = entities.Spells.Find(item);

                        ListSpell.Children.Add(new ButtonAdapter(spell));
                    }
                    break; 
                case "Колдун":
                    ListSpell.Children.Clear();
                    foreach (var item in entities.SpellClass.Where(x => x.ClassID == 11).Select(x => x.SpellID))
                    {
                        Spells spell = entities.Spells.Find(item);

                        ListSpell.Children.Add(new ButtonAdapter(spell));
                    }
                    break;
                case "Волшебник":
                    ListSpell.Children.Clear();
                    foreach (var item in entities.SpellClass.Where(x => x.ClassID == 12).Select(x => x.SpellID))
                    {
                        Spells spell = entities.Spells.Find(item);

                        ListSpell.Children.Add(new ButtonAdapter(spell));
                    }
                    break;
            }            
        }

        private void findSpell_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //ListSpell.Children.Clear();
            //foreach (var entity in entities.Spells.Where(x => x.Name.Contains(findSpell.Text)))
            //{
            //    ListSpell.Children.Add(new ButtonAdapter(spell));
            //}
        }
    }

    public class ButtonAdapter : Button
    {
        public Spells spells { get; set; }

        public ButtonAdapter(Spells spells) : base()
        {
            this.spells = spells;
            this.Click += ButtonAdapter_Click;
            this.Content = $"{spells.Name} | {spells.Lvl}-го круга";
            this.FontSize = 14;
            this.Height = 35;
            this.Margin = new Thickness(3);
        }

        private void ButtonAdapter_Click(object sender, RoutedEventArgs e)
        {
            new SpellInfo(spells).Show();
        }
    }
}
