using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {

	public Transform followingPosition;

	private float sizeCamera;
	private Camera kamera;
	private float sizeCameraNow;
	
	
	private Vector3 velocity = Vector3.zero;

	void Awake () {
		kamera = GetComponent<Camera>();
		sizeCameraNow = sizeCamera = kamera.orthographicSize;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(kamera.orthographicSize - sizeCameraNow) < 0.1)
			kamera.orthographicSize = sizeCameraNow;
		else 
			kamera.orthographicSize = Mathf.Lerp(
				kamera.orthographicSize,
				sizeCameraNow,
				0.1f);
			
		Vector3 position = new Vector3(followingPosition.position.x, followingPosition.position.y, transform.position.z);
		transform.position = Vector3.SmoothDamp(transform.position, position, 
			ref velocity, 0.2f);;
	}
	
	public void ZoomOut() {
		sizeCameraNow = sizeCamera * 4;
	}
	
	public void ZoomIn() {
		sizeCameraNow = sizeCamera;
	}
}
