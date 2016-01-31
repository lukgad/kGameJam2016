using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RainPointerController : MonoBehaviour {

	public float branchLeftBorder = 0;
	public float branchRightBorder = 0;
	public float groundHeight = 0;
	public GameObject rainSpot;
	public int numberOfMiraclesToSpawn = 15;

	public GameObject retryObject;

	private static readonly float RAIN_SPOT_WIDTH = 2f;
	bool gameOver = false;
	void Start () {
		wave ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void wave() {
		StartCoroutine(SpawnRainSpots(3f, 3f, numberOfMiraclesToSpawn));
	}

	IEnumerator SpawnRainSpots(float startWait, float interval, int numberOfSpots) {
		yield return new WaitForSeconds (startWait);
		for (int i = 0; i < numberOfSpots; i++) {
			rainSpot.GetComponent<Renderer>().sortingLayerName = "Foreground";
			Instantiate (rainSpot, CalculateRainSpotPosition (), Quaternion.identity);

			yield return new WaitForSeconds (interval);
		}

		StartCoroutine(over (4f));
	}


	IEnumerator over(float startWait) {
		yield return new WaitForSeconds (startWait);
		Time.timeScale = 0f;
		retryObject.SetActive(true);
	}


	private Vector3 CalculateRainSpotPosition (){
		float calcPositionX = Random.Range(branchLeftBorder, branchRightBorder);

		return new Vector3 (calcPositionX, groundHeight, 0);
	}


}
