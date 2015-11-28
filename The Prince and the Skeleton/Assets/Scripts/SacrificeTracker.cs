using UnityEngine;
using System.Collections;

public class SacrificeTracker : MonoBehaviour {

	public bool sacrificedArm = false;
	public bool sacrificedLeg = false;

	// Use this for initialization
	void Start () {

	}

	void OnEnable () {
		if (GameObject.FindObjectsOfType<SacrificeTracker>().Length > 1) {
			Destroy(this.gameObject);
		} else {
			DontDestroyOnLoad(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
