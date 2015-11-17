using UnityEngine;
using System.Collections;

public class BoulderFall : MonoBehaviour {
	bool _isTriggered = false; //Check for Trigger Once

	void OnTriggerEnter2D(Collider2D col) {
		//Check for Player Entering Area of Rock Fall
		if (_isTriggered == false && col.gameObject.tag == "Player") {
			Transform boulder = this.gameObject.transform.GetChild (0);
			boulder.parent = null;
			boulder.GetComponent<Rigidbody2D>().isKinematic = false;
			_isTriggered = true;
		}
	}
}

