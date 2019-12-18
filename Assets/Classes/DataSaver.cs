using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaver
{
    //Save Data
    public static void SaveData(string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        string toSave = Player.getUsername();
        toSave += "|" + Player.NumberMonstersMax;
        toSave += "|" + Player.Gems;
        toSave += "|" + Player.Gold + "|";
        foreach(Monster m in Player.getMonsters())
        {
            toSave += m.ToString() + ";";
        }
        toSave = toSave.Substring(0, toSave.Length - 1);
        toSave += "|" + Player.getMainMonster().ToString() + "|";
        foreach (Food f in Player.getFoodDico().Keys)
        {
            toSave += Player.getFoodDico()[f] + ",";
        }
        toSave = toSave.Substring(0, toSave.Length - 1);

        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        }

        File.WriteAllText(tempPath, toSave);

        /* string tempPath = Path.Combine(Application.persistentDataPath, "data");
         tempPath = Path.Combine(tempPath, dataFileName + ".txt");

         //Convert To Json then to bytes
         string gems = JsonConvert.SerializeObject(dataToSave.gems);
         string gold = JsonConvert.SerializeObject(dataToSave.gold);
         string mainMonster = JsonConvert.SerializeObject(dataToSave.mainMonster);
         string numberMonstersMax = JsonConvert.SerializeObject(dataToSave.numberMonstersMax);
         string username = JsonConvert.SerializeObject(dataToSave.username);
         string _foods = JsonConvert.SerializeObject(dataToSave._foods);
         string _monsters = JsonConvert.SerializeObject(dataToSave._monsters);

         *//*string jsonData = JsonConvert.SerializeObject(dataToSave);
         byte[] jsonByte = Encoding.ASCII.GetBytes(jsonData);
 *//*
         string jsonData = gems + "|" + gold + "|" + mainMonster + "|" + numberMonstersMax + "|" + username + "|" + _foods + "|" + _monsters + "|";
         //Create Directory if it does not exist
         if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
         {
             Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
         }
         //Debug.Log(path);

         File.WriteAllText(tempPath, jsonData);

         *//*using (StreamWriter file = File.CreateText(tempPath))
         {
             JsonSerializer serializer = new JsonSerializer();
             serializer.Serialize(file, dataToSave);
         }*/
    }

    //Load Data
    public static bool LoadData(string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        //Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Debug.LogWarning("Directory does not exist");
            return false;
        }

        if (!File.Exists(tempPath))
        {
            Debug.Log("File does not exist");
            return false;
        }

        string read = File.ReadAllText(tempPath);

        string[] readSplit = read.Split('|');

        Player.setUsername(readSplit[0]);
        Player.NumberMonstersMax = System.Convert.ToInt32(readSplit[1]);
        Player.Gems = System.Convert.ToInt32(readSplit[2]);
        Player.Gold = System.Convert.ToInt32(readSplit[3]);
        Player.clearMonsters();
        string[] monsters = readSplit[4].Split(';');
        foreach(string s in monsters)
        {
            string[] aliments = s.Split(',');
            Monster m = ListMonsters.get(aliments[0]);
            m.setLevel(Convert.ToInt32(aliments[1]));
            m.Experience = Convert.ToInt32(aliments[2]);
            for (int i=3; i<6; i++)
            {
                if(aliments[i] != "null")
                {
                    Food f = null;
                    if(aliments[i] == "Chili")
                    {
                        f = Chili.Instance;
                    }
                    else if (aliments[i] == "Sushi")
                    {
                        f = Sushi.Instance;
                    }
                    else if (aliments[i] == "Yaourtauxfraises")
                    {
                        f = YaourtFraise.Instance;
                    }
                    else if (aliments[i] == "Fraise")
                    {
                        f = Fraise.Instance;
                    }
                    else if (aliments[i] == "HaricotRouge")
                    {
                        f = HaricotRouge.Instance;
                    }
                    else if (aliments[i] == "Lait")
                    {
                        f = Lait.Instance;
                    }
                    else if (aliments[i] == "Oignon")
                    {
                        f = Oignon.Instance;
                    }
                    else if (aliments[i] == "Poivron")
                    {
                        f = Poivron.Instance;
                    }
                    else if (aliments[i] == "Riz")
                    {
                        f = Riz.Instance;
                    }
                    else if (aliments[i] == "Steak")
                    {
                        f = Steak.Instance;
                    }
                    else if (aliments[i] == "Thon")
                    {
                        f = Thon.Instance;
                    }
                    AddStats(f, m);
                }
            }
            Player.addMonster(m);
        }

        string[] details = readSplit[5].Split(',');
        Monster monster = ListMonsters.get(details[0]);
        monster.setLevel(Convert.ToInt32(details[1]));
        monster.Experience = Convert.ToInt32(details[2]);
        for (int i = 3; i < 6; i++)
        {
            if (details[i] != "null")
            {
                Food f = null;
                if (details[i] == "Chili")
                {
                    f = Chili.Instance;
                }
                else if (details[i] == "Sushi")
                {
                    f = Sushi.Instance;
                }
                else if (details[i] == "Yaourtauxfraises")
                {
                    f = YaourtFraise.Instance;
                }
                else if (details[i] == "Fraise")
                {
                    f = Fraise.Instance;
                }
                else if (details[i] == "HaricotRouge")
                {
                    f = HaricotRouge.Instance;
                }
                else if (details[i] == "Lait")
                {
                    f = Lait.Instance;
                }
                else if (details[i] == "Oignon")
                {
                    f = Oignon.Instance;
                }
                else if (details[i] == "Poivron")
                {
                    f = Poivron.Instance;
                }
                else if (details[i] == "Riz")
                {
                    f = Riz.Instance;
                }
                else if (details[i] == "Steak")
                {
                    f = Steak.Instance;
                }
                else if (details[i] == "Thon")
                {
                    f = Thon.Instance;
                }
                AddStats(f, monster);
            }
        }
        Player.defineMainMonster(monster);

        string[] foodDico = readSplit[6].Split(',');
        Player.getFoodDico()[Chili.Instance] = Convert.ToInt32(foodDico[0]);
        Player.getFoodDico()[Sushi.Instance] = Convert.ToInt32(foodDico[1]);
        Player.getFoodDico()[YaourtFraise.Instance] = Convert.ToInt32(foodDico[2]);

        Player.getFoodDico()[Fraise.Instance] = Convert.ToInt32(foodDico[3]);
        Player.getFoodDico()[HaricotRouge.Instance] = Convert.ToInt32(foodDico[4]);
        Player.getFoodDico()[Lait.Instance] = Convert.ToInt32(foodDico[5]);
        Player.getFoodDico()[Oignon.Instance] = Convert.ToInt32(foodDico[6]);
        Player.getFoodDico()[Poivron.Instance] = Convert.ToInt32(foodDico[7]);
        Player.getFoodDico()[Riz.Instance] = Convert.ToInt32(foodDico[8]);
        Player.getFoodDico()[Steak.Instance] = Convert.ToInt32(foodDico[9]);
        Player.getFoodDico()[Thon.Instance] = Convert.ToInt32(foodDico[10]);
        return true;
    }


    private static void AddStats(Food f, Monster m)
    {
        m.addFood(f);
        int mult = ListInteractionFood.GetMultiplier(new List<Food>(m.getFood()));
        m.FoodBonusMultiplier = mult;

        m.addStats(-m.BonusStats["hp"], -m.BonusStats["attack"], -m.BonusStats["defense"], -m.BonusStats["speed"], -m.BonusStats["critRate"], -m.BonusStats["critDamage"]);

        Dictionary<string, int> statsToAdd = f.getBonus();
        foreach (KeyValuePair<string, int> kvp in f.getBonus())
        {
            m.BonusStats[kvp.Key] += statsToAdd[kvp.Key];
        }

        foreach (KeyValuePair<string, int> kvp in f.getBonus())
        {
            m.BonusStats[kvp.Key] *= m.FoodBonusMultiplier;
        }

        m.addStats(m.BonusStats["hp"], m.BonusStats["attack"], m.BonusStats["defense"], m.BonusStats["speed"], m.BonusStats["critRate"], m.BonusStats["critDamage"]);
    }
}