using UnityEngine;
using System.Collections;

public class Guardian : MonoBehaviour {

	bool direction = false;
	
	void Update () {
		Vector3 pos =  GetComponent<Transform>().localPosition;
		
		if(direction){
			pos.y += 0.01f;
			GetComponent<Transform>().localPosition = pos;
			if(pos.y > 1.5f){
				direction = false;
			}
		}
		else {
			pos.y -= 0.01f;
			GetComponent<Transform>().localPosition = pos;
			if(pos.y < -0.1f){
				direction = true;
			}
		}
	}
}
