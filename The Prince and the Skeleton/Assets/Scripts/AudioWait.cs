using UnityEngine;
using System.Collections;

public class AudioWait : MonoBehaviour {
    bool call = false;
    //public int levelIndex = -1; 
    AudioClip currentAudio = null;
    AudioSource source;
    public GameObject[] hide;
    public GameObject[] show;

    void OnTriggerEnter2D (Collider2D c) {
        if(!call){
            source = this.GetComponent<AudioSource>();
            source.Play();
            call = true;
        }
    }
    
    void hideObject(){
        foreach(GameObject h in hide) {
           h.SetActive(false);
        }
    }

    void showObject(){
        foreach(GameObject s in show) {
            s.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {
		if (source != null && !source.isPlaying) {
            hideObject();
            showObject();
        }
    }
}