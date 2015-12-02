using UnityEngine;
using System.Collections;

public class AudioDoor : MonoBehaviour {
    public int levelIndex = -1; 
    AudioClip currentAudio = null;
    AudioSource source;


    void OnTriggerEnter2D (Collider2D c) {
        source = this.GetComponent<AudioSource>();
        source.Play();
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