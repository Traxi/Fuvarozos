using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public enum Levels : byte
{
    First,
    Second,
    Third
}

public class GameController
{
    public string[] Rounds;
    public int CurrentRound = 0;
    public int CurrentPlayerIndex
    {
        get
        {
            return Players.IndexOf(_currentPlayer);
        }
    }

    private Player _currentPlayer;
    public Player CurrentPlayer
    {
        get { return _currentPlayer ?? (_currentPlayer = Players.FirstOrDefault()); }
        set
        {
            _currentPlayer = value;
        }
    }

    public void SelectNextPlayer()
    {
        if (PlayerCount - 1 > CurrentPlayerIndex)
            CurrentPlayer = Players[CurrentPlayerIndex + 1];
    }

    public void SelectPreviousPlayer()
    {
        if (CurrentPlayerIndex > 0)
            CurrentPlayer = Players[CurrentPlayerIndex - 1];
    }

    private static GameController instance;
    public static GameController Instance
    {
        get { return instance ?? (instance = new GameController()); }
        set
        {
            instance = value;
        }
    }

    public Levels CurrentLevel;

    public readonly Dictionary<int, int> RoundNumbers = new Dictionary<int, int>(Gamerules.DefaultRoundNumbers);

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


