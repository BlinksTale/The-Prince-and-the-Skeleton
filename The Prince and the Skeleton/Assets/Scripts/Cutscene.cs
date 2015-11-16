using UnityEngine;
using System.Collections;

[System.Serializable]
public class SoundImages
{
	public AudioClip sound;
	public GameObject image;
}

public class Cutscene : MonoBehaviour {

	public SoundImages[] list;
	int position = 0;
	AudioClip currentAudio = null;
	AudioSource source;

	// Use this for initialization
	void Start () {
		source = this.GetComponent<AudioSource>();
		source.clip = list[0].sound;
		source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying) {
			position++;
			if (position < list.Length) {
				// Update image and start new sound
				list[position-1].image.SetActive(false);
				list[position].image.SetActive(true);
				source.clip = list[position].sound;
				source.Play();
			} else {
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}
	}
}
