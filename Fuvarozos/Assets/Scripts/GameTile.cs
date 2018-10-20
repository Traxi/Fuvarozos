using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class GameTile
{
    public string Id;
    public string Name;
    [SerializeField]
    private List<string> _connections;
    public List<string> Connections
    {
        get
        {
            if (_connections == null)
            {
                _connections = new List<string>();
            }

            return _connections;
        }
    }

    public GameTile(string id, string name = "")
    {
        Id = id;
        Name = name;
    }
}
