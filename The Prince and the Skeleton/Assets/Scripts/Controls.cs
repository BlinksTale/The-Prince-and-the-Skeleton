using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	Rigidbody2D rigid;
	int rockWalls = 0;
	bool climbingWalls = false;
	public bool collect = false; //the player has the collectible - true (gonna be accessed by PrinceInteract
	public GameObject visuals;
	public GameObject armLeft, armRight, legLeft, legRight;
	SacrificeTracker sacrificeTracker;
	bool falling = false;
	float lastPositionY = 0f;
	float fallingTime = 0f;
	bool tripped = false;

	// Use this for initialization
	void Start () {
		sacrificeTracker = SacrificeTracker.sacrificeTracker;
		if (sacrificeTracker.sacrificedArm) {
			armLeft.SetActive(false);
		}
		if (sacrificeTracker.sacrificedLeg) {
			legRight.SetActive(false);
			
		}

		rigid = this.GetComponent<Rigidbody2D>();
	}

	void RandomFall() {
		falling = true;
		Debug.Log ("Random fall!");
	}

	void RandomTrip() {
		tripped = true;
		if (rigid.velocity.x < 0f) {
			visuals.transform.eulerAngles = new Vector3(0f,0f,-90f);
		} else {
			visuals.transform.eulerAngles = new Vector3(0f,0f, 90f);
		}
		Debug.Log ("Random trip!");
		Invoke ("TripRecovery", Random.Range (2f, 4f));
	}

	void TripRecovery() {
		visuals.transform.eulerAngles = Vector3.zero;
		tripped = false;
	}

	// Update is called once per frame
	void Update () {
		// DELETEME:
		// Skipping levels
		if (Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}

		if (!tripped) {

			// Walking
			if (Input.GetKey(KeyCode.LeftArrow)) {
				rigid.AddForce(new Vector2(-10f, 0f));
			}
			if (Input.GetKey(KeyCode.RightArrow)) {
				rigid.AddForce(new Vector2(10f, 0f));
			}

			// Tripping
			if (sacrificeTracker.sacrificedLeg) {
				if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
					Invoke ("RandomTrip", Random.Range(3f, 8f));
				}
				if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && Mathf.Abs (rigid.velocity.x) < .2f) {
					CancelInvoke("RandomTrip");
				}
			}

		}

		// Climbing
		if (!tripped && !falling && rockWalls > 0) {

			// Starting Climb
			if (!climbingWalls) {
				if (Input.GetKey(KeyCode.UpArrow)) {
					climbingWalls = true;
					rigid.gravityScale = 0;

					if (sacrificeTracker.sacrificedArm) {
						float timer = Random.Range(3f, 13f);
						Debug.Log ("Invoking randomFall in " + timer + " seconds");
						Invoke("RandomFall", timer);
					}
				}

			// Continuing Climb
			} else {
				rigid.velocity *= 3f/4f;
				
				if (Input.GetKey(KeyCode.UpArrow)) {
					rigid.AddForce(new Vector2(0f, 10f));
				}
				if (Input.GetKey(KeyCode.DownArrow)) {
					rigid.AddForce(new Vector2(0f, -10f));
				}
			}

		// Falling
		} else {

			// Start Falling
			if (climbingWalls) {
				climbingWalls = false;
				rigid.gravityScale = 1;

			// Stop Falling
			} else if (fallingTime > .5f && (this.transform.position.y - lastPositionY >= -.01f || rockWalls <= 0)) {
				falling = false;
				CancelInvoke("RandomFall");
				fallingTime = 0f;
			}

			// Measure time falling
			if (falling) {
				fallingTime += Time.deltaTime;
			}
			Debug.Log("Rock walls are " + rockWalls + " and pos y - last pos y is " + (this.transform.position.y - lastPositionY));

		}

		// Tracking to know when falling stops
		lastPositionY = this.transform.position.y;
	}

	//collision detection for collectible items
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Collect") {
			col.gameObject.active= false;
			collect = true;
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
//		Debug.Log ("Collided with " + c.gameObject.name);
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
