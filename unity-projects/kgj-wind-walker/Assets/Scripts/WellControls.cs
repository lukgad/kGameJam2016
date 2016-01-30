using UnityEngine;
using System.Collections;

public class WellControls : MonoBehaviour
{

    // Use this for initialization
    private float time;
    internal bool touched = false;
    void Start()
    {

        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var pScroll = GameplayControl.Instance.playerControl.GetComponent<ScrollingScript>();
        var isVisible = GetComponentInChildren<Renderer>().IsVisibleFrom(Camera.main);
        if (isVisible && !touched)
        {
            pScroll.isLinkedToCamera = false;
            GameplayControl.Instance.GetComponent<EnemySpawningControl>().stopSpawning();
            GameplayControl.Instance.GetComponent<TimeController>().StopTimer();
        }
    }



    public void DebugTime()
    {
        Debug.Log(Time.time - time);
    }
}
