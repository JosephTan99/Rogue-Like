using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// Handles all inputs in the code.
    /// </summary>

    //Singleton Pattern
    public static InputManager instance;

    private void Awake()
    {
        instance = this;
    }


    private Vector2 dir;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
    }

    public Vector2 GetDir()
    {
        return dir;
    }
}
