using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementManager : MonoBehaviour
{
    /// <summary>
    /// Manages the movement of the player character.
    /// </summary>


    //Singleton Pattern

    public static MovementManager instance;

    private void Awake()
    {
        instance = this;
    }

    private float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
            timer = 0;
        }
    }

    public void Move(Vector2 dir)
    {
        transform.DOJump(transform.position + (Vector3)dir, 0.25f, 1, 0.5f);
        if (dir.x < 0) GetComponent<SpriteRenderer>().flipX = true;
        else if(dir.x > 0) GetComponent<SpriteRenderer>().flipX = false;
    }

}
