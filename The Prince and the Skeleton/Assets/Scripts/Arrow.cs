using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
   bool direction = false;

	void Update () {
        Vector3 pos =  GetComponent<Transform>().localPosition;
        
        if(direction){
            pos.y += 0.04f;
            GetComponent<Transform>().localPosition = pos;
            if(pos.y > -4.0f){
                direction = false;
            }
        }
        else {
            pos.y -= 0.04f;
            GetComponent<Transform>().localPosition = pos;
            if(pos.y < -5.25f){
                direction = true;
            }
	    }
    }
}
