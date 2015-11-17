using UnityEngine;
using System.Collections;

public class PrinceInteract : MonoBehaviour {
	bool _princeInteract = false;
	bool _water = false;
	bool _rock = false;
	bool _flower = false;
	int state = 0;


	void OnTriggerEnter2D(Collider2D col) {
		//Check for Player Entering Area of Prince Door
		if (col.gameObject.tag == "Player") {
			_princeInteract = true;
			Debug.Log ("INSIDE PRINCE");
		}
	}

	void OnTriggerExit2D (Collider2D c) {
		_princeInteract = false;
	}


	void update() {
		if (_princeInteract == true) {
			if(Input.GetKeyDown("return")){
				if(state ==0){
					Transform princeVoice = this.gameObject.transform.GetChild (0);
					princeVoice.GetComponent<TextMesh>().text = "Water...";
				
				}
				
			}
		}
	}
}
