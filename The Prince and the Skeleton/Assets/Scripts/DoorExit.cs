using UnityEngine;
using System.Collections;

public class DoorExit : MonoBehaviour {
	public int levelIndex = -1; 

	void OnTriggerEnter2D (Collider2D c) {
		if(levelIndex == -1){
			// On triggered, restart level
			Debug.Log ("Door triggered with " + c.gameObject.name);
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else {
			Application.LoadLevel(levelIndex);
		}
	}
}
