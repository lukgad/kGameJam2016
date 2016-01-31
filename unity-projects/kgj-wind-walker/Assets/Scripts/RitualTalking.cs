using UnityEngine;
using System.Collections;

public class RitualTalking : MonoBehaviour {
	public GameObject wow;
	public GameObject such;
	public GameObject doge;
	// Use this for initialization
	void Start () {
		go ();
	}

	private void go() {
		StartCoroutine (SpawnTalks (wow, 8f));
		StartCoroutine (SpawnTalks (such, 17f));
		StartCoroutine (SpawnTalks (doge, 24f));
		StartCoroutine (SpawnTalks (wow, 30f));
	}
	

	IEnumerator SpawnTalks(GameObject cloud, float startWait) {
			yield return new WaitForSeconds (startWait);
			cloud.GetComponent<Renderer>().sortingLayerName = "UI";
			Instantiate (cloud, cloud.transform.position, Quaternion.identity);
		}
}
