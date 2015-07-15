using UnityEngine;
using System.Collections;

public class LevelFinishTriggerScript : MonoBehaviour {

	public Animator fadeSceneAnimator;
	public string jumpInto;

	// Use this for initialization
	void Start () {
		fadeSceneAnimator = GameObject.Find("Scene Story Manager").GetComponent<SceneStoryManager>().fadeSceneAnimator;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			SceneStoryData.NEXT_STAGE = jumpInto;
			fadeSceneAnimator.SetTrigger("Fade In");
		}
	}
}
