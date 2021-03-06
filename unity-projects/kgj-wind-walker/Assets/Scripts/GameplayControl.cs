﻿using UnityEngine;
using System.Collections;
using System;

public class GameplayControl: MonoBehaviour {


    public float timeLimit = 30;
    public float toWayTimeLimit;
    public float defaultSpeed = 10;
    public float distance;
    public ScrollingScript groundScrollingScript;
    public ScrollingScript backgroundScrollingScript;
    public PlayerControls playerControl;
    public static GameplayControl Instance;
    private bool initReverse = false;
    private float initReverseTime;
    private float reverse = -1;

    void Awake()
    {
        distance = defaultSpeed * timeLimit;
        toWayTimeLimit = timeLimit * 2;
        initReverseTime = Time.time + 5;
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of Difficulty!");
        }


        groundScrollingScript = GameObject.Find("Ground").GetComponent<ScrollingScript>();
        backgroundScrollingScript = GameObject.Find("ScrollingBackground").GetComponent<ScrollingScript>();
        playerControl = GameObject.Find("RunningPlayer").GetComponent<PlayerControls>();

        Instance = this;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(initReverse)
        {
            playerControl.GetComponentInChildren<Animator>().SetBool("Running", false);
            if(initReverseTime <= Time.time)
            {
                initReverse = false;
                playerControl.GetComponentInChildren<Animator>().SetBool("Running", true);
                Debug.Log("will go back");
                playerControl.GoBack();
                backgroundScrollingScript.StartMoving();
                backgroundScrollingScript.Reverse();
                groundScrollingScript.Reverse();
                groundScrollingScript.StartMoving();
                backgroundScrollingScript.RebuildList();
                groundScrollingScript.RebuildList();
                GetComponent<EnemySpawningControl>().ReverserSpawnBorder();
                GetComponent<EnemySpawningControl>().startSpawning();
                GetComponent<TimeController>().StartTimer();
                GetComponent<ComboController>().ResetCounter();

            }
        } else
        {
            initReverseTime = Time.time + 3.0f;
        }
	}

    internal void StopGround()
    {
        groundScrollingScript.StopMoving();
    }

    internal void StopBackground()
    {
        backgroundScrollingScript.StopMoving();
    }

    internal void StopPlayer()
    {
        playerControl.GetComponent<ScrollingScript>().StopMoving();
        playerControl.GetComponentInChildren<Animator>().SetBool("Running", false);

    }

    internal void InitReverseRun()
    {
        initReverse = true;
    }

    internal void AddScrollingScriptToSpawned(GameObject go)
    {
        go.AddComponent<ScrollingScript>();
        go.GetComponent<ScrollingScript>().speed = groundScrollingScript.speed;
        go.GetComponent<ScrollingScript>().direction = groundScrollingScript.direction;
    }
}
