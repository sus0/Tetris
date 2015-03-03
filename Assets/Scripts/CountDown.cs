using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {
	public GameObject one;
	public GameObject two;
	public GameObject three;

	private Spawner m_SpawnerScript;
	// Use this for initialization
	void Start () 
	{
		m_SpawnerScript = GameObject.Find ("Spawn").GetComponent<Spawner>();
		m_SpawnerScript.enabled = false;
		GetReady();
	}
	
	void GetReady ()
	{
		Instantiate(one, transform.position, Quaternion.identity);

	}
}
