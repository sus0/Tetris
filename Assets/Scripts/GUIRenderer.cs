using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GUIRenderer : MonoBehaviour {

	public  Sprite[]  sprites;
	public  Font      btnFont;
	private Image 	  nextImage;
	private Animator  animGameOver;
	private int  _nextIdx;
	public  int  NextIdx
	{
		get
		{
			return this._nextIdx;
		}
		set
		{
			if ( value > 6 || value < 0 )
			{
				throw new Exception("Invalid next block index: "  + value );
			}
			this._nextIdx = value;
		}
	}
	public bool EnableRender { get; set; }
	public bool GameOver	 { get; set; }
	// Use this for initialization
	void Start () 
	{
		EnableRender 			= false;
		animGameOver 			= GameObject.Find("gameover").GetComponent<Animator>();
		animGameOver.enabled 	= false;
		nextImage 				= GetComponent<Image>();
		if (nextImage == null)
		{
			throw new Exception("Cannot find image component of GameObject " + gameObject.name);
		}
	}

	// Update is called once per frame
	void Update () 
	{

		if (EnableRender)
		{
			nextImage.sprite = sprites[_nextIdx];
		}

	}
	void OnGUI()
	{
		GUIStyle btnStyle = GUIStyle.none;
		btnStyle.fontSize = 50;
		btnStyle.font 	  = btnFont;
		if (GameOver)
		{
			animGameOver.enabled = true;
			animGameOver.Play ("gameover_fall");
			if (GUI.Button ( new Rect( ( Screen.width/2 - 150 ), Screen.height/2, 300, 50 ), "Play Again", btnStyle ) )
			{
				Application.LoadLevel("MainScene");
			}
			if (GUI.Button(new Rect( ( Screen.width/2 - 150 ), Screen.height/2 + 100, 300, 50), "Exit Game", btnStyle))
			{
				Application.Quit();
			}
		}
	}
}
