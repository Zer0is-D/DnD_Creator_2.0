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

namespace DnD_Creator_2._0
{
    /// <summary>
    /// Логика взаимодействия для PagePanel1.xaml
    /// </summary>
    public partial class PagePanel : UserControl
    {
        private List<UIElement> elements;

        public List<UIElement> Elements
        {
            get => elements;
            set
            {
                elements = value;
                MainPart.Items.Clear();

                panels = new List<ListBox>();

                for (int i = 0; i < elements.Count; i++)
                {
                    (elements[i] as UserControl).Width = 130;
                    (elements[i] as UserControl).Height = 200;
                    (elements[i] as UserControl).Margin = new Thickness(1, 0, 1, 5);

                    if ((i % 4) == 0)
                    {
                        panels.Add(new ListBox() { VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });

                        MainPart.Items.Add(panels[panels.Count - 1]);
                    }

                    panels[panels.Count - 1].Items.Add(elements[i]);
                }
            }
        }

        private List<ListBox> panels;
        public List<ListBox> Panels => panels;

        public PagePanel()
        {
            InitializeComponent();
        }

        public PagePanel(List<UIElement> list)
        {
            InitializeComponent();
            Elements = list;
        }
    }
}
