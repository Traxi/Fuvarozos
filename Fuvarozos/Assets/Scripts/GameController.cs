using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

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

public class GameController
{
    public string[] Rounds;
    public int CurrentRound;

    private static GameController instance;
    public static GameController Instance
    {
        get { return instance ?? (instance = new GameController()); }
        set
        {
            instance = value;
        }
    }

    private Levels CurrentLevel;

    public Dictionary<int, int> RoundNumbers = new Dictionary<int, int>(Gamerules.DefaultRoundNumbers);

    public int PlayerCount
    {
        get { return Players.Count; }
    }
    private List<Player> _players;
    public List<Player> Players
    {
        get { return _players ?? (_players = new List<Player>()); }
    }

    public void AddPlayers(Player player)
    {
        Players.Add(player);
    }

    public void RemovePlayerById(string id)
    {
        var playerToRemove = Players.Find(p => p.Id == id);
        Debug.Log(playerToRemove);
        if (playerToRemove != null)
            Players.Remove(playerToRemove);
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


