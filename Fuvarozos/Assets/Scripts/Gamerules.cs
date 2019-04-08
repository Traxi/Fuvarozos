using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quality
{
    Good,
    Normal,
    Bad
}

public static class Gamerules
{
    public static List<GameTile> GameMap = new List<GameTile>
    {
        {new GameTile("0",new Vector3(5,20,0), Vector3.one ,"Győr") },
        {new GameTile("1",new Vector3(15,20,0), Vector3.one,"Budapest") },
        {new GameTile("2",new Vector3(25,20,0), Vector3.one, "Miskolc") },
        {new GameTile("3",new Vector3(0,10,0), Vector3.one,"Szombathely") },
        {new GameTile("4",new Vector3(10,10,0), Vector3.one,"Székesfehérvár") },
        {new GameTile("5",new Vector3(20,10,0), Vector3.one,"Kecskemét") },
        {new GameTile("6",new Vector3(30,10,0), Vector3.one,"Debrecen") },
        {new GameTile("7",new Vector3(5,0,0), Vector3.one,"Pécs") },
        {new GameTile("8",new Vector3(15,0,0), Vector3.one,"Szeged") },
        {new GameTile("9",new Vector3(25,0,0), Vector3.one,"Békéscsaba") }
    };


    public static Dictionary<int, int> DefaultRoundNumbers = new Dictionary<int, int>
    {
        {
            (int)Levels.First, 20

        },
        {
            (int)Levels.Second, 20
        },
        {
            (int)Levels.Third, 20
        }
    };

    public static Dictionary<Levels, int> Liquidity = new Dictionary<Levels, int>
    {
        {Levels.First,-500 },
        {Levels.Second,-2000 },
        {Levels.Third,-4000 }
    };

    public static Dictionary<Levels, int> TaxPerRound = new Dictionary<Levels, int>
    {
        {Levels.First,50 },
        {Levels.Second,100},
        {Levels.Third,200 }
    };

    public static Dictionary<Levels, int> PolicePenalty = new Dictionary<Levels, int>
    {
        {Levels.First, 100 },
        {Levels.Second,250 },
        {Levels.Third, 400 }
    };

    public class Prices
    {
        public Prices(Levels level, Quality quality, int price, int upkeep)
        {
            Level = level;
            Quality = quality;
            Price = price;
            Upkeep = upkeep;
        }
        public Levels Level;
        public Quality Quality;
        public int Price;
        public int Upkeep;
    }

    public static List<Prices> VehiclePrices = new List<Prices>
    {
        {new Prices( Levels.First, Quality.Normal,600,10)},
        {new Prices( Levels.Second,Quality.Good,1200,20)},
        {new Prices( Levels.Second,Quality.Bad,800,25)},
        {new Prices( Levels.Third, Quality.Good,1800,80)},
        {new Prices( Levels.Third, Quality.Bad,1100,100)}
    };
    public static List<Prices> DriverPrices = new List<Prices>
    {
        {new Prices( Levels.First, Quality.Normal,600,10)},
        {new Prices( Levels.Second,Quality.Good,200,20)},
        {new Prices( Levels.Second,Quality.Bad,100,10)},
        {new Prices( Levels.Third, Quality.Good,250,150)},
        {new Prices( Levels.Third, Quality.Bad,80,50)}
    };
}
