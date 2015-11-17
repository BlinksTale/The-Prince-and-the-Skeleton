using UnityEngine;
using System.Collections;

public class FallStraight : MonoBehaviour {

	Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// And cap horizontal motion to zero if falling
		if (rigid.velocity.y < -.5f) {
			Vector2 newVel = rigid.velocity;
			newVel.x = 0f;
			rigid.velocity = newVel;
		}
	}
}
