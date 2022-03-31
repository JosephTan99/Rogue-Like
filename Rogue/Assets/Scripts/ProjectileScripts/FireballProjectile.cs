using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : BaseProjectile
{
    [SerializeField]
    private Vector2Int velocity;

    public override void TickUpdateA()
    {
        Move(velocity);
    }

    #region Getters & Setters
    public void SetVelocity(Vector2Int newVelocity)
    {
        velocity = newVelocity;
    }

    public Vector2Int GetVelocity()
    {
        return velocity;
    }

    #endregion

    public override void Start()
    {
        base.Start();
        int randomNumber = Random.Range(0, 4);
        randomNumber = 0;
        velocity = new Vector2Int(Mathf.RoundToInt(Mathf.Cos(randomNumber * Mathf.PI / 2)), Mathf.RoundToInt(Mathf.Sin(randomNumber * Mathf.PI / 2)));
    }
}
