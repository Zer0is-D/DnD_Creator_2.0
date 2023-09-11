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
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class SpellAdd : Window
    {
        Create_Hero hero;
        DnDEntities entities = new DnDEntities();

        List<Spells> spells = new List<Spells>();

        public static int lvl1 = 0;
        public static int cantrip = 0;

        public SpellAdd(Create_Hero hero)
        {
            InitializeComponent();

            foreach (var item in entities.ClassHasMagic.Where(x => x.ClassID == hero.choosedClass.ID))
            {
                // Классы с формулами
                if (item.ClassID == 3 || item.ClassID == 4)
                {
                    lvl1 = hero.Wis.mod + 1;
                    cantrip = item.Cantrip;
                    cantripCount.Text = $"Макс. заговоров: {item.Cantrip}";
                    lvl1Count.Text = $"Макс. заклинаний: {(hero.Wis.mod + 1)}".ToString();
                }
                //  Остальные 
                else
                {
                    lvl1 = item.SpellCount;
                    cantrip = item.Cantrip;
                    cantripCount.Text = $"Макс. заговоров: {item.Cantrip}";
                    lvl1Count.Text = $"Макс. заклинаний: {item.SpellCount}";
                }
            }

            foreach (var item in entities.Spells)
            {
                if (item.Lvl < 2)
                {
                    PackSpells pack = new PackSpells(item, hero, false);
                    spellList.Items.Add(pack);
                    spells.Add(item);
                }
            }

            this.hero = hero;
        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {
            PackSpells pack1 = spellList.SelectedItem as PackSpells;

            if (pack1 != null)
            {
                foreach (var item in spells)
                {
                    if (item.ID == pack1.spell.ID)
                    {
                        if (hero.magic.SpellCount <= hero.mySpells.Items.Count && lvl1 >= 1)
                        {
                            PackSpells pack = new PackSpells(item, hero);
                            hero.mySpells.Items.Add(pack);
                            lvl1--;
                        }
                        if (hero.mySpells.Items.Count <= hero.magic.Cantrip && cantrip >= 1)
                        {
                            PackSpells pack = new PackSpells(item, hero);
                            hero.mySpells.Items.Add(pack);
                            cantrip--;
                        }
                        else
                            MessageBox.Show($"У вас максимальное кол. заклинаний! Макс. {entities.ClassHasMagic.Where(x => x.ClassID == hero.choosedClass.ID).FirstOrDefault().SpellCount}!");
                    }
                }
            }            
        }

        private void Back_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

