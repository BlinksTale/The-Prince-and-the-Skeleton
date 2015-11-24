using UnityEngine;
using System.Collections;

public class EnemyArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			this.GetComponentInChildren<EnemyAI>().PlayerAlert(other.transform.position);
		}
	}
}
