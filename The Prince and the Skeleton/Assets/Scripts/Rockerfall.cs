using UnityEngine;
using System.Collections;

public class Rockerfall : MonoBehaviour {

	float loopTime = 4f;
	float fallTime = 1f;

	public GameObject collisionArea, visuals;

	// Use this for initialization
	void Start () {
		StopFall ();
	}

	void StartFall() {
		visuals.SetActive(true);
		collisionArea.SetActive(true);
		Invoke ("StopFall", fallTime);
	}

	void StopFall() {
		visuals.SetActive(false);
		collisionArea.SetActive(false);
		Invoke ("StartFall", loopTime - fallTime);
	}
}
