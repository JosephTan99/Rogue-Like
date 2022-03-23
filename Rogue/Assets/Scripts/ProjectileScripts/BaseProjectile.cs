using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseProjectile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TempoManager.instance.Tick += TickUpdate;
    }

    public void Move(Vector2 velocity)
    {
        transform.DOLocalMove(transform.position + (Vector3)velocity, 1f);
        if (velocity.x < 0) spriteRenderer.flipX = true;
        else if (velocity.x > 0) spriteRenderer.flipX = false;
    }

    public virtual void TickUpdate()
    {

    }
}
