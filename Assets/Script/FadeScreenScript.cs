using UnityEngine;
using System.Collections;

public class FadeScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ChangeNextStage () {
		Application.LoadLevel(Application.loadedLevel);
	}
}
