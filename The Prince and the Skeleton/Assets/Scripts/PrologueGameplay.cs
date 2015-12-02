using UnityEngine;
using System.Collections;

public class PrologueGameplay : MonoBehaviour {
	
	public int levelIndex=-1;
	public GameObject[] tasks; // touch these in order to progress
	int index = 0;
	TextMesh text;


	// Use this for initialization
	void Start () {
		foreach(GameObject g in tasks) {
			ShowTask (g, false);
		}
		ShowTask(tasks[0], true);
		text = this.GetComponent<TextMesh>();
	}

	void ShowTask(GameObject t, bool b) {
		if (!t.GetComponent<PrologueTask>().visibleBefore) {
			t.SetActive(b);
		} else {
			t.GetComponent<Collider2D>().enabled = b;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Progress() {
		index++;
		if (index < tasks.Length) {
			ShowTask(tasks[index], true);
			if (text != null) {
				text.text = "Task " + (index + 1);
			}
		} else {
			if (levelIndex == -1) {
				Application.LoadLevel(Application.loadedLevel + 1);
			} else {
				Application.LoadLevel(levelIndex);
			}
		}
	}
}
