using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Data.SqlClient;
using System.Xml.Serialization;
using DnD_Creator_2._0;
using DnD_Creator_2._0.Controls;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
using PdfDocument = Spire.Pdf.PdfDocument;
using DnD_Creator_2._0.AllClasses;

namespace DnD_Creator_2
{
    public class Hero
    {
        public static void SaveAsTxt(Create_Hero hero, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLineAsync($"Имя: {hero.Cha_name.Text}\n" +
                                            //$"Age: {hero.Age}\n"
                                            $"{hero.Race_val.Text}\n" +
                                            $"{hero.Class_val.Text}\n" +
                                            $"{hero.Worldview_val.Text}\n" +
                                            $"{hero.Backstory_val.Text}\n\n" +

                                            $"Характеристики\n" +
                                            $"КД: {hero.Armor_lab.Content}\n" +
                                            $"Инциатива: {hero.Iniciativa_lab.Content}\n" +
                                            $"Скорость: {hero.Speed_lab.Content}\n\n" +

                                            $"Сила: {hero.Str.Value} {hero.Str.Modificate}\n" +
                                            $"Ловкость: {hero.Ag.Value} {hero.Ag.Modificate}\n" +
                                            $"Выносливость: {hero.Sta.Value} {hero.Sta.Modificate}\n" +
                                            $"Интеллект: {hero.Intel.Value} {hero.Intel.Modificate}\n" +
                                            $"Мудрость: {hero.Wis.Value} {hero.Wis.Modificate}\n" +
                                            $"Харизма: {hero.Cha.Value} {hero.Cha.Modificate}\n\n" +

                                            $"Левая рука: {hero.Weapon_left_val.Content} {hero.Weapon_left_damag.Content}\n" +
                                            $"Правая рука: {hero.Weapon_right_val.Content} {hero.Weapon_right_damag.Content}\n" +
                                            $"Броня: {hero.Armor_name.Content} {hero.Armor_val.Content}\n");

                    foreach (PackItems item in hero.backpackItems.Items)
                    {
                        sw.WriteLineAsync($"{item.items.Name} {item.items.Weight}");
                    }

                    if (hero.mySpells.Items != null)
                    {
                        foreach (PackSpells item in hero.mySpells.Items)
                            sw.WriteLineAsync($"{item.spell.Name} {item.spell.Lvl}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        public static void SaveAsXML(Create_Hero hero, string path)
        {
            HeroInfo heroInfo = new HeroInfo();
            XmlSerializer sr = new XmlSerializer(heroInfo.GetType());
            
            heroInfo.Name_info = hero.Cha_name.Text;

            heroInfo.Race_info = hero.Race_val.Text;
            heroInfo.Class_info = hero.Class_val.Text;
            heroInfo.Worldview = hero.Worldview_val.Text;
            heroInfo.Origin = hero.Backstory_val.Text;

            heroInfo.Armor = hero.Armor_lab.Content.ToString();
            heroInfo.Iniciativa = hero.Iniciativa_lab.Content.ToString();
            heroInfo.Speed = hero.Speed_lab.Content.ToString();

            heroInfo.Strength = hero.Str.Value;
            heroInfo.Agility = hero.Ag.Value;
            heroInfo.Stamina = hero.Sta.Value;
            heroInfo.Intellect = hero.Intel.Value;
            heroInfo.Wisdom = hero.Wis.Value;
            heroInfo.Charisma = hero.Cha.Value;

            heroInfo.Weapon_left = hero.Weapon_left_val.Content.ToString();
            heroInfo.Weapon_right = hero.Weapon_right_val.Content.ToString();
            heroInfo.Armor_name = hero.Armor_name.Content.ToString();

            heroInfo.Backpack = new string[hero.backpackItems.Items.Count];

            for (int i = 0; i < heroInfo.Backpack.Length; i++)
            {
                heroInfo.Backpack[i] = $"{(hero.backpackItems.Items[i] as PackItems).items.Name} {(hero.backpackItems.Items[i] as PackItems).items.Weight}" ;
            }

            heroInfo.Magic = new string[hero.mySpells.Items.Count];

            for (int i = 0; i < heroInfo.Magic.Length; i++)
            {
                heroInfo.Magic[i] = $"{(hero.mySpells.Items[i] as PackSpells).spell.Name} {(hero.mySpells.Items[i] as PackSpells).spell.Lvl}";
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sr.Serialize(sw, heroInfo);
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        public static void Method(Create_Hero hero)
        {
            DnDEntities entities = new DnDEntities();
            Latinica.ToLatin(hero);

            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"C:\Users\Admin\source\repos\DnD_Creator 2.0\DnD_Creator 2.0\PDF\List_personazhaRU.pdf");
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;
                    switch (textBoxField.Name)
                    {
                        //  Передача в utf-8
                        # region Основное
                        case "CharacterName":                            
                            textBoxField.Text = "";
                            break;
                        case "ClassLevel#0":
                            textBoxField.Text = hero.choosedClass.Class_name;
                            break;
                        case "Background":
                            textBoxField.Text = hero.choosenOrigin.Name;
                            break;
                        case "PlayerName":
                            textBoxField.Text = "";
                            break;
                        case "Race ":
                            textBoxField.Text = hero.choosenRace.Name;
                            break;
                        case "Alignment":
                            textBoxField.Text = hero.Worldview_val.Text;
                            break;
                        case "XP":
                            textBoxField.Text = "0";
                            break;
                        #endregion

                        # region Параметры 
                        case "STR":
                            textBoxField.Text = hero.Str.Value.ToString();
                            break;
                        case "STRmod":
                            textBoxField.Text = hero.Str.Modificate.ToString();
                            break;
                        case "DEX":
                            textBoxField.Text = hero.Ag.Value.ToString();
                            break;
                        case "DEXmod ":
                            textBoxField.Text = hero.Ag.Modificate.ToString();
                            break;
                        case "CON":
                            textBoxField.Text = hero.Sta.Value.ToString();
                            break;
                        case "CONmod":
                            textBoxField.Text = hero.Sta.Modificate.ToString();
                            break;
                        case "INT":
                            textBoxField.Text = hero.Intel.Value.ToString();
                            break;
                        case "INTmod":
                            textBoxField.Text = hero.Intel.Modificate.ToString();
                            break;
                        case "WIS":
                            textBoxField.Text = hero.Wis.Value.ToString();
                            break;
                        case "WISmod":
                            textBoxField.Text = hero.Wis.Modificate.ToString();
                            break;
                        case "CHA":
                            textBoxField.Text = hero.Cha.Value.ToString();
                            break;
                        case "CHamod":
                            textBoxField.Text = hero.Cha.Modificate.ToString();
                            break;
                        #endregion

                        //  Вдохновение и бонус мастерства
                        case "Inspiration":
                            textBoxField.Text = "";
                            break;
                        case "ProfBonus":
                            textBoxField.Text = hero.masterBonus.ToString();
                            break;

                        #region Спасброски
                        case "ST Strength":
                            textBoxField.Text = hero.Str.Modificate.ToString(); 
                            break;
                        case "ST Dexterity":
                            textBoxField.Text = hero.Ag.Modificate.ToString(); 
                            break;
                        case "ST Constitution":
                            textBoxField.Text = hero.Sta.Modificate.ToString(); 
                            break;
                        case "ST Intelligence":
                            textBoxField.Text = hero.Intel.Modificate.ToString(); 
                            break;
                        case "ST Wisdom":
                            textBoxField.Text = hero.Wis.Modificate.ToString(); 
                            break;
                        case "ST Charisma":
                            textBoxField.Text = hero.Cha.Modificate.ToString(); 
                            break;
                        #endregion
                        //  Разобраться с Investigation и 

                        #region Навыки
                        case "Acrobatics":
                            foreach (Skills item in entities.Skills) 
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Ag.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Ag.Modificate.ToString();
                                }                                
                            }
                            break;
                        case "Animal"://    Investigation
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Intel.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Intel.Modificate.ToString();
                                }
                            }
                            
                            break;
                        case "Arcana"://    Athletics\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Str.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Str.Modificate.ToString();
                                }
                            }
                            
