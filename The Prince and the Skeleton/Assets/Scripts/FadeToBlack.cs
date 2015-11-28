using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour {

	Material m;
	bool fading = false;
	float fadeWait = 3f;
	float fadeTime = 5f;

	// Use this for initialization
	void Start () {
		m = this.GetComponent<MeshRenderer>().material;
		Invoke ("StartFade", fadeWait);
		Invoke ("EndFade", fadeWait + fadeTime + 4f);
	}

	void StartFade() {
		fading = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (fading) {
			Color c = m.color;
			c.a = Mathf.Min (1f, c.a + Time.deltaTime/fadeTime);
			m.color = c;
		}
	}

	void EndFade() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

}
