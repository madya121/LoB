using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour {

	public bool canJump = true;
	public Transform trans;
	
	private float yBefore = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(yBefore - trans.position.y) > 0.0001f) canJump = false;
		else canJump = true;
		
		yBefore = trans.position.y;
	}
	
	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Box") {
			canJump = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Box") {
			canJump = false;
		}
	}*/
}
