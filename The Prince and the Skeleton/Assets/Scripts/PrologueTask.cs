using UnityEngine;
using System.Collections;

public class PrologueTask : MonoBehaviour {

	PrologueGameplay gameplay;
	public bool visibleBefore, visibleAfter;

	// Use this for initialization
	void Start () {
		PrologueGameplay[] list = GameObject.FindObjectsOfType<PrologueGameplay>();
		if (list.Length > 1) {
			Debug.LogError("Too many PrologueGameplay objects, found these:");
			foreach(PrologueGameplay item in list) {
				Debug.LogError("PrologueGameplay gameObject: " + item.gameObject.name);
			}
		} else {
			gameplay = list[0];
		}
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
		CollisionResponse(other.gameObject);
	}

	void OnTriggerEnter2D (Collider2D other) {
		CollisionResponse(other.gameObject);
	}

	void CollisionResponse(GameObject g) {
		if (g.tag == "Player") {
			if (gameplay != null) {
				gameplay.Progress();
			}
			if (!visibleAfter) {
				this.gameObject.SetActive(false);
			}
		}
	}

}
