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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnD_Creator_2._0.Controls
{
    /// <summary>
    /// Логика взаимодействия для UserControl3.xaml
    /// </summary>
    public partial class Class_w : UserControl
    {
        DnDEntities entities = new DnDEntities();
        Classes classes;
        public Create_Hero hero { get; set; }

        public Class_w(Classes classes)
        {
            InitializeComponent();

            foreach (var item in entities.Chosable)
            {
                if (item.ClassID == classes.ID)
                {
                    foreach (var c in entities.Spec)
                    {
                        if (item.SpecID == c.ID)
                            chosableBox.Items.Add(c.Name);
                    }
                }
            }

            if (chosableBox.Items.Count <= 1)
                chosableBox.Visibility = Visibility.Collapsed;

            class_name.Text = classes.Class_name;
            if (classes.Image != null)
                ImageLoader.LoadImage(classes.Image, classImg);

            this.classes = classes;
        }

        private void Des_btn(object sender, RoutedEventArgs e)
        {
            if (chosableBox.Visibility == Visibility.Visible)
                new Class_description(classes, chosableBox.SelectedItem.ToString()).Show();
            else
                new Class_description(classes).Show();
        }

        private void SelectThis(object sender, RoutedEventArgs e)
        {
            //  Красим выбранную кнопку
            foreach (Class_w item in hero.classList)
            {
                item.chooseBtn.Background = Brushes.White;
            }
            this.chooseBtn.Background = Brushes.LightGreen;

            //  Сохраняем класс
            hero.choosedClass = classes;
            hero.skillsCount = hero.choosedClass.SkillCount.Value;
            hero.SkillAble.Content = $"Доступно на выбор: {hero.skillsCount}";

            //  Загрузка навыков класса
            int ID = hero.choosedClass.ID;          

            hero.classSkills.Clear();
            foreach (var item in entities.SkillClass.Where(x => x.ClassID == ID))
            {
                hero.classSkills.Add(item.SkillID);
            }
            hero.method();

            //  Доступ к заклинаниям
            hero.SpellEn.IsEnabled = false;

            var a = entities.ClassHasMagic.Where(x => x.ClassID == hero.choosedClass.ID).FirstOrDefault();
            if (a != null)
            {
                if (hero.choosedClass.ID == a.ClassID)
                {
                    hero.SpellEn.IsEnabled = true;
                    hero.magic = a;
                }
            }

            hero.Class_val.Text = $"Класс: {classes.Class_name}";
        }
    }
}
