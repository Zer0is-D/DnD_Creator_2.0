using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DnD_Creator_2
{
    public class HeroInfo
    {
        private string hero_name;
        public string Name_info
        {
            get => hero_name;
            set => hero_name = value;
        }

        private string hero_race;
        public string Race_info
        {
            get => hero_race;
            set => hero_race = value;
        }

        private string hero_class;
        public string Class_info
        {
            get => hero_class;
            set => hero_class = value;
        }

        private string worldview;
        public string Worldview
        {
            get => worldview;
            set => worldview = value;
        }

        private string origin;
        public string Origin
        {
            get => origin;
            set => origin = value;
        }

        //  Экипирвка
        private string armor;
        public string Armor
        {
            get => armor;
            set => armor = value;
        }

        private string iniciativa;
        public string Iniciativa
        {
            get => iniciativa;
            set => iniciativa = value;
        }

        private string speed;
        public string Speed
        {
            get => speed;
            set => speed = value;
        }

        //  Параметры
        private int strength;
        public int Strength
        {
            get => strength;
            set => strength = value;
        }

        private int agility;
        public int Agility
        {
            get => agility;
            set => agility = value;
        }

        private int stamina;
        public int Stamina
        {
            get => stamina;
            set => stamina = value;
        }

        private int intellect;
        public int Intellect
        {
            get => intellect;
            set => intellect = value;
        }

        private int wisdom;
        public int Wisdom
        {
            get => wisdom;
            set => wisdom = value;
        }

        private int charisma;
        public int Charisma
        {
            get => charisma;
            set => charisma = value;
        }

        //  Экипировано 
        private string weapon_left;
        public string Weapon_left
        {
            get => weapon_left;
            set => weapon_left = value;
        }

        private string weapon_right;
        public string Weapon_right
        {
            get => weapon_right;
            set => weapon_right = value;
        }

        private string armor_name;
        public string Armor_name
        {
            get => armor_name;
            set => armor_name = value;
        }

        //  Рюкзак
        private string[] backpack;
        public string[] Backpack
        {
            get => backpack;
            set => backpack = value;
        }

        private string[] magic;
        public string[] Magic
        {
            get => magic;
            set => magic = value;
        }
    }
}
