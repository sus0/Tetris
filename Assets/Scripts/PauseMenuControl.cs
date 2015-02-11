using UnityEngine;
using System.Collections;

public class PauseMenuControl : MonoBehaviour {
    public GameObject pauseMenu;
    private Animator animator;
    private bool isPause = false;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        animator = pauseMenu.GetComponent<Animator>();
        animator.enabled = false;
	}
	
	// Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Space) && !isPause) {
            PauseGame();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && isPause) {
            UnPauseGame();
        }
    }
    void PauseGame() {
        animator.enabled = true;
        animator.Play("pausemenu_slidein");
        isPause = true;
        Time.timeScale = 0;
    }

    void UnPauseGame() {
        animator.Play("pausemenu_slideout");
        isPause = false;
        Time.timeScale = 1;
    }
}
