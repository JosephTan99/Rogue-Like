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


}
