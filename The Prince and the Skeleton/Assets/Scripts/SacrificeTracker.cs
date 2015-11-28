using UnityEngine;
using System.Collections;

public class SacrificeTracker : MonoBehaviour {

	public bool sacrificedArm = false;
	public bool sacrificedLeg = false;
	public static SacrificeTracker sacrificeTracker;

	// Use this for initialization
	void Start () {

	}

	void OnEnable () {
		if (sacrificeTracker != null) {
			Destroy(this.gameObject);
		} else {
			DontDestroyOnLoad(this.gameObject);
			sacrificeTracker = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
