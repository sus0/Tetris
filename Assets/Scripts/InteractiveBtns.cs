using UnityEngine;
using System.Collections;

public class InteractiveBtns : MonoBehaviour {
	// Update is called once per frame
	public void StartButtonOnClick(){
		Application.LoadLevel("MainScene");
	}

	public void ExitButtonOnClick(){
		Application.Quit();
	}

	public void ResumeButtonOnClick(){
		//Time.timeScale = 1;
		PauseMenuControl pauseMenu = GameObject.Find("Main Camera").GetComponent<PauseMenuControl>();
		pauseMenu.UnPauseGame();
	}
}
