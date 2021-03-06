﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawningControl : MonoBehaviour
{

    private List<Transform> enemies;
    private List<Transform> foregrounds;
    public int numberOfEnemies = 200;
    public int numberOfForeground = 3;
    public Vector3 enemiesTimes = new Vector3(1.0f, 0.8f, 1.5f);
    public Vector3 foregroundTimes = new Vector3(1.0f, 1.0f, 1.5f);
    public float spawnRateMin = 0.5f;
    public Transform enemyTemplate;
    public Transform foregroundTemplate;
    private bool timeIsRunning;
    private bool reverse = false;
    private float postionForEnemies;
    private float positionForForeground;
    public int numberOfProps;
    private List<Transform> props;
    public Vector3 propsTimes = new Vector3(1.0f, 1.0f, 1.5f);
    private float positionForProps;

    // Use this for initialization
    void Start()
    {
        enemies = new List<Transform>();
        foregrounds = new List<Transform>();
        props = new List<Transform>();
        timeIsRunning = true;

        postionForEnemies = gameObject.transform.FindChild("EnemySpawningPoint").transform.position.y;
        positionForForeground = gameObject.transform.FindChild("BushSpawningPoint").transform.position.y;
        positionForProps = gameObject.transform.FindChild("UpperBushSpawningPoint").transform.position.y;
        enemiesTimes.x = Time.time + enemiesTimes.x;
        foregroundTimes.x = Time.time + foregroundTimes.x;
        propsTimes.x = Time.time + propsTimes.x;

    }

    // Update is called once per frame
    void Update()
    {
        var leftBorder = Camera.main.ViewportToWorldPoint(
                                new Vector3(0, 0, 0)
                            ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
                              new Vector3(1, 0, 0)
                          ).x;
        if (canSpawn(enemiesTimes,enemies,numberOfEnemies))
        {
            addObject(ref enemiesTimes, enemies, enemyTemplate, "Characters", postionForEnemies, rightBorder, leftBorder, true);
        }
        if (canSpawn(foregroundTimes, foregrounds, numberOfForeground))
        {
            addObject(ref foregroundTimes, foregrounds, foregroundTemplate, "Foreground", positionForForeground, rightBorder, leftBorder, false);
        }
        if (canSpawn(propsTimes, props, numberOfProps))
        {
            addObject(ref propsTimes, props, foregroundTemplate, "Props", positionForProps, rightBorder, leftBorder, false);
        }

        cleanupNulls(foregrounds);
        cleanupNulls(enemies);
        cleanupNulls(props);

    }

    private bool canSpawn(Vector3 times, List<Transform> target, int limit)
    {
        Debug.Log(times.x  + "    "+Time.time);
        return times.x < Time.time && timeIsRunning && target.Count < limit;
    }

    private void addObject(ref Vector3 timer, List<Transform> target, Transform baseSprite, string sortingLayer, float yPos, float rightBorder, float leftBorder, bool isValidForScore)
    {
        var currentFG = Instantiate(baseSprite) as Transform;
        currentFG.transform.position = new Vector3(reverse ? rightBorder : leftBorder, yPos, 0);
        currentFG.GetComponent<Renderer>().sortingLayerName = sortingLayer;
        target.Add(currentFG);
        currentFG.gameObject.AddComponent<EnemyRemoverControl>();
        GameplayControl.Instance.AddScrollingScriptToSpawned(currentFG.gameObject);
        currentFG.GetComponent<EnemyRemoverControl>().isValidForScore = isValidForScore;
        timer = new Vector3(Time.time + Random.Range(timer.y, timer.z), timer.y, timer.z);
    }

    private void cleanupNulls(List<Transform> target)
    {
        target.ForEach(e =>
        {
            if (e == null)
            {
                target.Remove(e);
            }
        });
    }
    

    private void killAll(List<Transform> target)
    {
        target.ForEach(e =>
        {
            if (e != null)
            {
                DestroyObject(e.gameObject);
                target.Remove(e);
            }
        });
    }
    public void stopSpawning()
    {
        killAll(enemies);
        killAll(foregrounds);
        killAll(props);
        timeIsRunning = false;
    }

    public void startSpawning()
    {
        timeIsRunning = true;
    }

    public void ReverserSpawnBorder()
    {
        reverse = !reverse;
    }
}
