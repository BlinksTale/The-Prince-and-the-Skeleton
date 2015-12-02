using UnityEngine;
using System.Collections;

public class epiloguePaths : MonoBehaviour {
    SacrificeTracker sacrificeTracker;
	// Use this for initialization
	void Start () {
	   sacrificeTracker = SacrificeTracker.sacrificeTracker;
        if (sacrificeTracker.sacrificedArm && sacrificeTracker.sacrificedLeg) {
            this.GetComponent<Cutscene>().list[3].image = GameObject.Find("39.pic_hd_3");
            this.GetComponent<Cutscene>().list[2].image = GameObject.Find("38.pic_hd_3");
        }
         else if (sacrificeTracker.sacrificedLeg) {
            this.GetComponent<Cutscene>().list[3].image = GameObject.Find("39.pic_hd_2");
            this.GetComponent<Cutscene>().list[2].image = GameObject.Find("38.pic_hd_2");
         }
         else if (sacrificeTracker.sacrificedArm) {
            this.GetComponent<Cutscene>().list[3].image = GameObject.Find("39.pic_hd_1");
            this.GetComponent<Cutscene>().list[2].image = GameObject.Find("38.pic_hd_1");
         }
         else{
            this.GetComponent<Cutscene>().list[3].image = GameObject.Find("39.pic_hd");
            this.GetComponent<Cutscene>().list[2].image = GameObject.Find("38.pic_hd");
         }

        foreach (Transform t in this.GetComponentsInChildren<Transform>()) {
            if (t != this.transform) {
                t.gameObject.SetActive(false);
            }
        }
        this.GetComponent<Cutscene>().list[0].image.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
