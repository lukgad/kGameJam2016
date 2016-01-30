using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {

	public int miraclesToPerform = 10;
	public Text scoreText;

	private static readonly string TEXT_TEMPLATE = "Remaining miracles: ";

	void Start () {
		updateRemainingMiraclesText ();
	}

	public void miraclePerformed() {
		miraclesToPerform--;
		updateRemainingMiraclesText ();
	}

	private void updateRemainingMiraclesText() {
		scoreText.text = TEXT_TEMPLATE + miraclesToPerform;
	}
}
