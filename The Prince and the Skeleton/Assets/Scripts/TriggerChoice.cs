using UnityEngine;
using System.Collections;

[System.Serializable]
public class AudioImages
{
	public AudioClip sound;
}

public class TriggerChoice : MonoBehaviour {
	
	public int levelIndex = -1; 
	public AudioImages[] list;
	int position = 0;
	AudioClip currentAudio = null;
	AudioSource source;
	
	// Use this for initialization
	void Start () {
		foreach (Transform t in this.GetComponentsInChildren<Transform>()) {
			if (t != this.transform) {
				t.gameObject.SetActive(false);
			}
		}
		source = this.GetComponent<AudioSource>();
		source.clip = list[0].sound;
		source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying || (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))) {
			NextPage();
		}
	}
	
	void NextPage() {
		position++;
		if (position < list.Length) {
			// Update image and start new sound
			source.clip = list[position].sound;
			source.Play();
		} else {
			Application.LoadLevel(levelIndex);
		}
	}
}
