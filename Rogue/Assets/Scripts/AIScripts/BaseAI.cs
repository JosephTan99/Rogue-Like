using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseAI : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TempoManager.instance.Tick += TickUpdate;
    }

    public void Move(Vector2 direction)
    {
        GridManager.instance.SetGridTile(new GameTile(TileType.Empty, null), Vector2Int.RoundToInt(transform.position));
        GridManager.instance.SetGridTile(new GameTile(TileType.Empty, null), Vector2Int.RoundToInt(transform.position + (Vector3)direction));
        transform.DOJump(transform.position + (Vector3)direction, 0.25f, 1, 0.5f);
        if (direction.x < 0) spriteRenderer.flipX = true;
        else if (direction.x > 0) spriteRenderer.flipX = false;
        
    }

    public virtual void TickUpdate() { }
    
}
