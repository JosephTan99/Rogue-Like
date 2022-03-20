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
        
    }

    public void Move()
    {
        Vector2 dir = InputManager.instance.GetDir();
        transform.DOJump(transform.position + (Vector3)dir, 0.25f, 1, 0.5f);
        if (dir.x < 0) GetComponent<SpriteRenderer>().flipX = true;
        else if(dir.x > 0) GetComponent<SpriteRenderer>().flipX = false;
    }

}
