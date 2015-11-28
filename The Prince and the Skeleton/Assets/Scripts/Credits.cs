using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public string[] credits;
	TextMesh text;
	int index = 0;
	public float delay = 4f;
	public bool loop = false;
	public bool holdOnFinal = false;

	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
		TryNextCredits();
	}
	
	// Update is called once per frame
	void TryNextCredits () {
		if (index >= credits.Length) {
			if (!loop) {
				HideText();
			} else {
				index=1;
				NextCredits();
			}
		} else {
			NextCredits();
		}
	}

	void NextCredits() {
		text.text = credits[index];
		index++;
		if (!holdOnFinal || index != credits.Length) {
			Invoke("TryNextCredits", delay);
			Invoke ("HideText", delay*.75f); // so credits disappear on third beat to reappear on fourth
		}
	}

	void HideText () {
		text.text = "";
	}
}
