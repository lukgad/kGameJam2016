using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {

	public int miraclesToPerform = 10;
	public Text scoreText;
	public GameObject gameDone;

	public static readonly string TEXT_TEMPLATE = "Remaining miracles: ";

	void Start () {
		updateRemainingMiraclesText ();
	}

	public void miraclePerformed() {
		miraclesToPerform--;
		updateRemainingMiraclesText ();
		if (miraclesToPerform <= 0) {
			setScoreTest ("CUSTOMER IS HAPPY");
			StartCoroutine(over (1f));
		}
	}


	IEnumerator over(float startWait) {
		yield return new WaitForSeconds (startWait);
		Time.timeScale = 0f;
		gameDone.SetActive(true);
	}
	private void updateRemainingMiraclesText() {
		setScoreTest(TEXT_TEMPLATE + miraclesToPerform);
	}

	public void setScoreTest(string text) {
		scoreText.text = text;
	}
}
