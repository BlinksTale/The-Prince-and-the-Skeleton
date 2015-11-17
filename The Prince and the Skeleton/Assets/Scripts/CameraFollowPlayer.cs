using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public bool followX, followY;
	public float rangeX, rangeY;
	public float lowerX, upperX, lowerY, upperY;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (followX) {
			float delta = player.transform.position.x - this.transform.position.x;
			if (Mathf.Abs(delta) > rangeX) {
				float movement = (Mathf.Abs(delta) - rangeX) * delta / Mathf.Abs(delta);
				Vector3 newPos = this.transform.position;
				newPos.x += movement;
				if (newPos.x > upperX) {
					newPos.x = upperX;
				}
				if (newPos.x < lowerX) {
					newPos.x = lowerX;
				}
				this.transform.position = newPos;
			}
		}

		if (followY) {
			float delta = player.transform.position.y - this.transform.position.y;
			if (Mathf.Abs(delta) > rangeY) {
				float movement = (Mathf.Abs(delta) - rangeY) * delta / Mathf.Abs(delta);
				Vector3 newPos = this.transform.position;
				newPos.y += movement;
				if (newPos.y > upperY) {
					newPos.y = upperY;
				}
				if (newPos.y < lowerY) {
					newPos.y = lowerY;
				}
				this.transform.position = newPos;
			}
		}
	}
}
