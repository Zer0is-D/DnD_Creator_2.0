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
    /// Логика взаимодействия для UserControl6.xaml
    /// </summary>
    public partial class PackSpells : UserControl
    {
        Create_Hero hero;
        public Spells spell;

        public PackSpells(Spells spell, Create_Hero hero, bool del_btn = true)
        {
            InitializeComponent();

            delete_btn.Visibility = (del_btn) ? Visibility.Visible : Visibility.Collapsed;

            spellName.Text = spell.Name;
            spellLvl.Content = spell.Lvl + " круг";


            this.spell = spell;
            this.hero = hero;
        }

        private void DelThisItem_btn(object sender, RoutedEventArgs e)
        {
            if (spell.Lvl > 0)
                SpellAdd.lvl1++;
            else
                SpellAdd.cantrip++;

            hero.mySpells.Items.Remove(this);
        }

        private void More_btn(object sender, RoutedEventArgs e)
        {
            new SpellInfo(spell).Show();
        }
    }
}
