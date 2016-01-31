using UnityEngine;
using System.Collections;

public class WaterTargetControl : MonoBehaviour {


    internal bool movedAway = false;
    private float time;

    // Use this for initialization
    void Start () {
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        var pScroll = GameplayControl.Instance.playerControl.GetComponent<ScrollingScript>();
		var isVisible = fakeBody().IsVisibleFrom(Camera.main);
		if (isVisible && movedAway)
        {
            pScroll.isLinkedToCamera = false;
            GameplayControl.Instance.GetComponent<EnemySpawningControl>().stopSpawning();
            GameplayControl.Instance.GetComponent<TimeController>().StopTimer();
            GameplayControl.Instance.backgroundScrollingScript.StopMoving();
            GameplayControl.Instance.groundScrollingScript.StopMoving();
        }
		if (!isVisible && !movedAway) {
			movedAway = true;
		}
    }

    public void DebugTime()
    {
        Debug.Log(Time.time - time);
    }

	private Renderer fakeBody() {
		return transform.FindChild ("WaterTargetFakeBody").GetComponent<Renderer> ();
	}
}
