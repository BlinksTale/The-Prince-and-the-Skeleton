using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour {

	Material m;
	bool fading = false;
	public float fadeWait = 3f;
	public float fadeTime = 5f;

	public bool reverse;
	public bool progress = true;

	// Use this for initialization
	void Start () {
		m = this.GetComponent<MeshRenderer>().material;
		Invoke ("StartFade", fadeWait);
		Invoke ("EndFade", fadeWait + fadeTime + 4f);
		
		Color c = m.color;
		if (reverse) {
			c.a = 1f;
		} else {
			c.a = 0f;
		}
		m.color = c;
	}

	void StartFade() {
		fading = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (fading) {
			Color c = m.color;
			if (reverse) {
				c.a = Mathf.Max (0f, c.a - Time.deltaTime/fadeTime);
			} else {
				c.a = Mathf.Min (1f, c.a + Time.deltaTime/fadeTime);
			}
			m.color = c;
		}
	}

	void EndFade() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

}
