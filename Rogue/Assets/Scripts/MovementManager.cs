using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Manages the movement of the player character.
/// </summary>
public class MovementManager : MonoBehaviour
{
    //Singleton Pattern

    public static MovementManager instance;

    [SerializeField]
    private Vector2Int playerPos = new Vector2Int(0,0);

    private Vector2Int dir;

    private void Awake()
    {
        instance = this;
        TempoManager.instance.TickA += Move;
    }

    private void Update()
    {
        InputDir();
    }

    /// <summary>
    /// Moves the player character 1 Tile towards the direction of keypress.
    /// </summary>
    public void Move()
    {
        Vector2Int dim = GridManager.instance.GetGridDimension();
        Vector2Int newPos = playerPos + dir;
        if(newPos.x >= 0 && newPos.y >= 0 && newPos.x < dim.x && newPos.y < dim.y)
        {
            if (GridManager.instance.GetTile(newPos).GetTileType() == TileType.Empty)
            {
                playerPos += dir;
                transform.DOJump(transform.position + (Vector3)(Vector2)dir, 0.25f, 1, 0.5f);
                if (dir.x < 0) GetComponent<SpriteRenderer>().flipX = true;
                else if (dir.x > 0) GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            transform.DOJump(transform.position, 0.25f, 1, 0.5f);
            if (dir.x < 0) GetComponent<SpriteRenderer>().flipX = true;
            else if (dir.x > 0) GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void ResetParam()
    {
        dir = Vector2Int.zero;
    }

    private void InputDir()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2Int.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2Int.down;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2Int.right;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2Int.left;
        }
    }

    #region Getters & Setters
    /// <summary>
    /// Returns the current player game tile position in Vector2Int.
    /// </summary>
    /// <returns></returns>
    public Vector2Int GetPlayerPos()
    {
        return playerPos;
    }

    /// <summary>
    /// Sets the current player game tile position according to the parameter.
    /// </summary>
    /// <param name="newPlayerPos"></param>
    public void SetPlayerPos(Vector2Int newPlayerPos)
    {
        playerPos = newPlayerPos;
    }

    public Vector2 GetDir()
    {
        return dir;
    }
    #endregion
}
