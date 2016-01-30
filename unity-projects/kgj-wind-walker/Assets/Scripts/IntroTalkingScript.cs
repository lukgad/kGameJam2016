using UnityEngine;
using System.Collections;

public class IntroTalkingScript : MonoBehaviour {
	public GameObject leftMoney;
	public GameObject leftAccept;
	public GameObject leftCloud;
	public GameObject rightMoney;
	public GameObject rightAccept;
	public GameObject rightCloud;

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
		StartCoroutine (SpawnRainSpots (leftAccept, 6f));
		StartCoroutine (SpawnRainSpots (leftMoney, 10f));
		StartCoroutine (SpawnRainSpots (rightMoney, 14f));
		StartCoroutine (SpawnRainSpots (leftAccept, 18f));
		StartCoroutine (SpawnRainSpots (rightAccept, 18f));
		StartCoroutine (LoadLevelAfterTime (22f));
	}

	private void LoadNextLevenOnSpace() {
		if(Input.GetKey("space")) {
			LoadNextLevel();
		}
	}

	private void LoadNextLevel() {
		Application.LoadLevel("RunningForWater");
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
