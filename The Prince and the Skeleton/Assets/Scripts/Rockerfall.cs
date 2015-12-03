using UnityEngine;
using System.Collections;

public class Rockerfall : MonoBehaviour {
	Animator animator;
	float loopTime = 4f;
	float fallTime = 1f;

	public GameObject collisionArea, visuals;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.transform.GetChild(1).GetComponent<Animator>();
		StopFall ();
	}

	void StartFall() {
		//animator.SetBool("fall", true);
		visuals.SetActive(true);
		collisionArea.SetActive(true);
		Invoke ("StopFall", fallTime);
	}

	void StopFall() {
		animator.SetBool("fall", false);
		visuals.SetActive(false);
		collisionArea.SetActive(false);
		Invoke ("StartFall", loopTime - fallTime);
	}
}
