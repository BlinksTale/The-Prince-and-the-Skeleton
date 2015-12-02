using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// Fallen offscreen? Restart
		if (player.transform.position.y < -15.5f) {
			Debug.Log ("Fell offscreen!");
			Application.LoadLevel(Application.loadedLevel);
		}

		// Reset level
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
