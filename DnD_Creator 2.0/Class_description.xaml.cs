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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Class_description : Window
    {
        DnDEntities entities = new DnDEntities();
        Chosable chosable = new Chosable();

        public Class_description(Classes classes)
        {
            InitializeComponent();

            className.Content = classes.Class_name;
            if (classes.Image != null)
                ImageLoader.LoadImage(classes.Image, classImg);
            classDes.Text = classes.Class_description;
        }

        public Class_description(Classes classes, string specName)
        {
            InitializeComponent();

            className.Content = classes.Class_name;
            classDes.Text = classes.Class_description;

            foreach (var c in entities.Spec)
            {
                if (specName == c.Name)
                {
                    classDes.Text += c.Description;
                }
            }
        }
    }
}
