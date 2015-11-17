using UnityEngine;
using System.Collections;

public class StartText : MonoBehaviour {

	public bool blinkOn = false;
	float blinkSpeed = 2f;
	// Use this for initialization
	void Start () {
		if (blinkOn) {
			InvokeBlink();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}

	void InvokeBlink() {
		Invoke ("BlinkOff", blinkSpeed*.85f);
		Invoke ("BlinkOn", blinkSpeed*1f);
	}
	void BlinkOn() {
		this.GetComponent<MeshRenderer>().enabled = true;
		InvokeBlink();
	}
	void BlinkOff() {
		this.GetComponent<MeshRenderer>().enabled = false;
	}
}
