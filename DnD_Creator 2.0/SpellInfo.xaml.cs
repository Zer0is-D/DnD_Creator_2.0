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
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class SpellInfo : Window
    {
        public SpellInfo(Spells spell)
        {
            InitializeComponent();

            spellName.Text = spell.Name;
            spellScholl.Content = $"Школа: {spell.SchoolName}";
            spellLvl.Content = $"{spell.Lvl} уровень";
            spellDes.Text = spell.Description;
        }
    }
}
