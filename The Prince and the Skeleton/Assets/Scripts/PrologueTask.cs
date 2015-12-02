using UnityEngine;
using System.Collections;

public class PrologueTask : MonoBehaviour {

	public PrologueGameplay gameplay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Player") {
			gameplay.Progress();
			this.gameObject.SetActive(false);
		}
	}
}
