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

    private void Awake()
    {
        instance = this;
        TempoManager.instance.Tick += Move;
    }

    public void Move()
    {

        Vector2 dir = InputManager.instance.GetDir();
        Vector2Int intDir = Vector2Int.RoundToInt(dir);
        Vector2Int dim = GridManager.instance.GetGridDimension();
        Vector2Int newPos = playerPos + intDir;
        if(newPos.x >= 0 && newPos.y >= 0 && newPos.x < dim.x && newPos.y < dim.y)
        {
            if (GridManager.instance.GetTile(newPos).GetTileType() == TileType.Empty)
            {
                playerPos += intDir;
                transform.DOJump(transform.position + (Vector3)dir, 0.25f, 1, 0.5f);
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

    public Vector2Int GetPlayerPos()
    {
        return playerPos;
    }

    public void SetPlayerPos(Vector2Int newPlayerPos)
    {
        playerPos = newPlayerPos;
    }
}
