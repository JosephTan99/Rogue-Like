using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public void Move(Vector2 dir)
    {
        gameObject.transform.position += (Vector3)dir;
    }
}
