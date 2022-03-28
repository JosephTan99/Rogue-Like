using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles the tempo and ticks of the game. 
/// </summary>
public class TempoManager : MonoBehaviour
{
    //Singleton Pattern
    public static TempoManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private float bpm;
    private float timeCountA;
    private float timeCountE;


    public int frameCount;

    /// <summary>
    /// A Delegate to store actions to be called on beat.
    /// </summary>
    public event UnityAction TickA;
    /// <summary>
    /// A Delegate to store actions to be called after the beat.
    /// </summary>
    public event UnityAction TickE;

    #region Getters & Setters
    /// <summary>
    /// Updates the bpm value to the new bpm value, max 120 bpm
    /// </summary>
    /// <param name="newBpm"></param>
    public void SetBpm(float newBpm)
    {
        bpm = newBpm;
        timeCountA = 60 / bpm;
    }

    /// <summary>
    /// Returns the current bpm.
    /// </summary>
    /// <returns></returns>
    public float GetBpm()
    {
        return bpm;
    }
    #endregion


    private void Update()
    {
        BeatUpdate();
    }

    private void BeatUpdate()
    {
        timeCountA -= Time.deltaTime;
        if (timeCountA <= 0)
        {
            OnBeatA();
            timeCountA = 60 / bpm;
            timeCountE = 45 / bpm;
        }

        timeCountE -= Time.deltaTime;
        if (timeCountE <= 0)
        {
            OnBeatE();
        }
    }

    private void OnBeatA()
    {
        TickA?.Invoke();
        //Tick = null;
        //Tick += MovementManager.instance.Move;
        MovementManager.instance.ResetParam();
    }

    private void OnBeatE()
    {
        TickE?.Invoke();

    }
}
