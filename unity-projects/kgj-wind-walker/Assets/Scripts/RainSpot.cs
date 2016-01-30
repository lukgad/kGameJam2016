﻿using UnityEngine;
using System.Collections;

public class RainSpot : MonoBehaviour {

	public float requiredWateringTime = 1f;

	private static readonly string PLAYER_TAG ="Player";
	private float spacePressTime =  0f;
	private float spaceReleaseTime =  0f;
	private bool spacePressed = false;
	private ScoreController scoreController;
	private ParticleSystem wateringEnabledParticleSystem;
	void Start() {
		findScoreController ();
		findRunneyTreeEmission ();
	}

	void Update () {
		appendSpaceTime ();
		handleWateringTime ();
	}

	void OnTriggerStay2D(Collider2D collider) {
		if(collider.gameObject.tag == PLAYER_TAG) {
			getSpace ();
			wateringEnabledParticleSystem.Play ();
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if(collider.gameObject.tag == PLAYER_TAG) {
			wateringEnabledParticleSystem.Stop ();
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
			scoreController.miraclePerformed ();
			wateringEnabledParticleSystem.Stop ();
			Destroy (gameObject);
		}
	}

	private void findScoreController() {
		GameObject scoreControllerObject = GameObject.FindWithTag ("ScoreController");
		if(scoreControllerObject != null) {
			scoreController = scoreControllerObject.GetComponent <ScoreController>();
		}
		if (scoreController == null) {
			Debug.Log ("Cannot find 'ScoreController' script");
		}
	}

	private void findRunneyTreeEmission() {
		GameObject runneyTreeEmissionObject = GameObject.FindWithTag ("RunneyTreeEmission");
		if(runneyTreeEmissionObject != null) {
			wateringEnabledParticleSystem = runneyTreeEmissionObject.GetComponent <ParticleSystem>();
		}
		if (wateringEnabledParticleSystem == null) {
			Debug.Log ("Cannot find 'RunneyTreeEmission' script");
		}
	}

}