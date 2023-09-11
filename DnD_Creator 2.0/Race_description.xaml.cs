using DnD_Creator_2._0.AllClasses;
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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Race_description : Window
    {
        public Race_description()
        {
            InitializeComponent();
        }

        public Race_description(Races races)
        {
            InitializeComponent();

            raceName.Content = races.Name;
            if (races.Image != null)
                ImageLoader.LoadImage(races.Image, raceImg);
            raceDes.Text = races.Description;
        }
    }
}
