using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DnD_Creator_2
{
    public class CheckBoxAdapter : CheckBox
    {
        public Parametr Parametr { get; set; } 
    }

    public enum Parametr
    {
        Strength, Agility, Stamina, Intellect, Wisdom, Charisma
    }
}
