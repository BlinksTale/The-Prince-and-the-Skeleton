using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	float edgeLeft, edgeRight;
	bool facingLeft = true;
	bool turning = false;

	float speed = 50f;

	// Use this for initialization
	void Start () {
		Transform p = this.transform.parent;
		BoxCollider2D range = p.GetComponent<BoxCollider2D>();
		CircleCollider2D collider = this.GetComponent<CircleCollider2D>();
		edgeLeft  = p.position.x - range.size.x / 2f + collider.radius;// * 9f / 16f;
		edgeRight = p.position.x + range.size.x / 2f - collider.radius;// * 9f / 16f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!turning) {
			if (facingLeft && this.transform.position.x > edgeLeft) {
				this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0f));
			} else if (!facingLeft && this.transform.position.x < edgeRight) {
				this.GetComponent<Rigidbody2D>().AddForce(new Vector2( speed, 0f));
			} else {
				Turn(2f);
			}
		}
	}

	void Turn(float turnSpeed) {
		// Check not implemented here as to allow emergency turns mid turn too
		turning = true;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		facingLeft = !facingLeft;
		Invoke ("FinishTurn", turnSpeed);
	}

	void FinishTurn() {
		turning = false;
	}

	public void PlayerAlert(Vector3 pos) {
		float x = this.transform.position.x;
		if ((pos.x > x && facingLeft) || (pos.x < x && !facingLeft)) {
			Turn (.5f);
		}
	}
}
