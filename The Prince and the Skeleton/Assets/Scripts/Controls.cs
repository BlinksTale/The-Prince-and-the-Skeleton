using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	Rigidbody2D rigid;
	int rockWalls = 0;
	bool climbingWalls = false;
	public bool collect = false; //the player has the collectible - true (gonna be accessed by PrinceInteract

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rigid.AddForce(new Vector2(-10f, 0f));
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			rigid.AddForce(new Vector2(10f, 0f));
		}

		if (rockWalls > 0) {
			if (climbingWalls) {
				rigid.velocity *= 3f/4f;

				if (Input.GetKey(KeyCode.UpArrow)) {
					rigid.AddForce(new Vector2(0f, 10f));
				}
				if (Input.GetKey(KeyCode.DownArrow)) {
					rigid.AddForce(new Vector2(0f, -10f));
				}
			} else {
				if (Input.GetKey(KeyCode.UpArrow)) {
					climbingWalls = true;
					rigid.gravityScale = 0;
				}
			}
		} else {
			if (climbingWalls) {
				climbingWalls = false;
				rigid.gravityScale = 1;
			}
		}
	}

	//collision detection for collectible items
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Collect") {
			col.gameObject.active= false;
			collect = true;
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		Debug.Log ("Collided with " + c.gameObject.name);
		if (c.gameObject.tag == "RockWall") {
			rockWalls++;
			Debug.Log ("Entered RockWall");
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		if (c.gameObject.tag == "RockWall") {
			rockWalls--;
			Debug.Log ("Exited RockWall");
		}
	}
}
