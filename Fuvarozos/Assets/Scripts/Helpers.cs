using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class Helpers
{
    public static void GenerateGameTiles(ref List<GameTile> gameTiles)
    {
        //Győr
        GenerateConnectionBetweenTiles(ref gameTiles, "0", "1", 3);
        GenerateConnectionBetweenTiles(ref gameTiles, "0", "3", 2);
        GenerateConnectionBetweenTiles(ref gameTiles, "0", "4", 2);
        //Budapest
        GenerateConnectionBetweenTiles(ref gameTiles, "1", "4", 2);
        GenerateConnectionBetweenTiles(ref gameTiles, "1", "5", 2);
        GenerateConnectionBetweenTiles(ref gameTiles, "1", "2", 4);
        //Miskolc
        GenerateConnectionBetweenTiles(ref gameTiles, "2", "5", 3);
        GenerateConnectionBetweenTiles(ref gameTiles, "2", "6", 2);
        //Szombathely
        GenerateConnectionBetweenTiles(ref gameTiles, "3", "4", 3);
        GenerateConnectionBetweenTiles(ref gameTiles, "3", "7", 4);
        //Székesfehérvár
        GenerateConnectionBetweenTiles(ref gameTiles, "4", "7", 3);
        //Kecskemét
        GenerateConnectionBetweenTiles(ref gameTiles, "5", "8", 2);
        //Debrecen
        GenerateConnectionBetweenTiles(ref gameTiles, "6", "9", 3);
        //Pécs
        GenerateConnectionBetweenTiles(ref gameTiles, "7", "8", 4);
        //Szeged
        GenerateConnectionBetweenTiles(ref gameTiles, "8", "9", 2);

        WriteMapToDisk(ref gameTiles);

    }
    public static void GenerateConnectionBetweenTiles(ref List<GameTile> gameTiles, string from, string to, int fieldsBetween)
    {
        GameTile From = FindGameTileById(ref gameTiles, from);
        GameTile latestAdded = From;
        GameTile newTile = new GameTile("");
        for (int i = 0; i < fieldsBetween; i++)
        {

            newTile = new GameTile(GenerateNewId(ref gameTiles));
            newTile.Connections.Add(latestAdded.Id);
            latestAdded.Connections.Add(newTile.Id);
            gameTiles.Add(newTile);
            latestAdded = newTile;
        }
        GameTile To = FindGameTileById(ref gameTiles, to);
        latestAdded.Connections.Add(newTile.Id);
        To.Connections.Add(latestAdded.Id);

    }

    public static string GenerateNewId(ref List<GameTile> gameTiles)
    {
        int breaktimer = 0;
        string newid = "_" + Random.Range(0, 100000000).ToString();
        while ((FindGameTileById(ref gameTiles, newid) != null) && breaktimer < 100)
        {
            Debug.Log(newid + " is already taken... Assigning new...");
            newid = Random.Range(0, 10).ToString();
            breaktimer++;
        }
        if (breaktimer == 100)
        {
            Debug.LogError("Cannot assign unique id... We are fucked.");
        }
        return newid;
    }

    public static GameTile FindGameTileById(ref List<GameTile> gameTiles, string idToFind)
    {
        return gameTiles.Find(x => x.Id == idToFind);
    }

    private class MapPositionHelper
    {
        public string TileId;
        public Vector3 Position;
    }
    public static Vector3[] DrawMap()
    {
        List<GameTile> map = ReadMapFromFile();
        List<MapPositionHelper> positions = new List<MapPositionHelper>();
        for (int i = 0, length = map.Count; i < length; i++)
        {
            positions.Add(new MapPositionHelper()
            {
                TileId = map[i].Id,
                Position = new Vector3(i, i)
            });
        }

        List<string> visited = new List<string>();
        foreach (GameTile field in map)
        {
            foreach (var item in field.Connections)
            {

            }
        }

        return null;
    }

    private static List<GameTile> ReadMapFromFile()
    {
        //Note: This will be moved into assetDatabase later on, and loaded from there.
        using (StreamReader sr = new StreamReader("helloworld.txt"))
        {
            string asd = sr.ReadToEnd();
            List<GameTile> topkek = FromJson<List<GameTile>>(asd);
            return topkek;
        }
    }



    public static void WriteMapToDisk(ref List<GameTile> gameTiles)
    {
        using (StreamWriter sw = new StreamWriter("helloworld.txt", false))
        {
            sw.Write(ToJson(gameTiles));
        }
    }

    private class ContainerClass<GenericData>
    {
        public GenericData genericData;
        public ContainerClass(GenericData data)
        {
            genericData = data;
        }
    }
    public static string ToJson<T>(T data)
    {
        ContainerClass<T> DataToJsonify = new ContainerClass<T>(data);
        return JsonUtility.ToJson(DataToJsonify, true);
    }

    public static GenericData FromJson<GenericData>(string data)
    {
        ContainerClass<GenericData> container;
        container = JsonUtility.FromJson<ContainerClass<GenericData>>(data);
        return container.genericData;
    }

}
