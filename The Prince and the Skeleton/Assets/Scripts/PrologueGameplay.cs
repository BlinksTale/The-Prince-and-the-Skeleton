using UnityEngine;
using System.Collections;

public class PrologueGameplay : MonoBehaviour {

	public GameObject[] tasks; // touch these in order to progress
	int index = 0;
	TextMesh text;

	// Use this for initialization
	void Start () {
		foreach(GameObject g in tasks) {
			g.GetComponent<PrologueTask>().gameplay = this;
			g.SetActive(false);
		}
		tasks[0].SetActive(true);
		text = this.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Progress() {
		index++;
		if (index < tasks.Length) {
			tasks[index].SetActive(true);
			text.text = "Task " + (index + 1);
		} else {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
