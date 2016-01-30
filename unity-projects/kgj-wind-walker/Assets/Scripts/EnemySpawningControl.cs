using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawningControl : MonoBehaviour {

    private List<float> enemiesPos;
    private int numberOfEnemies;
    private float spawnRate = 1.0f;
    public Transform enemy1Prefab;
    private float time;
    private bool timeIsRunning;
    private Transform currentEnemy;
    private int index;
    private bool reverse = false;

    // Use this for initialization
    void Start () {
        enemiesPos = new List<float>();
        timeIsRunning = true;
        numberOfEnemies = (int) (GameplayControl.Instance.timeLimit / spawnRate);
        index = 0;
        for(int i = 0; i< numberOfEnemies; i++)
        {
          
            var mainCam = Camera.main;

            var leftBorder = mainCam.ViewportToWorldPoint(
                                 new Vector3(0, 0, 0)
                             ).x;

            var rightBorder = mainCam.ViewportToWorldPoint(
                                  new Vector3(1, 0, 0)
                              ).x;

            var topBorder = mainCam.ViewportToWorldPoint(
                                new Vector3(0, 0, 0)
                            ).y;

            var bottomBorder = mainCam.ViewportToWorldPoint(
                                   new Vector3(0, 1, 0)
                               ).y;

            var groundSize = GameplayControl.Instance.groundScrollingScript.transform.GetComponentInChildren<Renderer>().bounds.size.y;
            var render = enemy1Prefab.GetComponent<Renderer>();
            var ranY = bottomBorder + render.bounds.size.y + groundSize;
            Debug.Log(ranY + "");
            var posY = gameObject.transform.FindChild("EnemySpawningPoint").transform.position.y;
            enemiesPos.Add(posY);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (time < Time.time && timeIsRunning && currentEnemy == null && index < enemiesPos.Count)
        {
            var leftBorder = Camera.main.ViewportToWorldPoint(
                                 new Vector3(0, 0, 0)
                             ).x;

            var rightBorder = Camera.main.ViewportToWorldPoint(
                                  new Vector3(1, 0, 0)
                              ).x;
            currentEnemy = Instantiate(enemy1Prefab) as Transform;
            currentEnemy.transform.position = new Vector3(reverse ? rightBorder : leftBorder, enemiesPos[index], 0);
            currentEnemy.GetComponent<Renderer>().sortingLayerName = "Characters";
            index++;
            time = Time.time + 1.0f;
        }
        if(currentEnemy != null)
        {
            var visible = currentEnemy.GetComponent<Renderer>().IsVisibleFrom(Camera.main);
            if(!visible)
            {
                DestroyObject(currentEnemy.gameObject);
                currentEnemy = null;
            }
        }
    }

    public void stopSpawning()
    {
        if (currentEnemy != null)
        {
            DestroyObject(currentEnemy.gameObject);
        }
        currentEnemy = null;
        timeIsRunning = false;
    }

    public void startSpawning()
    {
        timeIsRunning = true;
        index = 0;
    }

    public void ReverserSpawnBorder()
    {
        reverse = !reverse;
    }
}
