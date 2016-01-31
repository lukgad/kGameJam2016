using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeController : MonoBehaviour
{

    private float remainigTime;
    private float hitColorTime;
    public Text scoreText;

    private static readonly string TEXT_TEMPLATE = ": ";
    private float time;
    private bool timeIsRunning;

    void Start()
    {
        remainigTime = GameplayControl.Instance.toWayTimeLimit + 10.0f;
        timeIsRunning = true;
        updateRemainingTime();
        time = Time.time + 1.0f;
        hitColorTime = Time.time;
    }


    void FixedUpdate()
    {
        if (time < Time.time && timeIsRunning)
        {
            remainigTime--;
            updateRemainingTime();
            time = Time.time + 1.0f;
        }
        if (remainigTime <= 0.0f)
        {
            timeIsRunning = false;
            gameObject.AddComponent<GameOverScript>();
            GameplayControl.Instance.StopBackground();
            GameplayControl.Instance.StopGround();
            GameplayControl.Instance.StopPlayer();
        }
        if(hitColorTime < Time.time)
        {
            scoreText.color = Color.black;
        }
    }

    public void collisionWithObstacle()
    {
        remainigTime--;
        updateRemainingTime();
        scoreText.color = Color.red;
        hitColorTime = Time.time + 0.5f;
    }

    private void updateRemainingTime()
    {
        scoreText.text = TEXT_TEMPLATE + remainigTime;
    }

    internal void StopTimer()
    {
        timeIsRunning = false;
    }

    internal void StartTimer()
    {
        timeIsRunning = true;
    }
}
