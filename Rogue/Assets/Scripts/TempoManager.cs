using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempoManager : MonoBehaviour
{
    /// <summary>
    /// Handles the tempo of the game.
    /// </summary>



    //Singleton Pattern
    public static TempoManager instance;

    private void Awake()
    {
        instance = this;
    }

    private float bpm;
    private float timeCount;
    private event UnityAction Tick;

    public void ResetBpm(float newBpm)
    {
        timeCount = 60/bpm;
        bpm = newBpm;
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
        
    }

    public void AddTick()
    {

    }
}
