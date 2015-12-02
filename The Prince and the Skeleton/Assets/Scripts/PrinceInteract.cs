using UnityEngine;
using System.Collections;

public class PrinceInteract : MonoBehaviour {
	bool _princeInteract = false; //within Prince talking viscinity - true
	bool _questReceived = false;
	bool _collect = false;
	public int state = 0; //user defined state 0-water, 1-rock, 2-flower

	//void getScores() { state = PlayerPrefs.GetInt("collectState"); } 
	void OnTriggerEnter2D(Collider2D col) {
		//Check for Player Entering Area of Prince Door
		if (col.gameObject.tag == "Player") {
			_princeInteract = true;
			_collect = col.gameObject.GetComponent<Controls>().collect; 
		}
	}

	void OnTriggerExit2D (Collider2D c) {
		_princeInteract = false;
	}

	void Update() {
		if (_princeInteract == true) {
			//getScores();
			//Debug.Log(state);
//			if(Input.GetKeyDown("return")){
				Transform princeVoice = this.gameObject.transform.GetChild (0);
				if(state ==0){
					if(_collect == false){
						princeVoice.GetComponent<TextMesh>().text = "Water...";
						_questReceived = true;
					}	
					else{
						princeVoice.GetComponent<TextMesh>().text = "Thank you... Who are you?";
						StartCoroutine("NextLevel");
					}
				}
				if(state ==1){
					if(_collect == false){
						princeVoice.GetComponent<TextMesh>().text = "I'm bored...";
						_questReceived = true;
					}	
					else{
						princeVoice.GetComponent<TextMesh>().text = "Thank you... Here is a drawing.";
						StartCoroutine("NextLevel");
					}
				}
				if(state ==2){
					if(_collect == false){
						princeVoice.GetComponent<TextMesh>().text = "I'm curious of whats outside...";
						_questReceived = true;
					}	
					else{
						StartCoroutine("NextLevel");;
					}
				}

				
//			}
		}
	}

	private IEnumerator NextLevel(){
		while(true){
			yield return new WaitForSeconds(2f); // wait two seconds
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
