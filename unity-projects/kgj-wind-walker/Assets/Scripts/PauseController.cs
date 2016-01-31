using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject canvasPause;
	private bool gameOver = false;
	private bool paused = false;

	
	// Update is called once per frame
	void Update () {
		listenToEscape ();
	}

	private void escapePressed() {
		if (gameOver) {
			goToMenu();
		}
		else if (!gameOver && !paused) {
			pauseGame();
		}
		else if (!gameOver && paused) {
			unpauseGame();
		}

	}

	private void listenToEscape(){
		if(Input.GetKeyDown(KeyCode.Escape)) {
			escapePressed();
		}
	}

	private void pauseGame() {
		paused = true;		
		canvasPause.SetActive (true);
		Time.timeScale = 0f;
	}

	public void goToMenu() {
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}

	public void unpauseGame() {
		paused = false;
		Time.timeScale = 1f;
		canvasPause.SetActive (false);
	}

	public void retry() {
		Time.timeScale = 1f;
		Application.LoadLevel ("RitualScene");
	}
}
