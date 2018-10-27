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
        Debug.Log("Generation done!");

        WriteMapToDisk(ref gameTiles);

    }
    public static void GenerateConnectionBetweenTiles(ref List<GameTile> gameTiles, string from, string to, int fieldsBetween)
    {
        GameTile From = FindGameTileById(ref gameTiles, from);
        GameTile To = FindGameTileById(ref gameTiles, to);
        GameTile latestAdded = From;
        GameTile newTile = new GameTile("");
        for (int i = 0; i < fieldsBetween; i++)
        {
            Vector3 tarDir = To.TilePosition - From.TilePosition;
            Vector3 angleDir = Vector3.up;
            if (tarDir.y < 0 && tarDir.x > 0)
            {
                angleDir = Vector3.down;
            }

            newTile = new GameTile(GenerateNewId(ref gameTiles))
            {
                TilePosition = Vector3.Lerp(From.TilePosition, To.TilePosition, 1f / (fieldsBetween + 1) * (i + 1)),
                TileRotation = Vector3.Angle(tarDir, angleDir) * new Vector3(0, 0, 1),
                TileScale = new Vector3(1, 1 + (1f / (fieldsBetween)), 1)
            };
            newTile.Connections.Add(latestAdded.Id);
            latestAdded.Connections.Add(newTile.Id);
            gameTiles.Add(newTile);
            latestAdded = newTile;
        }
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
    public static GameObject DrawMap()
    {
        List<GameTile> map = ReadMapFromFile();
        GameObject mapcontainer = new GameObject("MapContainer");
        mapcontainer.transform.position = new Vector3(200,200,1);
        foreach (GameTile tile in map)
        {
            GameObject kek;
            if (tile.Id.StartsWith("_"))
            {
                kek = GameObject.Instantiate<GameObject>(Resources.Load("ConnectorTile") as GameObject);
            }
            else
            {
                kek = GameObject.Instantiate<GameObject>(Resources.Load("CityTile") as GameObject);

            }
            kek.transform.SetParent(mapcontainer.transform);
            kek.transform.position = tile.TilePosition;
            kek.transform.rotation = Quaternion.Euler(tile.TileRotation);
            kek.transform.localScale = tile.TileScale;
            
        }
        return mapcontainer;
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
        Debug.Log("Write to disk done!");
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
