using UnityEngine;
using System.Collections;

public class IntroTalkingScript : MonoBehaviour {
	public GameObject left;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void go() {
		//StartCoroutine(SpawnRainSpots(
	}

	/*
	IEnumerator SpawnRainSpots(GameObject cloud, float startWait) {
		yield return new WaitForSeconds (startWait);
			cloud.GetComponent<Renderer>().sortingLayerName = "UI";
			Instantiate (cloud, cloud.transform.position, Quaternion.identity);
		}
	}*/
}
