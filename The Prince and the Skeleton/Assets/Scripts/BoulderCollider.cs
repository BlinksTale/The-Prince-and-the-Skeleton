using UnityEngine;
using System.Collections;

public class BoulderCollider : MonoBehaviour {

	Transform parent;
	Animator animator;
	public bool hasBoulder;
	Collider2D collider;

	// Use this for initialization
	void Start () {
		parent = GameObject.FindGameObjectWithTag("Player").transform;
		animator = parent.GetComponentInChildren<Animator>();
		collider = this.GetComponent<Collider2D>();
	}

	void Update () {
		this.transform.position = parent.position;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log("Collision for " + gameObject.name);
		if (other.GetComponent<Rigidbody2D>() != null && other.tag != "Player") {
			hasBoulder = SameSide(other.transform);
			Debug.Log("Has boulder for " + gameObject.name + " is " + hasBoulder);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.GetComponent<Rigidbody2D>() != null && other.tag != "Player") {
			hasBoulder = false;
		}
	}

	bool SameSide(Transform other) {
		float dirBoulder = parent.position.x - other.position.x;
		float dirSelf = parent.position.x - (this.transform.position.x + collider.offset.x);
		Debug.Log ("DirBoulder: " + dirBoulder + ", dirSelf: " + dirSelf);

		return (dirBoulder >= 0) == (dirSelf >= 0);
	}
}
