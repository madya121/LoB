using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManagerScript : MonoBehaviour {

	void Awake () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 120;
		Cursor.visible = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void NewGame () {
		if (SceneStoryData.NEXT_STAGE.Equals("Coming Soon"))
			SceneStoryData.NEXT_STAGE = "Chapter 1/Level 1";
		Application.LoadLevel("Story Scene");
	}
	
	public void ExitGame () {
		Application.Quit();
	}
}
