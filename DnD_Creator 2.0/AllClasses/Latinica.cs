using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Creator_2._0.AllClasses
{
    internal class Latinica
    {
        public static Create_Hero ToLatin(Create_Hero hero)
        {
            switch (hero.choosenRace.Name)
            {
                case "Человек":
                    hero.choosenRace.Name = "Human";
                    break;
                case "Полуэльф":
                    hero.choosenRace.Name = "Halfelven";
                    break;
                case "Лесной эльф":
                    hero.choosenRace.Name = "Forest Elf";
                    break;
                case "Высший эльф":
                    hero.choosenRace.Name = "High Elf";
                    break;
                case "Дроу (Темный эльф)":
                    hero.choosenRace.Name = "Drow (Dark Elf)";
                    break;
                case "Горный дворф":
                    hero.choosenRace.Name = "Mountain Dwarf";
                    break;
                case "Холмовой  дворф":
                    hero.choosenRace.Name = "Hill Dwarf";
                    break;
                case "Каменный гном":
                    hero.choosenRace.Name = "Stone Dwarf";
                    break;
                case "Лесной гном":
                    hero.choosenRace.Name = "Forest Dwarf";
                    break;
                case "Легконогий полурослик":
                    hero.choosenRace.Name = "Light-footed halfling";
                    break;
                case "Коренастый полурослик":
                    hero.choosenRace.Name = "stocky halfling";
                    break;
                case "Тифлинг":
                    hero.choosenRace.Name = "Tiefling";
                    break;
                case "Полуорк":
                    hero.choosenRace.Name = "Half-Orc";
                    break;
                case "Драконо-рожденный":
                    hero.choosenRace.Name = "Dragonborn";
                    break;
            }

            switch (hero.choosenOrigin.Name)
            {
                case "Артист":
                    hero.choosenOrigin.Name = "Actor";
                    break;
                case "Беспризорник":
                    hero.choosenOrigin.Name = "Waif";
                    break;
                case "Благородный":
                    hero.choosenOrigin.Name = "Noble";
                    break;
                case "Гильдейский ремеслиник":
                    hero.choosenOrigin.Name = "Guild Craftsman";
                    break;
                case "Моряк":
                    hero.choosenOrigin.Name = "Sailor";
                    break;
                case "Мудрец":
                    hero.choosenOrigin.Name = "Wise man";
                    break;
                case "Народный герой":
                    hero.choosenOrigin.Name = "People's Hero";
                    break;
                case "Отшельник":
                    hero.choosenOrigin.Name = "Recluse";
                    break;
                case "Преступник":
                    hero.choosenOrigin.Name = "Criminal";
                    break;
                case "Священнослужитель":
                    hero.choosenOrigin.Name = "Clergyman";
                    break;
                case "Солдат":
                    hero.choosenOrigin.Name = "Soldier";
                    break;
                case "Чужеземец":
                    hero.choosenOrigin.Name = "Stranger";
                    break;
                case "Шарлатан":
                    hero.choosenOrigin.Name = "Charlatan";
                    break;
            }

            switch (hero.choosedClass.Class_name)
            {
                case "Варвар":                    
                    hero.choosedClass.Class_name = "Barbarian";
                    break;
                case "Бард":
                    hero.choosedClass.Class_name = "Bard";
                    break;
                case "Жрец":
                    hero.choosedClass.Class_name = "Cleric";
                    break;
                case "Друид":
                    hero.choosedClass.Class_name = "Druid";
                    break;
                case "Воин":
                    hero.choosedClass.Class_name = "Warrior";
                    break;
                case "Монах":
                    hero.choosedClass.Class_name = "Monk";
                    break;
                case "Паладин":
                    hero.choosedClass.Class_name = "Paladin";
                    break;
                case "Следопыт":
                    hero.choosedClass.Class_name = "Ranger";
                    break;
                case "Плут":
                    hero.choosedClass.Class_name = "Rouge";
                    break;
                case "Чародей":
                    hero.choosedClass.Class_name = "Warlock";
                    break;
                case "Колдун":
                    hero.choosedClass.Class_name = "Sorcerer";
                    break;
                case "Волшебник":
                    hero.choosedClass.Class_name = "Magician";
                    break;
            }

            switch (hero.Worldview_val.Text)
            {
                case "Мировоззрения: Законопослушный добрый":
                    hero.Worldview_val.Text = "Lawful Good";
                    break;
                case "Мировоззрения: Нейтральный добрый":
                    hero.Worldview_val.Text = "Neutral Good";
                    break;
                case "Мировоззрения: Хаотичный добрый":
                    hero.Worldview_val.Text = "Chaotic Good";
                    break;
                case "Мировоззрения: Законопослушный нейтральный":
                    hero.Worldview_val.Text = "Lawful Neutral";
                    break;
                case "Мировоззрения: Истинно нейтральный":
                    hero.Worldview_val.Text = "True Neutral";
                    break;
                case "Мировоззрения: Хаотичный нейтральный":
                    hero.Worldview_val.Text = "Chaotic Neutral";
                    break;
                case "Мировоззрения: Законопослушный злой":
                    hero.Worldview_val.Text = "Lawful Evil";
                    break;
                case "Мировоззрения: Нейтральный злой":
                    hero.Worldview_val.Text = "Neutral Evil";
                    break;
                case "Мировоззрения: Хаотически злой":
                    hero.Worldview_val.Text = "Chaotic Evil";
                    break;
            }

            switch (hero.Weapon_left_val.Content)
            {
                case "Боевой посох":
                    hero.Weapon_left_val.Content = "Battle Staff";
                    break;
                case "Булава":
                    hero.Weapon_left_val.Content = "Mace";
                    break;
                case "Дубинка":
                    hero.Weapon_left_val.Content = "Baton";
                    break;
                case "Кинжал":
                    hero.Weapon_left_val.Content = "Dagger";
                    break;
                case "Копьё":
                    hero.Weapon_left_val.Content = "Spear";
                    break;
                case "Лёгкий молот":
                    hero.Weapon_left_val.Content = "Light Hammer";
                    break;
                case "Метательное копьё":
                    hero.Weapon_left_val.Content = "Throwing Spear";
                    break;
                case "Палица":
                    hero.Weapon_left_val.Content = "Mace";
                    break;
                case "Ручной топор":
                    hero.Weapon_left_val.Content = "Hand Axe";
                    break;
                case "Серп":
                    hero.Weapon_left_val.Content = "Sickle";
                    break;
                case "Арбалет (лёгкий)":
                    hero.Weapon_left_val.Content = "Crossbow (light)";
                    break;
                case "Дротик":
                    hero.Weapon_left_val.Content = "Dart";
                    break;
                case "Короткий лук":
                    hero.Weapon_left_val.Content = "Short Bow";
                    break;
                case "Праща":
                    hero.Weapon_left_val.Content = "Sling";
                    break;
                case "Алебарда":
                    hero.Weapon_left_val.Content = "Halberd";
                    break;
                case "Боевая кирка":
                    hero.Weapon_left_val.Content = "Battle Pickaxe";
                    break;
                case "Боевой молот":
                    hero.Weapon_left_val.Content = "Battle Hammer";
                    break;
                case "Боевой топор":
                    hero.Weapon_left_val.Content = "Battle Axe";
                    break;
                case "Глефа":
                    hero.Weapon_left_val.Content = "Glaive";
                    break;
                case "Двуручный меч":
                    hero.Weapon_left_val.Content = "Two-handed sword";
                    break;
                case "Длинное копьё":
                    hero.Weapon_left_val.Content = "Long Spear";
                    break;
                case "Длинный меч":
                    hero.Weapon_left_val.Content = "The Long Sword";
                    break;
                case "Кнут":
                    hero.Weapon_left_val.Content = "The Whip";
                    break;
                case "Короткий меч":
                    hero.Weapon_left_val.Content = "Short Sword";
                    break;
                case "Молот":
                    hero.Weapon_left_val.Content = "Hammer";
                    break;
                case "Моргенштерн":
                    hero.Weapon_left_val.Content = "Morgenstern";
                    break;
                case "Пика":
                    hero.Weapon_left_val.Content = "Peak";
                    break;
                case "Рапира":
                    hero.Weapon_left_val.Content = "Rapier";
                    break;
                case "Секира":
                    hero.Weapon_left_val.Content = "Poleaxe";
                    break;
                case "Скимитар":
                    hero.Weapon_left_val.Content = "Scimitar";
                    break;
                case "Трезубец":
                    hero.Weapon_left_val.Content = "Trident";
                    break;
                case "Цеп":
                    hero.Weapon_left_val.Content = "Flail";
                    break;
                case "Арбалет (ручной)":
                    hero.Weapon_left_val.Content = "Crossbow (handed)";
                    break;
                case "Арбалет (тяжёлый)":
                    hero.Weapon_left_val.Content = "Crossbow (heavy)";
                    break;
                case "Длинный лук":
                    hero.Weapon_left_val.Content = "Long Bow";
                    break;
                case "Духовая трубка":
                    hero.Weapon_left_val.Content = "Blowpipe";
                    break;
                case "Сеть":
                    hero.Weapon_left_val.Content = "Net";
                    break;
                case "(Пусто)":
                    hero.Weapon_left_val.Content = "";
                    break;
            }

            switch (hero.Weapon_right_val.Content)
            {
                case "Боевой посох":
                    hero.Weapon_right_val.Content = "Battle Staff";
                    break;
                case "Булава":
                    hero.Weapon_right_val.Content = "Mace";
                    break;
                case "Дубинка":
                    hero.Weapon_right_val.Content = "Baton";
                    break;
                case "Кинжал":
                    hero.Weapon_right_val.Content = "Dagger";
                    break;
                case "Копьё":
                    hero.Weapon_right_val.Content = "Spear";
                    break;
                case "Лёгкий молот":
                    hero.Weapon_right_val.Content = "Light Hammer";
                    break;
                case "Метательное копьё":
                    hero.Weapon_right_val.Content = "Throwing Spear";
                    break;
                case "Палица":
                    hero.Weapon_right_val.Content = "Mace";
                    break;
                case "Ручной топор":
                    hero.Weapon_right_val.Content = "Hand Axe";
                    break;
                case "Серп":
                    hero.Weapon_right_val.Content = "Sickle";
                    break;
                case "Арбалет (лёгкий)":
                    hero.Weapon_right_val.Content = "Crossbow (light)";
                    break;
                case "Дротик":
                    hero.Weapon_right_val.Content = "Dart";
                    break;
                case "Короткий лук":
                    hero.Weapon_right_val.Content = "Short Bow";
                    break;
                case "Праща":
                    hero.Weapon_right_val.Content = "Sling";
                    break;
                case "Алебарда":
                    hero.Weapon_right_val.Content = "Halberd";
                    break;
                case "Боевая кирка":
                    hero.Weapon_right_val.Content = "Battle Pickaxe";
                    break;
                case "Боевой молот":
                    hero.Weapon_right_val.Content = "Battle Hammer";
                    break;
                case "Боевой топор":
                    hero.Weapon_right_val.Content = "Battle Axe";
                    break;
                case "Глефа":
                    hero.Weapon_right_val.Content = "Glaive";
                    break;
                case "Двуручный меч":
                    hero.Weapon_right_val.Content = "Two-handed sword";
                    break;
                case "Длинное копьё":
                    hero.Weapon_right_val.Content = "Long Spear";
                    break;
                case "Длинный меч":
                    hero.Weapon_right_val.Content = "The Long Sword";
                    break;
                case "Кнут":
                    hero.Weapon_right_val.Content = "The Whip";
                    break;
                case "Короткий меч":
                    hero.Weapon_right_val.Content = "Short Sword";
                    break;
                case "Молот":
                    hero.Weapon_right_val.Content = "Hammer";
                    break;
                case "Моргенштерн":
                    hero.Weapon_right_val.Content = "Morgenstern";
                    break;
                case "Пика":
                    hero.Weapon_right_val.Content = "Peak";
                    break;
                case "Рапира":
                    hero.Weapon_right_val.Content = "Rapier";
                    break;
                case "Секира":
                    hero.Weapon_right_val.Content = "Poleaxe";
                    break;
                case "Скимитар":
                    hero.Weapon_right_val.Content = "Scimitar";
                    break;
                case "Трезубец":
                    hero.Weapon_right_val.Content = "Trident";
                    break;
                case "Цеп":
                    hero.Weapon_right_val.Content = "Flail";
                    break;
                case "Арбалет (ручной)":
                    hero.Weapon_right_val.Content = "Crossbow (handed)";
                    break;
                case "Арбалет (тяжёлый)":
                    hero.Weapon_right_val.Content = "Crossbow (heavy)";
                    break;
                case "Длинный лук":
                    hero.Weapon_right_val.Content = "Long Bow";
                    break;
                case "Духовая трубка":
                    hero.Weapon_right_val.Content = "Blowpipe";
                    break;
                case "Сеть":
                    hero.Weapon_right_val.Content = "Net";
                    break;
                case "(Пусто)":
                    hero.Weapon_right_val.Content = "";
                    break;
            }


            return hero;
        }
    }
}
