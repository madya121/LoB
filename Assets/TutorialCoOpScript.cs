using UnityEngine;
using System.Collections;

public class TutorialCoOpScript : MonoBehaviour {
	
	public LevelCoOpScript levelCoOpScript;
	
	public GameObject tutorialCantPass;
	public GameObject tutorialMoveOn;
	public GameObject tutorialShutDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		if (levelCoOpScript.isOne == true) {
			tutorialCantPass.SetActive(false);
			tutorialMoveOn.SetActive(false);
			tutorialShutDown.SetActive(true);
		} else {
			tutorialCantPass.SetActive(true);
			tutorialMoveOn.SetActive(true);
			tutorialShutDown.SetActive(false);
		}
	}
}
