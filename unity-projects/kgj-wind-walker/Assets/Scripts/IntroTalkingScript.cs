using UnityEngine;
using System.Collections;

public class IntroTalkingScript : MonoBehaviour {
	public GameObject leftMoney;
	public GameObject leftAccept;
	public GameObject leftCloud;
	public GameObject rightMoney;
	public GameObject rightAccept;
	public GameObject rightCloud;
	public GameObject leftMagic;
	public GameObject rightNoMagic;
	public GameObject rightNoCloud;
	public GameObject rightKonewka;
	public GameObject rightWell;
	public GameObject leftLeftAccept;

	public GameObject client;


	// Use this for initialization
	void Start () {
		go ();
	}
	
	// Update is called once per frame
	void Update () {
		LoadNextLevenOnSpace ();
		
	}

	private void go() {
		StartCoroutine (SpawnRainSpots (rightCloud, 2f));
		StartCoroutine (SpawnRainSpots (leftMagic, 6f));
		StartCoroutine (SpawnRainSpots (leftCloud, 10f));
		StartCoroutine (SpawnRainSpots (rightAccept, 14f));
		StartCoroutine (SpawnRainSpots (leftMoney, 18f));
		StartCoroutine (SpawnRainSpots (rightAccept, 22f));
		StartCoroutine(ClientLeaves(26f));
		StartCoroutine (SpawnRainSpots (rightNoMagic, 30f));
		StartCoroutine (SpawnRainSpots (rightNoCloud, 34f));
		StartCoroutine (SpawnRainSpots (rightKonewka, 38f));
		StartCoroutine (SpawnRainSpots (rightWell, 42f));
		StartCoroutine (SpawnRainSpots (leftLeftAccept, 46f));
		StartCoroutine (LoadLevelAfterTime (50f));
	}

	private void LoadNextLevenOnSpace() {
		if(Input.GetKey("space")) {
			LoadNextLevel();
		}
	}

	private void LoadNextLevel() {
		Application.LoadLevel("RunningForWater");
	}

	IEnumerator ClientLeaves(float startWait) {
		yield return new WaitForSeconds (startWait);
		Quaternion temp = client.transform.rotation;
		temp.y = 180;
		client.transform.rotation = temp;

		client.GetComponent<Rigidbody2D> ().velocity = transform.right * 4;
	}


	IEnumerator SpawnRainSpots(GameObject cloud, float startWait) {
		yield return new WaitForSeconds (startWait);
		cloud.GetComponent<Renderer>().sortingLayerName = "UI";
		Instantiate (cloud, cloud.transform.position, Quaternion.identity);
	}

	IEnumerator LoadLevelAfterTime(float startWait) {
		yield return new WaitForSeconds (startWait);
		LoadNextLevel ();
	}
}
