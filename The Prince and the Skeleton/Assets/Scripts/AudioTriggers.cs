using UnityEngine;
using System.Collections;

public class AudioTriggers : MonoBehaviour {

    bool call = false;

	void OnTriggerEnter2D(Collider2D other) {
        if(!call){
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            call = true;
        }
    }
}
