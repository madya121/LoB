using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	public ChatMessageScript[] cmdText;
	
	int index = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating("StartCMD", 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void StartCMD() {
		cmdText[index].SpeakNow();
		index++;
		if (index == cmdText.Length) {
			CancelInvoke();
			SceneStoryData.NEXT_STAGE = "Chapter 1/Level 1";
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
