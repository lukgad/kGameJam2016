using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeController : MonoBehaviour
{

    private float remainigTime;
    public Text scoreText;

    private static readonly string TEXT_TEMPLATE = "Remaining time: ";
    private float time;
    private bool timeIsRunning;

    void Start()
    {
        remainigTime = GameplayControl.Instance.toWayTimeLimit + 10.0f;
        timeIsRunning = true;
        updateRemainingTime();
        time = Time.time + 1.0f;
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
    }

    public void collisionWithObstacle()
    {
        remainigTime--;
        updateRemainingTime();
    }

    private void updateRemainingTime()
    {
        scoreText.text = TEXT_TEMPLATE + remainigTime;
    }

    internal void StopTimer()
    {
        timeIsRunning = false;
    }
}
