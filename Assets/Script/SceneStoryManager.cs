using UnityEngine;
using System.Collections;

public class SceneStoryManager : MonoBehaviour {
	
	public Animator fadeSceneAnimator;
	
	void Awake () {
		Cursor.visible = false;
		Instantiate(Resources.Load(SceneStoryData.NEXT_STAGE, typeof(GameObject)));
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel("Main Menu");
	}
}
