using UnityEngine;
using System.Collections;

public class RockerfallCollision : MonoBehaviour {

	Controls player;

	// Use this for initialization
	void Start () {
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		player = p.GetComponent<Controls>();
	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D c) {
		if (c.tag == "Player" && !player.isFalling) {
			player.ForceFall();
		}
	}
}
