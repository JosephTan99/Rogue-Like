using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Empty,
    Player,
    Enemy,
    Obstacle
}

public class GameTile{
    private TileType TileType;
    private GameObject gameObject;

    public TileType GetTileType()
    {
        return TileType;
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}

public class GridManager : MonoBehaviour
{
    private GameTile[,] gridData = new GameTile[16, 16];

    public GameTile[,] GetTileData()
    {
        return gridData;
    }

    public TileType GetTileType(int x, int y)
    {
        return gridData[x, y].GetTileType();
    }
}
