using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : BaseProjectile
{
    [SerializeField]
    private Vector2 velocity;

    public override void TickUpdate()
    {
        Move(velocity);
    }

    #region Getters & Setters
    public void SetVelocity(Vector2 newVelocity)
    {
        velocity = newVelocity;
    }

    public Vector2 GetVelocity()
    {
        return velocity;
    }

    #endregion

    public void RandomDirection()
    {
        int randomNumber = Random.Range(0, 4);
        velocity = new Vector2(Mathf.RoundToInt(Mathf.Cos(randomNumber * Mathf.PI / 2)), Mathf.RoundToInt(Mathf.Sin(randomNumber * Mathf.PI / 2)));
    }

    public override void Start()
    {
        base.Start();
        RandomDirection();
    }

}
