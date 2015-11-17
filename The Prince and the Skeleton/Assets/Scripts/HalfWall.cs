using UnityEngine;
using System.Collections;

public class HalfWall : MonoBehaviour {

	GameObject player;
	Collider2D collider;
	bool leftTrigger = true;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		collider = this.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (collider.isTrigger) {
			if (!Input.GetKey(KeyCode.DownArrow) && player.transform.position.y >= this.transform.position.y + 0.9f) {
				// Player high enough, turn solid!		
				collider.isTrigger = false;
			}
		} else {
			if (Input.GetKey(KeyCode.DownArrow) || player.transform.position.y <= this.transform.position.y + 0.1f) {
				// Trying to go lower? Make a trigger!
				collider.isTrigger = true;
				leftTrigger = false;
			}
		}

	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			leftTrigger = true;
		}
	}

}
