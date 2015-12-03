using UnityEngine;
using System.Collections;

public class Guardian : MonoBehaviour {
	public float speed;
	public float minimum;
	public float maximum;
	public bool xAxis;
	public bool yAxis;

	bool direction = false;
	
	void Update () {
		Vector3 pos =  GetComponent<Transform>().localPosition;
		if(yAxis){
			if(direction){
				pos.y += speed;
				GetComponent<Transform>().localPosition = pos;
				if(pos.y > maximum){
					direction = false;
				}
			}
			else {
				pos.y -= speed;
				GetComponent<Transform>().localPosition = pos;
				if(pos.y < minimum){
					direction = true;
				}
			}
		}

		if(xAxis){
			if(direction){
				pos.x += speed;
				GetComponent<Transform>().localPosition = pos;
				if(pos.x > maximum){
					direction = false;
				}
			}
			else {
				pos.x -= speed;
				GetComponent<Transform>().localPosition = pos;
				if(pos.x < minimum){
					direction = true;
				}
			}
		}
	}
}
