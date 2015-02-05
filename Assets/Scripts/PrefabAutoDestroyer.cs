using UnityEngine;
using System.Collections;

public class PrefabAutoDestroyer : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(transform.childCount == 0){
			Destroy(gameObject);
		}
	}
}
