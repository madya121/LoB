using UnityEngine;
using System.Collections;

public class MainMenuManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void NewGame () {
		Application.LoadLevel("Story Scene");
	}
	
	public void ExitGame () {
		Application.Quit();
	}
}
