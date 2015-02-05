using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] prefabs;

	// Use this for initialization
	void Start () {
		Spawn ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){
		int randomNum = Random.Range(0, prefabs.Length);
		Instantiate(prefabs[randomNum], transform.position, Quaternion.identity);
	}
}
