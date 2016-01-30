using UnityEngine;
using System.Collections;

public class RunneyTree : MonoBehaviour {

	public float moveSpeed = 0;
	private static readonly string RAINSPOT_TAG_NAME = "RainSpot";
	private RainPointerController rainSpotPointerController;


	private static readonly string WATERING_ANIM = "Watering";
	private static readonly string RUNNING_ANIM = "Running";

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		rainSpotPointerController = GameObject.FindWithTag ("RainSpotPointerController").GetComponent<RainPointerController>();
	}
	
	// Update is called once per frame
	void Update () {
		KeyListener ();
		getAllRainSpots ();
		Walls ();
	}

	private void KeyListener() {

		if (Input.GetKeyDown ("left")) {
			MoveRight ();		
		} else if (Input.GetKeyDown ("right")) {
			MoveLeft ();		
		}
		if(Input.GetKeyUp("left") && !Input.GetKey("right")) {
			StopAfterKeyRelease();
		}
		if(Input.GetKeyUp("right") && !Input.GetKey("left")) {
			StopAfterKeyRelease();
		}
	}

	private GameObject[] getAllRainSpots () {
		return GameObject.FindGameObjectsWithTag (RAINSPOT_TAG_NAME);
	}

	private void MoveRight() {
		RotateRight ();
		GetComponent<Rigidbody2D> ().velocity = transform.right * -1 * moveSpeed;
		anim.SetBool (RUNNING_ANIM, true);
		anim.SetBool (WATERING_ANIM, false);
	}

	private void MoveLeft() {
		RotateLeft ();
		GetComponent<Rigidbody2D> ().velocity = transform.right * -1 * moveSpeed;
		anim.SetBool (RUNNING_ANIM, true);
		anim.SetBool (WATERING_ANIM, false);
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
		anim.SetBool (RUNNING_ANIM, false);
		anim.SetBool (WATERING_ANIM, false);
	}

	private void Walls() {
		if (gameObject.transform.position.x < rainSpotPointerController.branchLeftBorder && Input.GetKey("left")) {
			GetComponent<Rigidbody2D> ().velocity = transform.right * 0f;
		} 
		if (gameObject.transform.position.x > rainSpotPointerController.branchRightBorder && Input.GetKey("right")) {
			GetComponent<Rigidbody2D> ().velocity = transform.right * 0f;
		} 
	}
}

