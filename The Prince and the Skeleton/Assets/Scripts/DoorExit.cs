using UnityEngine;
using System.Collections;

public class DoorExit : MonoBehaviour {
	public string levelString = ""; 

	void OnTriggerEnter2D (Collider2D c) {
		if(levelString == ""){
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else {
			Application.LoadLevel(levelString);
		}
	}
}
