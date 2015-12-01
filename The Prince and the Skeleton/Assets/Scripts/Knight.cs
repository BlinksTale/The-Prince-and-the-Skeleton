using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("d")) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.right;
			GetComponent<Transform>().localScale = new Vector2(1, 1);
			animator.SetBool("run", true);
		} else if (Input.GetKey ("a")) {
			GetComponent<Rigidbody2D> ().velocity = -1 * Vector2.right;
			GetComponent<Transform>().localScale = new Vector2(-1, 1);
			animator.SetBool("run", true);
		} else {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			animator.SetBool ("run", false);
		}


		if(Input.GetKeyDown("p")){
			animator.SetTrigger("attack");
		}
	
	}
}
