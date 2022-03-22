using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// System that manages the player's health.
/// </summary>
public class HealthManager : MonoBehaviour
{
    //Singleton Patter

    public static HealthManager instance;

    private void Awake()
    {
        instance = this;
    }

    private float health;


    #region Getters & Setters
    /// <summary>
    /// Sets the current health of the player.
    /// </summary>
    /// <param name="newHealth"></param>
    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    /// <summary>
    /// Returns the current player's health.
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        return health;
    }
    #endregion

    /// <summary>
    /// Reduces the health of the player according to the damage taken in parameter.
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        if (health - damage <= 0)
        {
            //Death to be added
            return;
        }
        health -= damage;
    }
}
