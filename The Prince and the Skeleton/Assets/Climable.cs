using UnityEngine;
using System.Collections;

public class Climable : MonoBehaviour {

	GameObject subject;

	// Use this for initialization
	void Start () {
	
	}

	void Update() {
//		if (subject != null) {
//			subject.GetComponent<Rigidbody2D>().velocity *= 3f/4f;
//		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		// On triggered, restart level
//		if (c.gameObject.tag == "Player") {
//			c.GetComponent<Rigidbody2D>().gravityScale = 0;
//			subject = c.gameObject;
//		}
	}

	void OnTriggerExit2D (Collider2D c) {
		// On triggered, restart level
//		if (c.gameObject.tag == "Player") {
//			c.GetComponent<Rigidbody2D>().gravityScale = 1;
//			subject = null;
//		}
	}
}
