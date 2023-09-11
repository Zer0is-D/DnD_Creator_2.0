using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DnD_Creator_2._0.Controls;

namespace DnD_Creator_2._0
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CheckBoxAdapter[] SkillBoxes { get; } = new CheckBoxAdapter[]
        {
            new CheckBoxAdapter(){ Content = "Атлетика", Parametr = Parametr.Strength },
            new CheckBoxAdapter(){ Content = "Акробатика", Parametr = Parametr.Agility },
            new CheckBoxAdapter(){ Content = "Скрытность", Parametr = Parametr.Agility},
            new CheckBoxAdapter(){ Content = "Ловкость рук", Parametr = Parametr.Agility},
            new CheckBoxAdapter(){ Content = "Магия", Parametr = Parametr.Intellect},
            new CheckBoxAdapter(){ Content = "История", Parametr = Parametr.Intellect},
            new CheckBoxAdapter(){ Content = "Религия", Parametr = Parametr.Intellect},
            new CheckBoxAdapter(){ Content = "Природа", Parametr = Parametr.Intellect},
            new CheckBoxAdapter(){ Content = "Расследование", Parametr = Parametr.Intellect},
            new CheckBoxAdapter(){ Content = "Дресировка", Parametr = Parametr.Wisdom},
            new CheckBoxAdapter(){ Content = "Внимание", Parametr = Parametr.Wisdom},
            new CheckBoxAdapter(){ Content = "Проницательность", Parametr = Parametr.Wisdom},
            new CheckBoxAdapter(){ Content = "Медецина", Parametr = Parametr.Wisdom},
            new CheckBoxAdapter(){ Content = "Выживание", Parametr = Parametr.Wisdom},
            new CheckBoxAdapter(){ Content = "Убеждение", Parametr = Parametr.Charisma},
            new CheckBoxAdapter(){ Content = "Обман", Parametr = Parametr.Charisma},
            new CheckBoxAdapter(){ Content = "Запугивание", Parametr = Parametr.Charisma},
            new CheckBoxAdapter(){ Content = "Выступление", Parametr = Parametr.Charisma},
        };
    }
}
