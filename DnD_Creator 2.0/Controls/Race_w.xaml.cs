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
    /// Логика взаимодействия для UserControl10.xaml
    /// </summary>
    public partial class Race_w : UserControl
    {
        DnDEntities entities = new DnDEntities();
        Races races;
        public Create_Hero hero { get; set; }

        public Race_w(Races races)
        {
            InitializeComponent();

            Race_name.Text = races.Name;
            if (races.Image != null)
                ImageLoader.LoadImage(races.Image, raceImg);
            this.races = races;
        }

        private void Des_btn(object sender, RoutedEventArgs e)
        {
            new Race_description(races).Show();
        }

        private void SelectThis(object sender, RoutedEventArgs e)
        {
            //  Красим выбранную кнопку
            foreach (Race_w item in hero.raceList)
            {
                item.chooseBtn.Background = Brushes.White;
            }
            this.chooseBtn.Background = Brushes.LightGreen;

            //  Присваеваем скорость расы
            hero.Speed_lab.Content = races.Speed;

            //  Сбрасываем параметры
            hero.points = 27;

            hero.Str.Value = 8;
            hero.Str.Val.Text = "8";
            hero.Str.Minus.IsEnabled = false;

            hero.Ag.Value = 8;
            hero.Ag.Val.Text = "8";
            hero.Ag.Minus.IsEnabled = false;

            hero.Sta.Value = 8;
            hero.Sta.Val.Text = "8";
            hero.Sta.Minus.IsEnabled = false;

            hero.Intel.Value = 8;
            hero.Intel.Val.Text = "8";
            hero.Intel.Minus.IsEnabled = false;

            hero.Wis.Value = 8;
            hero.Wis.Val.Text = "8";
            hero.Wis.Minus.IsEnabled = false;

            hero.Cha.Value = 8;
            hero.Cha.Val.Text = "8";
            hero.Cha.Minus.IsEnabled = false;





            //  Для полуэльфов
            //if (races.ID == 2)
            //{
            //    foreach (Counter item in hero.param_panel.Children)
            //    {
            //        item.IsElif.Visibility = Visibility.Visible;
            //    }
            //}
            //else
            //{
            //    foreach (Counter item in hero.param_panel.Children)
            //    {
            //        item.IsElif.Visibility = Visibility.Hidden;
            //    }
            //}

            //  Сохроняем расу
            hero.choosenRace = races;
            hero.Race_val.Text = $"Раса: {races.Name}";

            //  Прибавляем параметры выбранной расы
            int raceID = races.ID;

            foreach (var item in entities.RaceSpells.Where(x => x.RaceID == raceID))
            {
                foreach (var spell in entities.Spells.Where(x => x.ID == item.SpellID))
                {
                    hero.labelSp.Text += $"{spell.Name}";
                }
            }

            foreach (var item in entities.RaceParam.Where(x => x.RaceID == raceID))
            {
                switch (item.Param)
                {
                    case "Сила":
                        hero.Str.Value += item.Bonus;
                        hero.Str.bonus = item.Bonus;
                        hero.Str.Val.Text = hero.Str.Value.ToString();
                        break;

                    case "Ловкость":
                        hero.Ag.Value += item.Bonus;
                        hero.Ag.bonus = item.Bonus;
                        hero.Ag.Val.Text = hero.Ag.Value.ToString();
                        break;

                    case "Выносливость":
                        hero.Sta.Value += item.Bonus;
                        hero.Sta.bonus = item.Bonus;
                        hero.Sta.Val.Text = hero.Sta.Value.ToString();
                        break;

                    case "Интеллект":
                        hero.Intel.Value += item.Bonus;
                        hero.Intel.bonus = item.Bonus;
                        hero.Intel.Val.Text = hero.Intel.Value.ToString();
                        break;

                    case "Мудрость":
                        hero.Wis.Value += item.Bonus;
                        hero.Wis.bonus = item.Bonus;
                        hero.Wis.Val.Text = hero.Wis.Value.ToString();
                        break;

                    case "Харизма":
                        hero.Cha.Value += item.Bonus;
                        hero.Cha.bonus = item.Bonus;
                        hero.Cha.Val.Text = hero.Cha.Value.ToString();
                        break;
                }
            }

            hero.raceSkills.Clear();
            foreach (var item in entities.RaceSkills.Where(x => x.RaceID == raceID))
            {
                hero.raceSkills.Add(item.SkillID);
            }
            hero.method();

            foreach (var item in entities.ClassHasMagic)
            {

            }
        }
    }
}
