using UnityEngine;
using System.Collections;

public class LevelCoOpScript : MonoBehaviour {

	public MainCameraScript mainCamera;
	public Transform one, zero;
	public OneControllerScript oneController, zeroController;
	public ShutdownTriggerScript shutdownTrigger;
	public TurnOnTriggerScript turnOnTrigger;
	public string jumpInto;
	public Animator cameraAnimator;
	public ParticleSystem backgroundParticle;
	
	public bool isOne = true;
	
	private Animator fadeSceneAnimator;

	// Use this for initialization
	void Start () {
		fadeSceneAnimator = GameObject.Find("Scene Story Manager").GetComponent<SceneStoryManager>().fadeSceneAnimator;
	}
	
	// Update is called once per frame
	void Update () {
		InputManager();
	}
	
	void InputManager() {
		if (Input.GetKeyDown(KeyCode.A)) {
			if (isOne) {
				if (shutdownTrigger.playerIsOnArea)
					ChangePlayerFocus();
			} else {
				if (turnOnTrigger.playerIsOnArea)
					ChangePlayerFocus();
				else if (shutdownTrigger.numberPlayer == 2) {
					// LEVEL FINISH
					print ("SELESAI");
					SceneStoryData.NEXT_STAGE = jumpInto;
					fadeSceneAnimator.SetTrigger("Fade In");
				}
			}
		}
	}
	
	public void ChangePlayerFocus() {
		if (isOne) {
			mainCamera.followingPosition = zero;
			zeroController.enabled = true;
			oneController.enabled = false;
			isOne = false;
			TurnOffAllObstacles();
		} else {
			mainCamera.followingPosition = one;
			zeroController.enabled = false;
			oneController.enabled = true;
			isOne = true;
			TurnOnAllObstacles();
		}
	}
	
	public void TurnOffAllObstacles() {
		cameraAnimator.SetTrigger("Off");
		backgroundParticle.enableEmission = false;
		
		// SHUTDOWN ALL BOXES
		GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
		foreach(GameObject box in boxes) {
			box.SendMessage("Shutdown");
		}
		
		GameObject[] lasers = GameObject.FindGameObjectsWithTag("Laser");
		foreach(GameObject laser in lasers) {
			laser.SendMessage("Shutdown");
		}
		
		GameObject[] deadTriggers = GameObject.FindGameObjectsWithTag("Dead Trigger");
		foreach(GameObject deadTrigger in deadTriggers) {
			if (deadTrigger.name.Equals("Dead Bottom") == false)
				deadTrigger.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
	
	public void TurnOnAllObstacles() {
		cameraAnimator.SetTrigger("On");
		backgroundParticle.enableEmission = true;
	
		// TURN ON ALL BOXES
		GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
		foreach(GameObject box in boxes) {
			box.SendMessage("TurnOn");
		}
		
		GameObject[] lasers = GameObject.FindGameObjectsWithTag("Laser");
		foreach(GameObject laser in lasers) {
			laser.SendMessage("TurnOn");
		}
		
		GameObject[] deadTriggers = GameObject.FindGameObjectsWithTag("Dead Trigger");
		foreach(GameObject deadTrigger in deadTriggers) {
			deadTrigger.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
}
