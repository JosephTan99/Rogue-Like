using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempoManager : MonoBehaviour
{
    /// <summary>
    /// Handles the tempo of the game. Maximum 120 BPM, DO NOT go over this value.
    /// </summary>



    //Singleton Pattern
    public static TempoManager instance;

    private void Awake()
    {
        instance = this;
    }

    public float bpm;
    public float timeCount;
    public event UnityAction Tick;
    public event UnityAction EndTick;

    private void Update()
    {
        BeatUpdate();
    }





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
        Tick?.Invoke();
        //Tick = null;
        //Tick += MovementManager.instance.Move;
        InputManager.instance.ResetParam();
    }

}
