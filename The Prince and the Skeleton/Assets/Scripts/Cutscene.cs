using UnityEngine;
using System.Collections;

[System.Serializable]
public class SoundImages
{
	public AudioClip sound;
	public GameObject image;
}

public class Cutscene : MonoBehaviour {
	public int levelIndex = -1; 
	public SoundImages[] list;
	int position = 0;
	AudioClip currentAudio = null;
	AudioSource source;
	//special case exception (hacky)
	public bool epilogue = false;
	// Use this for initialization
	void Start () {
		if(!epilogue){
			foreach (Transform t in this.GetComponentsInChildren<Transform>()) {
				if (t != this.transform) {
					t.gameObject.SetActive(false);
				}
			}
		}
		source = this.GetComponent<AudioSource>();
		source.clip = list[0].sound;
		source.Play();
		list[0].image.SetActive(true);
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
			list[position-1].image.SetActive(false);
			list[position].image.SetActive(true);
			source.clip = list[position].sound;
			source.Play();
		} else {
             if(levelIndex == -1){
                 Application.LoadLevel(Application.loadedLevel + 1);
             }
             else {
                Application.LoadLevel(levelIndex);
            }
		}
	}
}