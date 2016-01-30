using UnityEngine;
using System.Collections;

public class RunningEndsSpawner : MonoBehaviour {

    // Use this for initializatio
    public Vector3 placement;
    public bool reverse = false;

    void Awake()
    {
    
    }
     
	void Start () {
        var xpos = (Camera.main.transform.position.x + GameplayControl.Instance.distance);
        xpos = reverse ? xpos : xpos * -1;
		placement = new Vector3(xpos, transform.position.y, 0);
        transform.position = placement;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
