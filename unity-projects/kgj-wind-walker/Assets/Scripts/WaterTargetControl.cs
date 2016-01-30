using UnityEngine;
using System.Collections;

public class WaterTargetControl : MonoBehaviour {


    internal bool touched = false;
    private float time;

    // Use this for initialization
    void Start () {
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        var pScroll = GameplayControl.Instance.playerControl.GetComponent<ScrollingScript>();
        var isVisible = GetComponentInChildren<Renderer>().IsVisibleFrom(Camera.main);
        if (isVisible && !touched)
        {
            pScroll.isLinkedToCamera = false;
        }
    }

    public void DebugTime()
    {
        Debug.Log(Time.time - time);
    }
}
