using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseProjectile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Vector2Int projectilePos;

    private bool isDestroy = false;

    private void CheckGridTiles(Vector2Int tile)
    {
        if (GridManager.instance.GetTile(tile) == null)
        {
            isDestroy = true;
        }
    }

    public virtual void DestroyProjectile()
    {
        TempoManager.instance.TickA -= TickUpdateA;
        TempoManager.instance.TickE -= TickUpdateE;
        Destroy(gameObject);
    }


    public virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TempoManager.instance.TickA += TickUpdateA;
    }

    public void Move(Vector2Int velocity)
    {
        CheckGridTiles(projectilePos + velocity);
        //Check enemy presence 
        GameTile currTile = GridManager.instance.GetTile(Vector2Int.RoundToInt(transform.position) + velocity);
        if (!isDestroy)
        {
            if (currTile.GetTileType() == TileType.Enemy)
            {
                BaseAI script = currTile.GetObject().GetComponent<BaseAI>();
                Vector2Int tileToMove = script.MoveTile();
                if (tileToMove == Vector2Int.RoundToInt(transform.position) + velocity || tileToMove == Vector2Int.RoundToInt(transform.position))
                {
                    script.LockMove();
                    transform.DOLocalMove(transform.position + (Vector3)(Vector2)velocity, 60f / TempoManager.instance.GetBpm()).SetEase(Ease.Linear);
                }
            }
            else
            {
                transform.DOLocalMove(transform.position + (Vector3)(Vector2)velocity, 60f / TempoManager.instance.GetBpm()).SetEase(Ease.Linear);
                if (velocity.x < 0) spriteRenderer.flipX = true;
                else if (velocity.x > 0) spriteRenderer.flipX = false;
                projectilePos += velocity;
            }
            
        }
        else
        {
            transform.DOLocalMove(transform.position + (Vector3)(Vector2)velocity, 60f / TempoManager.instance.GetBpm()).SetEase(Ease.Linear);
            if (velocity.x < 0) spriteRenderer.flipX = true;
            else if (velocity.x > 0) spriteRenderer.flipX = false;
            projectilePos += velocity;
        }
        

    }

    public virtual void TickUpdateA()
    {

    }

    public virtual void TickUpdateE()
    {
        if (isDestroy)
        {
            DestroyProjectile();
        }
    }
}
