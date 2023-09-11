using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace DnD_Creator_2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create_btn(object sender, RoutedEventArgs e)
        {
            new Create_Hero().Show();
            this.Close();
        }

        private void All_heroes(object sender, RoutedEventArgs e)
        {
            new All_things().Show();
            this.Close();

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "XML files (*.xml)|*.xml";

            //if (openFileDialog.ShowDialog() == true)
            //{
            //    HeroInfo heroInfo = new HeroInfo();

            //    //XDocument document = new XDocument.Load("");

            //   
            //    this.Close();
            //}           
        }

        private void Spell_btn(object sender, RoutedEventArgs e)
        {
            new AllSpells().Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
