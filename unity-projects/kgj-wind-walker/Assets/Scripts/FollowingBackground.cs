using UnityEngine;
using System.Collections;

public class FollowingBackground : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = gameObject.transform.position;
		temp.x = player.transform.position.x;
		gameObject.transform.position = temp;
	
	}
}
