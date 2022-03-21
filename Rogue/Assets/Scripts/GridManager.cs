using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Empty,
    Enemy,
    Obstacle
}

public class GameTile{
    private TileType tileType;
    private GameObject gameObject;

    public GameTile(TileType newTileType, GameObject newGameObject)
    {
        tileType = newTileType;
        gameObject = newGameObject;
    }

    public void SetTileType(TileType newTileType)
    {
        tileType = newTileType;
    }

    public void SetObject(GameObject newGameObject)
    {
        gameObject = newGameObject;
    }

    public TileType GetTileType()
    {
        return tileType;
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}

public class GridManager : MonoBehaviour
{
    //Singleton Pattern
    public static GridManager instance;

    private void Awake()
    {
        instance = this;

        gridData = InitGrid(16,16);
    }

    private GameTile[,] gridData;

    public void SetGridData(GameTile[,] newGridData)
    {
        gridData = newGridData;
    }

    public void SetGridTile(GameTile tile, Vector2Int pos)
    {
        gridData[pos.x, pos.y] = tile;
    }


    public GameTile[,] GetGridData()
    {
        return gridData;
    }

    public TileType GetTileType(Vector2Int pos)
    {
        return gridData[pos.x, pos.y].GetTileType();
    }

    public Vector2Int GetGridDimension()
    {
        return new Vector2Int(gridData.GetLength(0), gridData.GetLength(1));
    }

    private GameTile[,] InitGrid(int width, int height)
    {
        GameTile[,] newGridData = new GameTile[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                newGridData[i, j] = new GameTile(TileType.Empty, null);
            }
        }
        return newGridData;
    }
}
