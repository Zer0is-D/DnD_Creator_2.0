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
    public partial class Charectors : Window
    {
        public Charectors()
        {
            InitializeComponent();

            char_panel.Elements = new List<UIElement>
            {
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
                new Charector() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2), Margin = new Thickness(5,5,5,5)},
            };
        }
    }
}
