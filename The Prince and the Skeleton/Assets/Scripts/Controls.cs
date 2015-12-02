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
	public int state = 0;
	public BoulderCollider boulderColliderLeft, boulderColliderRight;

	Animator animator;

	public bool isFalling {
		get {
			return falling;
		}
	}

	// Use this for initialization
	void Start () {
		sacrificeTracker = SacrificeTracker.sacrificeTracker;
		if (sacrificeTracker.sacrificedArm) {
			armLeft.SetActive(false);
		}
		if (sacrificeTracker.sacrificedLeg) {
			legRight.SetActive(false);
			
		}

		animator = this.GetComponentInChildren<Animator>();
		rigid = this.GetComponent<Rigidbody2D>();
	}

	public void ForceFall() {
		falling = true;
		Debug.Log ("Forced fall!");
	}

	public void ForceTrip() {
		tripped = true;
		if (rigid.velocity.x < 0f) {
			visuals.transform.eulerAngles = new Vector3(0f,0f,-90f);
		} else {
			visuals.transform.eulerAngles = new Vector3(0f,0f, 90f);
		}
		Debug.Log ("Force trip!");
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
		Vector2 v = rigid.velocity;
		v.x = Mathf.Clamp(v.x,-2.5f,2.5f);
		rigid.velocity = v;
		//rigid.velocity = Vector2.ClampMagnitude(rigid.velocity, 2.5f);
		if (Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}

		if (!tripped) {

			// Walking
			if (Input.GetKey(KeyCode.LeftArrow)) {
				rigid.AddForce(new Vector2(-10f, 0f));
				animator.SetBool("walking", true);
				FlipAnimation(-1f);
			}
			if (Input.GetKey(KeyCode.RightArrow)) {
				rigid.AddForce(new Vector2(10f, 0f));
				animator.SetBool("walking", true);
				FlipAnimation(1f);
			}
			// both true or both false? Stop.
			if (!Input.GetKey(KeyCode.LeftArrow) == !Input.GetKey(KeyCode.RightArrow)) {
				animator.SetBool("walking", false);
			}

			// Tripping
			if (sacrificeTracker.sacrificedLeg) {
				if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
					Invoke ("ForceTrip", Random.Range(3f, 8f));
				}
				if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && Mathf.Abs (rigid.velocity.x) < .2f) {
					CancelInvoke("ForceTrip");
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
						Debug.Log ("Invoking ForceFall in " + timer + " seconds");
						Invoke("ForceFall", timer);
					}
				}

			// Continuing Climb
			} else {
				rigid.velocity *= 3f/4f;
				
				if (Input.GetKey(KeyCode.UpArrow)) {
					rigid.AddForce(new Vector2(0f, 10f));
					animator.SetBool("vertical", true);
				}
				if (Input.GetKey(KeyCode.DownArrow)) {
					rigid.AddForce(new Vector2(0f, -10f));
					animator.SetBool("vertical", true);
				}
				// Again, if both true or both false, not moving vertically
				if (Input.GetKey(KeyCode.DownArrow) == Input.GetKey(KeyCode.UpArrow)) {
					animator.SetBool("vertical", false);
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
				CancelInvoke("ForceFall");
				fallingTime = 0f;
			}

			// Measure time falling
			if (falling) {
				fallingTime += Time.deltaTime;
			}
//			Debug.Log("Rock walls are " + rockWalls + " and pos y - last pos y is " + (this.transform.position.y - lastPositionY));

		}

		// Tracking to know when falling stops
		lastPositionY = this.transform.position.y;

		// Animation updates:
		if (climbingWalls != animator.GetBool("climbing")) {
			animator.SetBool("climbing", climbingWalls);
		}

		bool hasBoulder = (boulderColliderLeft.hasBoulder && animator.transform.localScale.x < 0) || (boulderColliderRight.hasBoulder && animator.transform.localScale.x > 0);
		if (animator.GetBool("boulder") != hasBoulder) {
			animator.SetBool("boulder", hasBoulder);
		}
	}

	//collision detection for collectible items
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Collect") {
			col.gameObject.active= false;
			collect = true;
			//getScores();
			//saveScores();

		}
	}

	void OnTriggerEnter2D(Collider2D c) {
//		Debug.Log ("Collided with " + c.gameObject.name);
		if (c.gameObject.tag == "RockWall") {
			rockWalls++;
			Debug.Log ("Entered RockWall");
//			FlipAnimation(1f);
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		if (c.gameObject.tag == "RockWall") {
			rockWalls--;
			Debug.Log ("Exited RockWall");
		}
	}

	void FlipAnimation(float newDirection) {
		Vector3 scale = animator.transform.localScale;
		scale.x = Mathf.Abs(scale.x) * newDirection;
		if (animator.transform.localScale != scale) {
			animator.transform.localScale = scale;
		}
	}
	//void getScores() { state = PlayerPrefs.GetInt("collectState"); } 
	//void saveScores() { PlayerPrefs.SetInt("collectState",state+1); } 
}
