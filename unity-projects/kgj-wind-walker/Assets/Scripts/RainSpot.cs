using UnityEngine;
using System.Collections;

public class RainSpot : MonoBehaviour {

	public float requiredWateringTime = 1f;

	private static readonly string PLAYER_TAG ="Player";
	private float spacePressTime =  0f;
	private float spaceReleaseTime =  0f;
	private bool spacePressed = false;

	
	void Update () {
		appendSpaceTime ();
		handleWateringTime ();
	}

	void OnTriggerStay2D(Collider2D collider) {
		if(collider.gameObject.tag == PLAYER_TAG) {
			getSpace ();
		}
	}

	private void getSpace() {
		if(Input.GetKeyDown("space")) {
			spacePressed = true;	
		}
		if(Input.GetKeyUp("space")) {
			spacePressed = false;
		}
	}

	private void appendSpaceTime() {
		if (spacePressed) {
			spacePressTime += Time.deltaTime;
		}
	}

	private void handleWateringTime() {
		if (spacePressTime > requiredWateringTime) {
			Debug.Log ("Watering time: " + spacePressTime + "\n Destroying spot");
			Destroy (gameObject);
		}
	}
}