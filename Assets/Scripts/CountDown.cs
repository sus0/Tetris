using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject go;

	private Spawner m_SpawnerScript;
	private Animator m_One;
	private Animator m_Two;
	private Animator m_Three;
	private Animator m_Go;


	// Use this for initialization
	void Start () 
	{
		m_SpawnerScript     	= GameObject.Find ("Spawn").GetComponent<Spawner>();
		m_SpawnerScript.enabled = false;

		m_One 					= one.GetComponent<Animator>();
		m_Two 					= two.GetComponent<Animator>();
		m_Three 				= three.GetComponent<Animator>();
		m_Go 					= go.GetComponent<Animator>();

		m_One.enabled 			= false;
		m_Two.enabled 			= false;
		m_Three.enabled 		= false;
		m_Go.enabled 			= false;


		StartCoroutine(GetReady());
	}
	
	private IEnumerator GetReady ()
	{
		// Wait for 2 sec; Dont start to count down immediately
		yield return new WaitForSeconds (2f);  
		m_Three.enabled = true;
		m_Three.Play("3_zoomin");
		StartCoroutine(PlayTwo());
	}
	private IEnumerator PlayTwo()
	{
		yield return new WaitForSeconds (2f);  
		m_Two.enabled = true;
		m_Two.Play("2_zoomin");
		StartCoroutine(PlayOne());
	}

	private IEnumerator PlayOne()
	{
		yield return new WaitForSeconds (2f);  
		m_One.enabled = true;
		m_One.Play("1_zoomin");
		StartCoroutine(PlayGo());
	}

	private IEnumerator PlayGo()
	{
		yield return new WaitForSeconds (2f); 
		m_Go.enabled = true;
		m_Go.Play("go_zoomin");
		StartCoroutine(GameStart());
	}

	private IEnumerator GameStart()
	{
		yield return new WaitForSeconds (1f); 
		m_SpawnerScript.enabled = true;
		m_One.enabled 			= false;
		m_Two.enabled 			= false;
		m_Three.enabled 		= false;
		m_Go.enabled 			= false;
	}
}
