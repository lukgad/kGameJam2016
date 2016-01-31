using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	void Update() {
		QuitOnEscape ();
	}

	public void StartGame() {
        Application.LoadLevel("Intro");
	//	.LoadLevel ("GameScene");
	}

	public void ExitGame() {
		Application.Quit();
	}

	private void QuitOnEscape() {
		if (Input.GetKey (KeyCode.Escape)) {
			ExitGame();
		}
	}
}
