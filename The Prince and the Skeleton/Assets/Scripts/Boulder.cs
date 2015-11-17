using UnityEngine;
using System.Collections;

public class Boulder : MonoBehaviour {
//scripts pertaining to the boulder 
	void OnCollisionEnter2D (Collision2D col) {
		if ( col.gameObject.CompareTag ( "Player" ) ) {
			var normal = col.contacts[0].normal;
			if (normal.y > 0) { //if the boulder fell on player 
				Debug.Log ("Boulder, You Hit the Player");
				//add force to knockback
				col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, 200f));
			}
		}
	}
}
