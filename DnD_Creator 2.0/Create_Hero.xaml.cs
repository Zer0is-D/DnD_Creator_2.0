using DnD_Creator_2._0.Controls;
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
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using Label = System.Windows.Controls.Label;
using CheckBox = System.Windows.Controls.CheckBox;
using Button = System.Windows.Controls.Button;

namespace DnD_Creator_2._0
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Create_Hero : Window
    {
        DnDEntities entities;

        #region Вкладка Заклинания
        int num = 0;
        string[] images_Url =
        {
            "1.png",
            "2.png",
        };
        #endregion

        //  Очки параметров
        public int points = 27;
        public int masterBonus = 2;
        public int skillsCount = 0;
        public bool PointItSkill = false;
        public double packWeight;
        public int heroMaxWeight 
        {
            get
            {
                int res = Str.Value * 15;
                
                return res;
            }
        }
        public bool ww_bool = false;

        public Classes choosedClass;
        public Races choosenRace;
        public Origins choosenOrigin;
        public ClassHasMagic magic;

        public List<Items> items = new List<Items>();

        public List<UIElement> raceList = new List<UIElement>();
        public List<UIElement> classList = new List<UIElement>();

        public List<int> raceSkills = new List<int>();
        public List<int> classSkills = new List<int>();
        public List<int> originSkills = new List<int>();

        public List<ChekboxSkill> AllSkills = new List<ChekboxSkill>();

        public Create_Hero()
        {
            InitializeComponent();

            this.entities = new DnDEntities();

            //Загрузка рас в список
            foreach (var item in entities.Races)
            {
                Race_w race = new Race_w(item) { hero = this };
                raceList.Add(race);
            }
            PageRace.Elements = raceList;

            //Загрузка классов в список
            foreach (var item in entities.Classes)
            {
                Class_w classes = new Class_w(item) { hero = this };
                classList.Add(classes);
            }
            PageClass.Elements = classList;

            //Загрузка происхождений в список
            foreach (var item in entities.Origins)
            {
                Label ori = new Label() { Content = item.Name, FontSize = 18 };
                origins.Items.Add(ori);
            }

            foreach (var item in entities.Skills)
            {
                ChekboxSkill box = new ChekboxSkill(item, this);                

                if (item.ID < 19)
                {
                    Skills_panel.Items.Add(box);
                    box.pointIt.IsEnabled = false;
                }

                AllSkills.Add(box);
            }

            #region Привязка параметров
            //Прараметры
            Param_points.Content = $"Очки: {points}";

            Str.Parametr = Parametr.Strength;
            Str.Header.Content = "Сила";

            Ag.Parametr = Parametr.Agility;
            Ag.Header.Content = "Ловкость";

            Sta.Parametr = Parametr.Stamina;
            Sta.Header.Content = "Выносливость";

            Intel.Parametr = Parametr.Intellect;
            Intel.Header.Content = "Интеллект";

            Wis.Parametr = Parametr.Wisdom;
            Wis.Header.Content = "Мудрость";

            Cha.Parametr = Parametr.Charisma;
            Cha.Header.Content = "Харизма";

            foreach (Counter c in param_panel.Children)
            {
                c.Increase += Increase;
                c.Decrease += Decrease;
            }

            #endregion

            //Загрузка оружия в комбобоксы
            foreach (var item in entities.Weapons)
            {
                Weapon_left.Items.Add(item.Name);
                Weapon_right.Items.Add(item.Name);
            }

            foreach (var item in entities.Armor)
            {
                Armorbox.Items.Add($"{item.Name} КД: {item.ArmorClass}");
            }

            packWeightLabel.Content = $"{packWeight}/{heroMaxWeight}";
        }

        #region Параметры
        private void Decrease(object sender, EventArgs e)
        {
            Counter s = sender as Counter;

            if (s.Value > 12)
                points += 2;
            else if (points >= 2)
                points++;

            if (s.Value == s.min)
                s.Minus.IsEnabled = false;

            foreach (Counter c in param_panel.Children)
                c.Plus.IsEnabled = c.Value < c.max;

            Param_points.Content = $"Очки: {points}";
            ModificateTree();
        }

        private void Increase(object sender, EventArgs e)
        {
            Counter s = sender as Counter;

            if (points > 0)
            {
                if (s.Value < 14)
                    points--;
                else if (points >= 2)
                    points -= 2;

                if (s.Value == s.max)
                    s.Plus.IsEnabled = false;

                if (points < 1)
                {
                    foreach (Counter c in param_panel.Children)
                        c.Plus.IsEnabled = false;
                }
            }

            Param_points.Content = $"Очки: {points}";
            ModificateTree();
        }

        

        //  Обновление параметров в случаи изменение
        private string RaceSkillsTreeFormula(Counter counter)
        {
            string s = counter.Modificate.ToString();

            if (choosenRace != null)
            {
                foreach (var skills in entities.Skills.Where(x => x.ID < 19))
                {
                    foreach (var item in entities.RaceSkills.Where(x => x.RaceID == choosenRace.ID))
                    {
                        if (skills.ID == item.SkillID)
                            s = (counter.mod + masterBonus).ToString();
                        //else
                        //    s = (counter.mod).ToString();
                    }
                }
            }

            return s;
        }
        private string OriginSkillsTreeFormula(Counter counter)
        {
            string s = counter.Modificate.ToString();

            if (choosenOrigin != null)
            {
                foreach (var skills in entities.Skills.Where(x => x.ID < 19))
                {
                    foreach (var item in entities.OriginSkill.Where(x => x.OriginID == choosenOrigin.ID))
                    {
                        if (skills.ID == item.Skills.ID)
                            s = (counter.mod + masterBonus).ToString();
                        //else
                        //    s = (counter.mod).ToString();
                    }
                }
            }

            return s;
        }

        //  Обновление параметров в случаи изменение
        private void ModificateTree()
        {
            Str_tree.Header = $"Сила: {Str.Value}";
            Athletic_val.Content = RaceSkillsTreeFormula(Str);
            packWeightLabel.Content = $"{packWeight}/{heroMaxWeight}";

            Ag_tree.Header = $"Ловкость: {Ag.Value}";
            Acrobatic_val.Content = RaceSkillsTreeFormula(Ag);
            HandAgility_val.Content = RaceSkillsTreeFormula(Ag);
            Sneak_val.Content = RaceSkillsTreeFormula(Ag);

            //  Инициатива
            Iniciativa_lab.Content = Ag.mod.ToString();

            Sta_tree.Header = $"Выносливость: {Sta.Value}";

            Intel_tree.Header = $"Интеллект: {Intel.Value}";
            Magic_val.Content = RaceSkillsTreeFormula(Intel);
            History_val.Content = RaceSkillsTreeFormula(Intel);
            Detectiv_val.Content = RaceSkillsTreeFormula(Intel);
            Nature_val.Content = RaceSkillsTreeFormula(Intel);
            Religion_val.Content = RaceSkillsTreeFormula(Intel);

            Wis_tree.Header = $"Мудрость: {Wis.Value}";
            Training_val.Content = RaceSkillsTreeFormula(Wis);
            Proniciats_val.Content = RaceSkillsTreeFormula(Wis);
            Medicine_val.Content = RaceSkillsTreeFormula(Wis);
            Perception_val.Content = RaceSkillsTreeFormula(Wis);
            Survive_val.Content = RaceSkillsTreeFormula(Wis);

            Cha_tree.Header = $"Харизма: {Cha.Value}";
            Lie_val.Content = RaceSkillsTreeFormula(Cha);
            Terror_val.Content = RaceSkillsTreeFormula(Cha);
            Acting_val.Content = RaceSkillsTreeFormula(Cha);
            Conviction_val.Content = RaceSkillsTreeFormula(Cha);

            //  Проверка для оружия
        }
        #endregion

        //Мировоззрение
        private void Worldview_btn(object sender, RoutedEventArgs e)
        {
            Worldview.Content = ((sender as Button).Content as TextBlock).Text;
            Worldview_val.Text = $"Мировоззрения: {Worldview.Content}";
            ww_bool = true;
        }

        //  Выбранные предыстории
        private void origins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DnDEntities entities = new DnDEntities();
            int ID = 0;

            foreach (var item in entities.Origins)
            {
                if (item.ID - 1 == origins.SelectedIndex)
                {
                    oriDes.Text = item.Descriptions;
                    Backstory_val.Text = $"Предыстория: {item.Name}";
                    ID = item.ID - 1;
                    choosenOrigin = entities.Origins.Find(ID);
                }
            }

            originSkills.Clear();
            foreach (var i in entities.OriginSkill.Where(x => x.OriginID == ID))
            {
                originSkills.Add(i.OriginID);
            }

            foreach (ChekboxSkill item in Skills_panel.Items)
            {
                item.IsEnabled = true;
            }
            method();
        }

        //  Выбранные навыки
        private void Skills_panel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DnDEntities entities = new DnDEntities();

            foreach (var item in entities.Skills)
            {
                if (item.ID - 1 == Skills_panel.SelectedIndex)
                {
                    skillDes.Text = item.Description;
                }
            }
        }

        #region Кнопки слайдера
        private void Btn_next(object sender, RoutedEventArgs e)
        {
            num++;
            if (num >= images_Url.Length)
                num = 0;

            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug", "NewFolder1\\" + images_Url[num]);
            pic.Source = new BitmapImage(new Uri(path));
        }

        private void Btn_last(object sender, RoutedEventArgs e)
        {
            num--;
            if (num < 0)
                num = images_Url.Length - 1;

            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug", "NewFolder1\\" + images_Url[num]);
            pic.Source = new BitmapImage(new Uri(path));
        }
        #endregion

        //  Добавить предмет в рюкзак
        private void Add_item(object sender, RoutedEventArgs e)
        {
            new ItemAdd(this).Show();
        }

        //  Левая рука
        private void Weapon_left_Selected(object sender, RoutedEventArgs e)
        {
            foreach (var item in entities.Weapons)
            {
                if (item.ID - 1 == Weapon_left.SelectedIndex)
                {
                    if (item.Fencing.Value && Ag.Modificate >= Str.Modificate)
                        Weapon_left_hit.Content = $"{item.Damage} + {Ag.Modificate + masterBonus}";
                    else
                        Weapon_left_hit.Content = $"{item.Damage} + {Str.Modificate + masterBonus}";

                    Weapon_left_val.Content = item.Name;
                    Weapon_left_damag.Content = Weapon_left_hit.Content;
                }
            }
        }

        //  Правая рука
        private void Weapon_right_Selected(object sender, RoutedEventArgs e)
        {
            foreach (var item in entities.Weapons)
            {
                if (item.ID - 1 == Weapon_right.SelectedIndex)
                {
                    if (item.Fencing.Value && Ag.Modificate >= Str.Modificate)
                        Weapon_right_hit.Content = $"{item.Damage} + {Ag.Modificate + masterBonus}";
                    else
                        Weapon_right_hit.Content = $"{item.Damage} + {Str.Modificate + masterBonus}";

                    Weapon_right_val.Content = item.Name;
                    Weapon_right_damag.Content = Weapon_right_hit.Content;
                }
            }
        }

        //  Броня
        private void Armorbox_Selected(object sender, RoutedEventArgs e)
        {
            foreach (var item in entities.Armor)
            {
                if (item.ID - 1 == Armorbox.SelectedIndex)
                {
                    Armor_m.Content = $"{item.ArmorClass}";

                    Armor_name.Content = item.Name;
                    Armor_val.Content = item.ArmorClass;
                    Armor_lab.Content = item.ArmorClass;
                }
            }
        }

        private void Inventory_btn(object sender, RoutedEventArgs e)
        {
            new Inventory(this).Show();
        }

        private void AddSpell(object sender, RoutedEventArgs e)
        {
            new SpellAdd(this).Show();
        }

        public void method()
        {
            List<int> list = new List<int>();

            if (classSkills != null)
                foreach (var item in classSkills)
                {
                    var a = entities.Skills.Find(item);
                    var b = entities.SkillClass.Where(x => x.ClassID == choosedClass.ID && x.SkillID == a.ID).FirstOrDefault();

                    AllSkills[item - 1].checkSkill.IsEnabled = true;
                    AllSkills[item - 1].checkSkill.IsChecked = false;
                    AllSkills[item - 1].pointIt.IsEnabled = true;
                }

            if (originSkills != null)
                foreach (var item in originSkills)
                {
                    var a = entities.Skills.Find(item);
                    var b = entities.OriginSkill.Where(x => x.OriginID == choosenOrigin.ID && x.OriginSkill1 == a.ID).FirstOrDefault();

                    AllSkills[item - 1].checkSkill.IsEnabled = false;
                    AllSkills[item - 1].checkSkill.IsChecked = true;
                    AllSkills[item - 1].pointIt.IsEnabled = false;
                }

            if (raceSkills != null)
                foreach (var item in raceSkills)
                {
                    var a = entities.Skills.Find(item);
                    var b = entities.RaceSkills.Where(x => x.RaceID == choosenRace.ID && x.SkillID == a.ID).FirstOrDefault();

                    AllSkills[item - 1].checkSkill.IsEnabled = b.IsChoosable.Value;
                    AllSkills[item - 1].checkSkill.IsChecked = !b.IsChoosable.Value;
                    AllSkills[item - 1].pointIt.IsEnabled = b.IsChoosable.Value;
                }

            if (classSkills != null)
            {
                foreach(var item in classSkills)
                {
                    var a = entities.Skills.Find(item);
                    var b = entities.SkillClass.Where(x => x.ClassID == choosedClass.ID && x.SkillID == a.ID).FirstOrDefault();

                    if (AllSkills[item - 1].IsEnabled)
                    {
                        AllSkills[item - 1].pointIt.Click += PointIt_Click;
                    }
                }
            }
        }

        private void PointIt_Click(object sender, RoutedEventArgs e)
        {
            //PointItSkill = !PointItSkill;

            //if (PointItSkill)
            //    skillsCount--;
            //else
            //    skillsCount++;

            
        }

        public void BonusSpell(List<int> list)
        {
            foreach (var item in list)
            {
                var a = entities.Skills.Where(x => x.ID == item).Select(x => x.Name);
                foreach (var i in a)
                {
                    if (item < 19)
                        Skills_panel.Items.Add(i);
                }
            }
            var dis = list.Distinct().ToList();
        }

        //  Кнопки формы
        //  Переход на главную
        private void ToMainMenu_btn(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        //  Создание персонажа
        private void SaveCharector(object sender, RoutedEventArgs e)
        {
            //string pathTxt = $"{Cha_name.Text}.txt";
            //string pathXML = $"{Cha_name.Text}.xml";

            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.Desktop,
                ShowNewFolderButton = true
            };

            var res = dialog.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                bool[] CHECK = new bool[7];

                CHECK[0] = choosenRace != null;
                CHECK[1] = choosedClass != null;
                CHECK[2] = points == 0;
                CHECK[3] = ww_bool;
                CHECK[4] = originSkills != null;
                CHECK[5] = Cha_name != null;
                CHECK[6] = skillsCount == 0;
                

                if (CHECK.All(x => x))
                {
                    Hero.Method(this);
                    MessageBox.Show("Персонаж успешно сохранен!");
                    new MainWindow().Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Не все обязательные данные были заполнены", "Ошибка");

            }
        }
        private void RaceWhat_btn(object sender, RoutedEventArgs e)
        {
            string s = "Каждый персонаж принадлежит к одной из множества разумных гуманоидных рас мира D&D.\n" +
                "Наиболее распространёнными расами игровых персонажей являются дварфы, эльфы, полурослики и\n" +
                "люди. Некоторые расы также имеют подрасы,\n" +
                "например, горный дварф или лесной эльф. А также\n" +
                "других менее распространенных расах: драконорождённых, гномах, полуэльфах, полуорках и тифлингах.\n" +
                "Раса, которую вы выбрали, придаёт индивидуальность вашему персонажу, определяя характерную внешность и врождённые таланты, полученные через культуру и происхождение. Раса вашего\n" +
                "персонажа даёт определённые расовые особенности, такие как: особые чувства, владение несколькими видами оружия или инструментов, владение\n" +
                "одним или несколькими навыками, а также возможность использовать простейшие заклинания.\n" +
                "Эти особенности иногда хорошо сочетаются со\n" +
                "способностями некоторых классов.\n" +
                "Например, особенности расы легконогих полуросликов делают их исключительными плутами, а высшие эльфы, как правило, становятся могущественными волшебниками. Иногда поступать не по шаблонам тоже может быть весело. Полуорк паладин\n" +
                "и горный дварф волшебник, например, могут быть\n" +
                "необычными, но запоминающимися персонажами.\n" +
                "Ваша раса также увеличивает одно или несколько значений характеристик, которые вы\n" +
                "определите позже.";
            MessageBox.Show(s, "Справка");
        }
        private void ClassWhat_btn(object sender, RoutedEventArgs e)
        {
            string s = "Каждый искатель приключений — представитель\n" +
                "какого - либо класса.Класс в общих чертах описывает призвание персонажа, таланты, которыми он\n" +
                "обладает, и тактики, к которым он чаще всего\n" +
                "прибегает, когда исследует подземелье, сражается\n" +
                "с монстрами или участвует в напряжённых переговорах.\n" +
                "Ваш персонаж получает ряд преимуществ от выбранного вами класса. Множество этих преимуществ\n" +
                "являются классовыми умениями — возможностями\n" +
                "(включая чтение заклинаний), которые отличают вашего персонажа от представителей других классов.\n" +
                "Вы также получаете перечень владения (умение\n" +
                "пользоваться) доспехами, оружием, навыками, спасбросками и иногда инструментами. Владение определяет многое из того, что ваш персонаж может делать особенно хорошо: применять в бою определённые виды оружия или убедительно лгать.";
            MessageBox.Show(s, "Справка");
        }
        private void ParamWhat_btn(object sender, RoutedEventArgs e)
        {
            string s = "Многое из того, что ваш персонаж способен сделать в игре, зависит от его шести характеристик:\n" +
                "Силы, Ловкости, Телосложения, Интеллекта, Мудрости и Харизмы. ФИЗИЧЕСКИЕ И УМСТВЕННЫЕ СПОСОБНОСТИ любого существа можно описать с\n" +
                "помощью шести характеристик: \n" +
                "• Сила, измеряющая физическую мощь\n" +
                "• Ловкость, измеряющая проворство\n" +
                "• Телосложение, измеряющая выносливость\n" +
                "• Интеллект, измеряющий рассудительность и память\n" +
                "• Мудрость, измеряющая внимательность и проницательность\n" +
                "• Харизма, измеряющая силу характера\n" +
                "Какой ваш персонаж, мускулистый и проницательный? Умный и очаровательный? Ловкий и стойкий? Значения характеристик помогают оценить эти качества — сильные стороны и недостатки существ.";
            MessageBox.Show(s, "Справка");
        }
        private void WorldVWhat_btn(object sender, RoutedEventArgs e)
        {
            string s = "Выберите его мировоззрение (моральный компас, который руководит его решениями)\n" +
                "Большинство рас имеют склонность к определённому мировоззрению. Это никак не ограничивает вашего персонажа, но осознание, почему вопреки строго законопослушному обществу ваш дварф вырос хаотичным, поможет вам лучше вжиться в роль.";
            MessageBox.Show(s, "Справка");
        }
        private void OriginWhat_btn(object sender, RoutedEventArgs e)
        {
            string s = "Предыстория вашего персонажа описывает\n" +
                "его родину, первоначальную специальность и место персонажа в мире D&D. Предыстория также\n" +
                "может быть доработана, чтобы точнее подходить\n" +
                "концепции вашего персонажа.\n" +
                "Предыстория даёт вашему персонажу особые\n" +
                "умения и владение двумя навыками, а также может предоставлять знание дополнительных языков или владение некоторыми видами инструментов";
            MessageBox.Show(s, "Справка");
        }
        private void SkillsWhat_btn(object sender, RoutedEventArgs e)
        {
            string s = "Характеристики покрывают широкий диапазон\n" +
                "возможностей, включая навыки, которыми персонаж или чудовище может владеть. Навык отражает некий аспект характеристики, а владение\n" +
                "навыком демонстрирует сосредоточенность на\n" +
                "этом аспекте (владения навыками персонажа\n" +
                "определяются при его создании, а владения навыками чудовища написаны в блоке его статистики).\n" +
                "Например, Ловкость может отражать попытку\n" +
                "персонажа выполнить акробатический трюк, стащить предмет, или остаться скрытым. У этих аспектов Ловкости есть три конкретных навыка: Акробатика, Ловкость рук и Скрытность, соответственно. Таким образом, персонаж, владеющий\n" +
                "навыком Скрытность, особенно хорошо совершает\n" +
                "проверки Ловкости, связанные с попытками вести\n" +
                "себя тихо и оставаться незамеченным.\n" +
                "Навыки, связанные с характеристиками, показаны в приведённой таблице (с Телосложением не\n" +
                "связан ни один навык).";
            MessageBox.Show(s, "Справка");
        }
        private void SpellWhat_btn(object sender, RoutedEventArgs e)
        {
            string s = "Заклинание это единый магический эффект, магическая энергия, пропитывающая мультивселенную,\n" +
                "сформированная в конкретное обличье. Накладывая\n" +
                "заклинание, персонаж бережно хватает невидимые\n" +
                "пряди сырой магии, пропитывающей мир, переплетает их особым узором, заставляет вибрировать, а потом отпускает, вызывая желаемый эффект — чаще\n" +
                "всего всё это происходит за доли секунды.\n" +
                "Заклинания могут быть универсальными инструментами, оружием, и даже защитой. Они могут причинять и устранять урон, накладывать и снимать состояния, вытягивать жизненную энергию и возвращать к жизни.\n" +
                "За ход истории мультивселенной было создано\n" +
                "бессчётное множество заклинаний, и большая их\n" +
                "часть давно забыта. Часть из них записана в ветхих книгах, лежащих в древних руинах, или заперта в сознании мёртвых богов. Они могут быть\n" +
                "повторно изобретены персонажем, накопившим\n" +
                "нужную энергию и мудрость для понимания.";
            MessageBox.Show(s, "Справка");
        }
    }
}
