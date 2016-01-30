using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	void Update() {
		QuitOnEscape ();
	}

	public void StartGame() {
		SceneManager.LoadScene ("Intro");
	//	.LoadLevel ("GameScene");
	}

	public void ExitGame() {
		Application.Quit();
	}

	private void QuitOnEscape() {
		if (Input.GetKey ("escape")) {
			ExitGame();
		}
	}
}
