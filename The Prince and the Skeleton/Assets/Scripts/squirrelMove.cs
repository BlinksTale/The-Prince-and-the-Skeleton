using UnityEngine;
using System.Collections;

public class squirrelMove : MonoBehaviour {
    bool squirrelTriggered = false;
	void OnTriggerEnter2D (Collider2D c) {
        squirrelTriggered = true;
    }

    void Update(){
        Vector3 pos =  GetComponent<Transform>().localPosition;
        if(squirrelTriggered){
            pos.x -= 0.07f;
            GetComponent<Transform>().localPosition = pos;
        }
    }
}