                            break;
                        case "Athletics":// Perception\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Wis.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Wis.Modificate.ToString();
                                }
                            }
                            
                            break;
                        case "Deception "://    Survival
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Wis.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Wis.Modificate.ToString();
                                }

                            }
                            
                            break;
                        case "History "://  Performance\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Cha.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Cha.Modificate.ToString();
                                }
                            }
                            
                            break;
                        case "Insight"://   Intimidation\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Cha.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Cha.Modificate.ToString();
                                }
                            }
                           
                            break;
                        case "Intimidation"://  History\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Intel.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Intel.Modificate.ToString();
                                }
                            }
                     
                            break;
                        case "Investigation "://    SleightofHand
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Ag.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Ag.Modificate.ToString();
                                }
                            }
                      
                            break;
                        case "Medicine"://  Arcana\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Intel.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Intel.Modificate.ToString();
                                }
                            }
                        
                            break;
                        case "Nature"://    Medicine\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Wis.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Wis.Modificate.ToString();
                                }
                            }
                          
                            break;
                        case "Perception "://   Deception\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Cha.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Cha.Modificate.ToString();
                                }
                            }
                     
                            break;
                        case "Performance"://   Nature\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Intel.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Intel.Modificate.ToString();
                                }
                            }
                         
                            break;
                        case "Persuasion"://    Insight\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Wis.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Wis.Modificate.ToString();
                                }
                            }
                   
                            break;
                        case "Religion":
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Intel.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Intel.Modificate.ToString();
                                }
                            }
                      
                            break;
                        case "SleightofHand":// Stealth\
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Ag.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Ag.Modificate.ToString();
                                }
                            }
                            
                            break;
                        case "Stealth "://  Persuasion
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Cha.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Cha.Modificate.ToString();
                                }
                            }
                  
                            break;
                        case "Survival"://  Animal
                            foreach (Skills item in entities.Skills)
                            {
                                foreach (ChekboxSkill skill in hero.Skills_panel.Items)
                                {
                                    if (skill.checkSkill.IsChecked.Value)
                                        textBoxField.Text = (hero.Wis.Modificate + hero.masterBonus).ToString();
                                    else
                                        textBoxField.Text = hero.Wis.Modificate.ToString();
                                }
                            }                    
                            break;
                        #endregion

                        //  Пассивная мудрость и владения
                        case "Passive":
                            textBoxField.Text = hero.Wis.Value.ToString();
                            break;
                        case "ProficienciesLang":
                            foreach (PackItems item in hero.backpackItems.Items)
                            {
                                textBoxField.Text = item.Name.ToString();
                            }
                            textBoxField.Text += "\n";
                            //foreach (PackItems item in hero.backpackItems.Items)
                            //{
                            //    textBoxField.Text = item.Name.ToString();
                            //}
                            break;

                        #region Здоровье и особенности
                        case "AC":
                            textBoxField.Text = hero.Armor_val.Content.ToString();
                            break;
                        case "Initiative":
                            textBoxField.Text = hero.Iniciativa_lab.Content.ToString();
                            break;
                        case "Speed":
                            textBoxField.Text = hero.Speed_lab.Content.ToString();
                            break;

                        case "HPMax":
                            textBoxField.Text = (hero.Sta.Value + 5).ToString();
                            break;
                        case "HPCurrent":
                            textBoxField.Text = (hero.Sta.Value + 5).ToString();
                            break;
                        case "HPTemp":
                            textBoxField.Text = "0";
                            break;

                        case "HDTotal":
                            textBoxField.Text = "1";
                            break;
                        case "HD":
                            textBoxField.Text = "1d10";
                            break;

                        //  Спасброски от смерти

                        #endregion

                        #region Атаки и оружие
                        case "Wpn Name":
                            textBoxField.Text = hero.Weapon_right_val.Content.ToString();
                            break;
                        case "Wpn1 AtkBonus":
                            textBoxField.Text = (hero.Str.Modificate + hero.masterBonus).ToString();
                            break;
                        case "Wpn1 Damage":
                            textBoxField.Text = hero.Weapon_left_damag.Content.ToString();
                            break;

                        case "Wpn Name 2":
                            textBoxField.Text = hero.Weapon_right_val.Content.ToString();
                            break;
                        case "Wpn2 AtkBonus ":
                            textBoxField.Text = (hero.Str.Modificate + hero.masterBonus).ToString();
                            break;
                        case "Wpn2 Damage ":
                            textBoxField.Text = hero.Weapon_right_damag.Content.ToString();
                            break;

                        //case "Wpn Name 3":
                        //    textBoxField.Text = "Wpn Name 3";
                        //    break;
                        //case "Wpn3 AtkBonus  ":
                        //    textBoxField.Text = (hero.Str.Modificate + hero.masterBonus).ToString();
                        //    break;
                        //case "Wpn3 Damage ":
                        //    textBoxField.Text = "Wpn3 Damage";
                        //    break;

                        case "AttacksSpellcasting":
                            textBoxField.Text = "";
                            break;
                        #endregion

                        #region Деньги и снаряжение
                        case "CP":
                            textBoxField.Text = "0";
                            break;
                        case "SP":
                            textBoxField.Text = "0";
                            break;
                        case "EP":
                            textBoxField.Text = "0";
                            break;
                        case "GP":
                            textBoxField.Text = "10";
                            break;
                        case "PP":
                            textBoxField.Text = "0";
                            break;
                        case "Equipment":
                            textBoxField.Text = "short sword short bow and quiver with 20 arrows\n" +
                            "dungeon explorer's set\n" +
                            "Leather armor\n" +
                            " two daggers\n" +
                            "thieves' tools";
                            break;
                        #endregion

                        //  Свойства личности
                        case "PersonalityTraits ":
                            textBoxField.Text = "";
                            break;
                        case "Ideals":
                            textBoxField.Text = "";
                            break;
                        case "Bonds":
                            textBoxField.Text = "";
                            break;
                        case "Flaws":
                            textBoxField.Text = "";
                            break;

                        //  Особенности
                        case "Features and Traits":
                            textBoxField.Text = "";
                            break;

                        #region Чекбоксы
                        case "Check Box 11":
                            textBoxField.Text = "Check Box 11";
                            break;
                        case "Check Box 12":
                            textBoxField.Text = "Check Box 12";
                            break;
                        case "Check Box 13":
                            textBoxField.Text = "Check Box 13";
                            break;
                        case "Check Box 14":
                            textBoxField.Text = "Check Box 14";
                            break;
                        case "Check Box 15":
                            textBoxField.Text = "Check Box 15";
                            break;
                        case "Check Box 16":
                            textBoxField.Text = "Check Box 16";
                            break;
                        case "Check Box 17":
                            textBoxField.Text = "Check Box 17";
                            break;
                        case "Check Box 18":
                            textBoxField.Text = "Check Box 18";
                            break;
                        case "Check Box 19":
                            textBoxField.Text = "Check Box 19";
                            break;
                        case "Check Box 20":
                            textBoxField.Text = "Check Box 20";
                            break;
                        case "Check Box 21":
                            textBoxField.Text = "Check Box 21";
                            break;
                        case "Check Box 22":
                            textBoxField.Text = "Check Box 22";
                            break;
                        case "Check Box 23":
                            textBoxField.Text = "Check Box 23";
                            break;
                        case "Check Box 24":
                            textBoxField.Text = "Check Box 24";
                            break;
                        case "Check Box 25":
                            textBoxField.Text = "Check Box 25";
                            break;
                        case "Check Box 26":
                            textBoxField.Text = "Check Box 26";
                            break;
                        case "Check Box 27":
                            textBoxField.Text = "Check Box 27";
                            break;
                        case "Check Box 28":
                            textBoxField.Text = "Check Box 28";
                            break;
                        case "Check Box 29":
                            textBoxField.Text = "Check Box 29";
                            break;
                        case "Check Box 30":
                            textBoxField.Text = "Check Box 30";
                            break;
                        case "Check Box 31":
                            textBoxField.Text = "Check Box 31";
                            break;
                        case "Check Box 32":
                            textBoxField.Text = "Check Box 32";
                            break;
                        case "Check Box 33":
                            textBoxField.Text = "Check Box 33";
                            break;
                        case "Check Box 34":
                            textBoxField.Text = "Check Box 34";
                            break;
                        case "Check Box 35":
                            textBoxField.Text = "Check Box 35";
                            break;
                        case "Check Box 36":
                            textBoxField.Text = "Check Box 36";
                            break;
                        case "Check Box 37":
                            textBoxField.Text = "Check Box 37";
                            break;
                        case "Check Box 38":
                            textBoxField.Text = "Check Box 38";
                            break;
                        case "Check Box 39":
                            textBoxField.Text = "Check Box 39";
                            break;
                        case "Check Box 40":
                            textBoxField.Text = "Check Box 40";
                            break;
                        #endregion

                        //  Страница 2
                        #region Основа
                        case "CharacterName 2":
                            textBoxField.Text = "Character Name";
                            break;

                        case "Age":
                            textBoxField.Text = "";
                            break;
                        case "Height":
                            textBoxField.Text = "";
                            break;
                        case "Weight":
                            textBoxField.Text = "";
                            break;
                        case "Eyes":
                            textBoxField.Text = "";
                            break;
                        case "Skin":
                            textBoxField.Text = "";
                            break;
                        case "Hair":
                            textBoxField.Text = "";
                            break;
                        #endregion

                        //  Внешка и предыстория
                        //case "CHARACTER IMAGE":
                        //    textBoxField.Text = "CHARACTER IMAGE";
                        //    break;
                        case "Backstory":
                            textBoxField.Text = "";
                            break;

                        //  Фракция
                        case "FactionName":
                            textBoxField.Text = "";
                            break;
                        case "Faction Symbol Image":
                            textBoxField.Text = "";
                            break;
                        case "Allies":
                            textBoxField.Text = "";
                            break;

                        //  Доп умения
                        case "Feat+Traits":
                            textBoxField.Text = "";
                            break;

                        //  Сокровища
                        case "Treasure":
                            textBoxField.Text = "";
                            break;

                        //  ХЗ
                        case "CHARACTER IMAGE.CHARACTER IMAGE0":
                            textBoxField.Text = "";
                            break;
                        case "CHARACTER IMAGE.CHARACTER IMAGE0#0":
                            textBoxField.Text = "";
                            break;

                        //  Страница 3
                        //  Основное
                        //case "Spellcasting Class 2":
                        //    textBoxField.Text = "Spellcasting Class";
                        //    break;

                        //case "SpellcastingAbility 2":
                        //    textBoxField.Text = "SpellcastingAbility 2";
                        //    break;
                        //case "SpellSaveDC  2":
                        //    textBoxField.Text = "SpellSaveDC  2";
                        //    break;
                        //case "SpellAtkBonus 2":
                        //    textBoxField.Text = "SpellAtkBonus 2";
                        //    break;

                        ////  Заговоры
                        //case "Spells 1014":
                        //    textBoxField.Text = "Spells 1014";
                        //    break;
                        //case "Spells 1016":
                        //    textBoxField.Text = "Spells 1016";
                        //    break;
                        //case "Spells 1017":
                        //    textBoxField.Text = "Spells 1017";
                        //    break;
                        //case "Spells 1018":
                        //    textBoxField.Text = "Spells 1018";
                        //    break;

                        ////  Кол ячеек и потраченные 1 круга
                        //case "SlotsTotal 19":
                        //    textBoxField.Text = "SlotsTotal 19";
                        //    break;
                        //case "SlotsRemaining 19":
                        //    textBoxField.Text = "0";
                        //    break;

                        //case "Spells 1015":
                        //    textBoxField.Text = "Spells 1015";
                        //    break;
                        //case "Spells 1023":
                        //    textBoxField.Text = "Spells 1023";
                        //    break;
                        //case "Spells 1024":
                        //    textBoxField.Text = "Spells 1024";
                        //    break;
                        //case "Spells 1025":
                        //    textBoxField.Text = "Spells 1025";
                        //    break;
                    }
                }
                if (field is PdfDocumentInformation)
                {
                    PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;
                    switch (listBoxField.Name)
                    {
                        case "email_format":
                            int[] index = { 1 };
                            listBoxField.SelectedIndex = index;
                            break;
                    }
                }
                //if (field is PdfListBoxWidgetFieldWidget)
                //{
                //    PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;
                //    switch (listBoxField.Name)
                //    {
                //        case "email_format":
                //            int[] index = { 1 };
                //            listBoxField.SelectedIndex = index;
                //            break;
                //    }
                //}

                //if (field is PdfComboBoxWidgetFieldWidget)
                //{
                //    PdfComboBoxWidgetFieldWidget comBoxField = field as PdfComboBoxWidgetFieldWidget;
                //    switch (comBoxField.Name)
                //    {
                //        case "title":
                //            int[] items = { 0 };
                //            comBoxField.SelectedIndex = items;
                //            break;
                //    }
                //}   

                //if (field is PdfRadioButtonListFieldWidget)
                //{
                //    PdfRadioButtonListFieldWidget radioBtnField = field as PdfRadioButtonListFieldWidget;
                //    switch (radioBtnField.Name)
                //    {
                //        case "country":
                //            radioBtnField.SelectedIndex = 1;
                //            break;
                //    }
                //}

                //if (field is PdfCheckBoxWidgetFieldWidget)
                //{
                //    PdfCheckBoxWidgetFieldWidget checkBoxField = field as PdfCheckBoxWidgetFieldWidget;
                //    switch (checkBoxField.Name)
                //    {
                //        case "agreement_of_terms":
                //            checkBoxField.Checked = true;
                //            break;
                //    }
                //}
                //if (field is PdfButtonWidgetFieldWidget)
                //{
                //    PdfButtonWidgetFieldWidget btnField = field as PdfButtonWidgetFieldWidget;
                //    switch (btnField.Name)
                //    {
                //        case "submit":
                //            btnField.Text = "Submit";
                //            break;
                //    }
                //}
            }
            doc.SaveToFile($@"C:\Users\Admin\Desktop\{hero.Cha_name.Text}.pdf");
            System.Diagnostics.Process.Start($@"C:\Users\Admin\Desktop\{hero.Cha_name.Text}.pdf");


        }
    }
}
