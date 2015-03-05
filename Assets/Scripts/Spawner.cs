using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] prefabs;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public int GenerateRandomNumber()
	{
		return Random.Range(0, prefabs.Length);
	}

	public void Spawn( int nIndex )
	{
		Instantiate(prefabs[nIndex], transform.position, Quaternion.identity);
	}

	public void SpawnFirstBlock ()
	{
		Spawn (GenerateRandomNumber());
	}
}
