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
    /// Логика взаимодействия для UserControl4.xaml
    /// </summary>
    public partial class Counter : UserControl
    {
        public event EventHandler Increase;
        public event EventHandler Decrease;

        public int min => 8 + bonus;
        public int max => 15 + bonus;

        public int bonus;

        public int Value { get; set; }
        public int Modificate
        {
            get
            {
                int res = (Value - 10) / 2;
                if (Value == 9)
                {
                    res = -1;
                }

                return res;
            }
        }

        private Parametr _parametr;
        public Parametr Parametr
        {
            get => _parametr;
            set
            {
                _parametr = value;
            }
        }

        public int mod;

        public Counter()
        {
            InitializeComponent();
            Value = 8;
            Increase += Counter_Increase;
            Decrease += Counter_Decrease;
        }

        public Counter(Parametr parametr)
        {
            InitializeComponent();
            Value = 8;
            Parametr = parametr;
            Increase += Counter_Increase;
            Decrease += Counter_Decrease;
        }

        private void Counter_Increase(object sender, EventArgs e)
        {
            Minus.IsEnabled = true;
        }

        private void Counter_Decrease(object sender, EventArgs e)
        {
            Plus.IsEnabled = true;
        }

        public void Minus_Click(object sender, RoutedEventArgs e)
        {
            Val.Text = (--Value).ToString();
            Decrease(this, new EventArgs());
            UpdateModificate();
        }

        public void Plus_Click(object sender, RoutedEventArgs e)
        {
            Val.Text = (++Value).ToString();
            Increase(this, new EventArgs());
            UpdateModificate();
        }

        private void UpdateModificate()
        {
            modificate.Text = $"({((int)Modificate)})";
        }
    }
}
