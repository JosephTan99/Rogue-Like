using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseAI : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private bool canMove = true;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TempoManager.instance.TickA += TickUpdateA;
        TempoManager.instance.TickE += TickUpdateE;
    }

    public void Move(Vector2 velocity)
    {
        if (!canMove)
        {
            canMove = true;
        }
        else
        {
            GridManager.instance.SetGridTile(new GameTile(TileType.Empty, null), Vector2Int.RoundToInt(transform.position));
            GridManager.instance.SetGridTile(new GameTile(TileType.Enemy, gameObject), Vector2Int.RoundToInt(transform.position + (Vector3)velocity));
            transform.DOJump(transform.position + (Vector3)velocity, 0.25f, 1, 0.5f);
            if (velocity.x < 0) spriteRenderer.flipX = true;
            else if (velocity.x > 0) spriteRenderer.flipX = false;
        }
    }

    public virtual Vector2Int MoveTile()
    {
        return Vector2Int.zero;
    }

    public void LockMove()
    {
        canMove = false;
    }

    public virtual void TickUpdateA() { }

    public virtual void TickUpdateE() { }
}
