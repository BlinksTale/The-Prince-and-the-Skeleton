using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rigid.AddForce(new Vector2(-10f, 0f));
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			rigid.AddForce(new Vector2(10f, 0f));
		}
	}
}
