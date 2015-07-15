using UnityEngine;
using System.Collections;

public class ShutdownTriggerScript : MonoBehaviour {

	public bool playerIsOnArea = false;
	public int numberPlayer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print (numberPlayer);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerIsOnArea = true;
			numberPlayer++;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerIsOnArea = false;
			numberPlayer--;
		}
	}
}
