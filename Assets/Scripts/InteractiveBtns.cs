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
}
