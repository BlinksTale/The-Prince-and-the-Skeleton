﻿using UnityEngine;
using System.Collections;

public class SelectSacrifice : MonoBehaviour {

	public GameObject OptionA, OptionB;
	int currentOption = 0;
	public bool allowChoice = true;
	bool stopMovement = false;
	GameObject sacrificeTracker;
	public int levelIndex = -1; 

	// Use this for initialization
	void Start () {
		Vector3 pos = this.transform.position;
		pos.x = pos.y = 0f;
		this.transform.position = pos;
		sacrificeTracker = GameObject.Find("SacrificeTracker");
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopMovement) {
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			Vector3 pos = OptionA.transform.position;
			pos.z = this.transform.position.z;
			this.transform.position = pos;
			currentOption = -1;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			Vector3 pos = OptionB.transform.position;
			pos.z = this.transform.position.z;
			this.transform.position = pos;
			currentOption = 1;
		}
		}
		if (Input.GetKeyDown(KeyCode.Return) && currentOption != 0) {
			if (allowChoice) {
				SacrificeTracker c = sacrificeTracker.GetComponent<SacrificeTracker>();
				if ((currentOption == -1) && (Application.loadedLevelName == "Chapter 1 Choice")) {
					c.sacrificedArm = true;
				}
				if ((currentOption == -1) && (Application.loadedLevelName == "Chapter 2 Choice")) {
					c.sacrificedLeg = true;
				}
				if (levelIndex == -1) {
					Application.LoadLevel(Application.loadedLevel+1);
				} else {
					Application.LoadLevel(levelIndex);
				}
			} else {
//				stopMovement = true;
			}
		}
	}
}
