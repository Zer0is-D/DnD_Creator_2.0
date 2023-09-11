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
    public partial class All_things : Window
    {
        public All_things()
        {
            InitializeComponent();
        }

        public All_things(HeroInfo heroInfo)
        {
            InitializeComponent();
        }

        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Edit_btn(object sender, RoutedEventArgs e)
        {
            new All_thingsRE().Show();
        }

        private void Del_btn(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить этого персонажа", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Персонаж успешно удален");
            }
        }
    }
}
