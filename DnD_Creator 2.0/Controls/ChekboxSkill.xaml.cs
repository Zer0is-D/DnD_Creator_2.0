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
    /// Логика взаимодействия для ChekboxSkill.xaml
    /// </summary>
    public partial class ChekboxSkill : UserControl
    {
        Create_Hero hero;
        Skills skill;
        bool click = true;

        public ChekboxSkill(Skills skills, Create_Hero hero)
        {
            InitializeComponent();            
            
            //checkSkill.IsChecked = skill.
            skillName.Text = skills.Name;

            this.hero = hero;
            this.skill = skills;
        }

        private void pointIt_Click(object sender, RoutedEventArgs e)
        {
            //  Красим выбранную кнопку
            if (hero.skillsCount > 0)
            {
                click = !click;

                if (click)
                    hero.skillsCount++;
                else
                    if (hero.skillsCount > 0)
                    hero.skillsCount--;

                hero.SkillAble.Content = $"Доступно на выбор: {hero.skillsCount}";

                this.pointIt.Background = click ? Brushes.White : Brushes.LightGreen;
            }
            else
            {

            }

        }
    }
}
