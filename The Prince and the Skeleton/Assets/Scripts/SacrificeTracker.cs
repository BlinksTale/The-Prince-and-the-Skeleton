using UnityEngine;
using System.Collections;

public class SacrificeTracker : MonoBehaviour {

	public bool sacrificedArm = false;
	public bool sacrificedLeg = false;
	public static SacrificeTracker sacrificeTracker;
	public bool isSacrificeTracker = false;

	// Use this for initialization
	void Start () {

	}

	void OnEnable () {
		if (sacrificeTracker != null && !isSacrificeTracker) {
			Destroy(this.gameObject);
		} else {
			DontDestroyOnLoad(this.gameObject);
			sacrificeTracker = this;
			isSacrificeTracker = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
