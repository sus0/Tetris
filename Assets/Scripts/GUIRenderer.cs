using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GUIRenderer : MonoBehaviour {

	public Sprite[] sprites;
	private Image nextImage;
	private int _nextIdx;
	public int NextIdx
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

	// Use this for initialization
	void Start () {
		EnableRender = false;
		nextImage = GetComponent<Image>();
		if (nextImage == null)
		{
			throw new Exception("Cannot find image component of GameObject " + gameObject.name);
		}
	}

	// Update is called once per frame
	void Update () {

		if (EnableRender)
		{
			nextImage.sprite = sprites[_nextIdx];
		}

	}
}
