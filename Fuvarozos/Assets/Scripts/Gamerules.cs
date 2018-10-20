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
        {new GameTile("0","Győr") },
        {new GameTile("1","Budapest") },
        {new GameTile("2","Miskolc") },
        {new GameTile("3","Szombathely") },
        {new GameTile("4","Székesfehérvár") },
        {new GameTile("5","Kecskemét") },
        {new GameTile("6","Debrecen") },
        {new GameTile("7","Pécs") },
        {new GameTile("8","Szeged") },
        {new GameTile("9","Békéscsaba") }
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
        {new Prices( Levels.Second,Quality.Normal,1200,20)},
        {new Prices( Levels.Second,Quality.Normal,800,25)},
        {new Prices( Levels.Third, Quality.Normal,1800,80)},
        {new Prices( Levels.Third, Quality.Normal,1100,100)}
    };
    public static List<Prices> DriverPrices = new List<Prices>
    {
        {new Prices( Levels.First, Quality.Normal,600,10)},
        {new Prices( Levels.Second,Quality.Normal,1200,20)},
        {new Prices( Levels.Second,Quality.Normal,800,25)},
        {new Prices( Levels.Third, Quality.Normal,1800,80)},
        {new Prices( Levels.Third, Quality.Normal,1100,100)}
    };
}
