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
    private float timeCount;
    /// <summary>
    /// A Delegate to store actions to be called on beat.
    /// </summary>
    public event UnityAction Tick;
    /// <summary>
    /// A Delegate to store actions to be called after the beat.
    /// </summary>
    public event UnityAction EndTick;

    #region Getters & Setters
    /// <summary>
    /// Updates the bpm value to the new bpm value, max 120 bpm
    /// </summary>
    /// <param name="newBpm"></param>
    public void SetBpm(float newBpm)
    {
        bpm = newBpm;
        timeCount = 60 / bpm;
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
        timeCount -= Time.deltaTime;
        if (timeCount <= 0)
        {
            OnBeat();
            timeCount = 60 / bpm;
        }
    }

    private void OnBeat()
    {
        Tick?.Invoke();
        //Tick = null;
        //Tick += MovementManager.instance.Move;
        InputManager.instance.ResetParam();
    }
}
