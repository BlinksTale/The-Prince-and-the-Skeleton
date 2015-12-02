using UnityEngine;
using System.Collections;

public class AudioDoor : MonoBehaviour {
    public int levelIndex = -1; 
    AudioClip currentAudio = null;
    AudioSource source;
    bool call = false;


    void OnTriggerEnter2D (Collider2D c) {
        if(!call){
            source = this.GetComponent<AudioSource>();
            source.Play();
            call = true;
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (!source.isPlaying) {
            if(levelIndex == -1){
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            else {
                Application.LoadLevel(levelIndex);
            }
        }


    }
}