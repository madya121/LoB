using UnityEngine;
using System.Collections;

public class OneTriggerScript : MonoBehaviour {

	public OneControllerScript oneController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Box") {
			other.gameObject.SendMessage("PlayerOnBox");
		} else if (other.gameObject.tag == "Dead Trigger") {
			oneController.Dead();
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Box") {
			other.gameObject.SendMessage("PlayerLeaveBox");
		}
	}
}
