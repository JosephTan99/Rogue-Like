using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseProjectile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Vector2Int projectilePos;

    private void CheckGridTiles(Vector2Int tile)
    {
        if (GridManager.instance.GetTile(tile) == null)
        {
            DestroyProjectile();
        }
    }

    public virtual void DestroyProjectile()
    {
        TempoManager.instance.TickA -= TickUpdate;
        Destroy(gameObject);
    }


    public virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TempoManager.instance.TickA += TickUpdate;
    }

    public void Move(Vector2Int velocity)
    {
        transform.DOLocalMove(transform.position + (Vector3)(Vector2)velocity, 60f / TempoManager.instance.GetBpm()).SetEase(Ease.Linear);
        if (velocity.x < 0) spriteRenderer.flipX = true;
        else if (velocity.x > 0) spriteRenderer.flipX = false;
        projectilePos += velocity;
        CheckGridTiles(projectilePos);
    }

    public virtual void TickUpdate()
    {

    }
}
