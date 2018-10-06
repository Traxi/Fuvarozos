using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhases : byte
{
    Shopping,
    Auctioning,
    Movement,
    Summary
}
public enum Levels : byte
{
    First,
    Second,
    Third
}

internal interface IOnLoadListener
{
    void OnLoadComplete();
}
public class GameController : IOnLoadListener
{
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameController();
            }

            return instance;
        }
    }

    private Levels CurrentLevel;

    private List<Player> _players;
    public List<Player> Players
    {
        get
        {
            if (_players == null)
            {
                _players = new List<Player>();
            }
            return _players;
        }
    }

    public void AddPlayers(Player player)
    {
        Players.Add(player);
    }

    public int GetVehiclePrice(Levels currentLevel, Quality quality)
    {
        return Gamerules.VehiclePrices.Find(x => x.Level == currentLevel && x.Quality == quality).Price;
    }
    public int GetVehicleUpkeep(Levels currentLevel, Quality quality)
    {
        return Gamerules.VehiclePrices.Find(x => x.Level == currentLevel && x.Quality == quality).Upkeep;
    }
    public int GetDriverPrice(Levels currentLevel, Quality quality)
    {
        return Gamerules.DriverPrices.Find(x => x.Level == currentLevel && x.Quality == quality).Price;
    }
    public int GetDriverUpkeep(Levels currentLevel, Quality quality)
    {
        return Gamerules.DriverPrices.Find(x => x.Level == currentLevel && x.Quality == quality).Upkeep;
    }

    public void OnLoadComplete()
    {

    }
}


