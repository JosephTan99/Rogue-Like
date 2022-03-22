using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TileType is an enum that specifies the type of a tile.
/// </summary>
public enum TileType
{
    Empty,
    Enemy,
    Obstacle
}

/// <summary>
/// GameTile is a class that stores data for a tile in the game.
/// </summary>
public class GameTile{
    private TileType tileType;
    private GameObject gameObject;

    public GameTile(TileType newTileType, GameObject newGameObject)
    {
        tileType = newTileType;
        gameObject = newGameObject;
    }

    #region Setters & Getters
    /// <summary>
    /// Sets the TileType of the current GameTile.
    /// </summary>
    /// <param name="newTileType"></param>
    public void SetTileType(TileType newTileType)
    {
        tileType = newTileType;
    }

    /// <summary>
    /// Sets the GameObject of the current GameTile.
    /// </summary>
    /// <param name="newGameObject"></param>
    public void SetObject(GameObject newGameObject)
    {
        gameObject = newGameObject;
    }

    /// <summary>
    /// Returns the TileType of the current GameTile.
    /// </summary>
    /// <returns></returns>
    public TileType GetTileType()
    {
        return tileType;
    }

    /// <summary>
    /// Returns the GameObject of the current GameTile.
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject()
    {
        return gameObject;
    }
    #endregion

}

/// <summary>
/// GridManager is a class that manages the grid system in this game.
/// </summary>
public class GridManager : MonoBehaviour
{
    /// 
    /// Attributes: 
    /// 
    /// gridData    => 2D array of GameTile, stores all the information about the game grid
    /// 
    /// Get-Set Methods(Self explanatory):
    /// 
    /// SetGridData
    /// GetGridData
    /// SetGridTile
    /// GetTile
    /// GetGridDimension
    /// 
    /// Private Methods:
    /// InitGrid    => initializes the gridData
    /// 
    /// 

    //Singleton Pattern
    public static GridManager instance;

    private void Awake()
    {
        instance = this;

        gridData = InitGrid(16,16);
    }

    private GameTile[,] gridData;

    #region Getters & Setters
    /// <summary>
    /// Sets the GridData to the 2D array given in parameter.
    /// </summary>
    /// <param name="newGridData"></param>
    public void SetGridData(GameTile[,] newGridData)
    {
        gridData = newGridData;
    }

    /// <summary>
    /// Sets the tile at Vector2Int position with the tile given in parameter.
    /// </summary>
    /// <param name="tile"></param>
    /// <param name="pos"></param>
    public void SetGridTile(GameTile tile, Vector2Int pos)
    {
        gridData[pos.x, pos.y] = tile;
    }

    /// <summary>
    /// Returns current gridData - 2D array of GameTile.
    /// </summary>
    /// <returns></returns>
    public GameTile[,] GetGridData()
    {
        return gridData;
    }

    /// <summary>
    /// Returns GameTile at Vector2Int position given in parameter. Returns null if position is not valid.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public GameTile GetTile(Vector2Int pos)
    {
        Vector2Int dim = GetGridDimension();
        if(pos.x >= 0 && pos.y >= 0 && pos.x < dim.x && pos.y < dim.y)
        {
            return gridData[pos.x, pos.y];
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Returns the dimension of the current gridData in the form of Vector2Int.
    /// </summary>
    /// <returns></returns>
    public Vector2Int GetGridDimension()
    {
        return new Vector2Int(gridData.GetLength(0), gridData.GetLength(1));
    }
    #endregion

    /// <summary>
    /// Initializes the grid to the width and height given in parameters with Empty GameTiles.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
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
