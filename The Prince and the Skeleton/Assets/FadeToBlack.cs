using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour {

	Material m;
	bool fading = false;
	// Use this for initialization
	void Start () {
		m = this.GetComponent<MeshRenderer>().material;
		Invoke ("StartFade", 3f);
	}

	void StartFade() {
		fading = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (fading) {
		Color c = m.color;
		c.a = Mathf.Min (1f, c.a + Time.deltaTime/5f);
		m.color = c;
		}
	}

}
