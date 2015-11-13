using UnityEngine;
using System.Collections;

public class DoorExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D (Collider2D c) {
		// On triggered, restart level
		Debug.Log ("Door triggered with " + c.gameObject.name);
		Application.LoadLevel(Application.loadedLevel);
	}
}
