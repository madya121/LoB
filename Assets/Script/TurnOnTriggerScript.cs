using UnityEngine;
using System.Collections;

public class TurnOnTriggerScript : MonoBehaviour {

	public bool playerIsOnArea = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerIsOnArea = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerIsOnArea = false;
		}
	}
}
