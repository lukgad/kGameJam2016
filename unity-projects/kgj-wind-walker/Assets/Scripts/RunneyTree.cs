using UnityEngine;
using System.Collections;

public class RunneyTree : MonoBehaviour {

	public float moveSpeed = 0;
	private static readonly string RAINSPOT_TAG_NAME = "RainSpot";

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		KeyListener ();
		getAllRainSpots ();
	}

	private void KeyListener() {

		if (Input.GetKeyDown ("left")) {
			MoveRight ();		
		} else if (Input.GetKeyDown ("right")) {
			MoveLeft ();		
		}
		if(Input.GetKeyUp("left")) {
			StopAfterKeyRelease();
		}
		if(Input.GetKeyUp("right")) {
			StopAfterKeyRelease();
		}
	}

	private GameObject[] getAllRainSpots () {
		return GameObject.FindGameObjectsWithTag (RAINSPOT_TAG_NAME);
	}

	private void MoveRight() {
		RotateRight ();
		GetComponent<Rigidbody2D> ().velocity = transform.right * -1 * moveSpeed;

	}

	private void MoveLeft() {
		RotateLeft ();
		GetComponent<Rigidbody2D> ().velocity = transform.right * -1* moveSpeed;


	}

	private void RotateRight() {
		Quaternion temp = transform.rotation;
		temp.y = 0;
		transform.rotation = temp;
	}

	private void RotateLeft() {
		Quaternion temp = transform.rotation;
		temp.y = 180;
		transform.rotation = temp;
	}

	private void StopAfterKeyRelease() {
		GetComponent<Rigidbody2D> ().velocity = transform.right * 0;
	}

	private void killRainSpot() {

	}


}

