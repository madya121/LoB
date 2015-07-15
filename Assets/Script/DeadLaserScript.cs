using UnityEngine;
using System.Collections;

public class DeadLaserScript : MonoBehaviour {

	public Transform point1, point2;
	
	LineRenderer lineRenderer;
	Material laserMaterial;

	void Awake () {
		lineRenderer = GetComponent<LineRenderer>();
		laserMaterial = lineRenderer.material;
	}

	// Use this for initialization
	void Start () {
		lineRenderer.SetPosition(0, point1.position);
		lineRenderer.SetPosition(1, point2.position);
	}
	
	public void Shutdown() {
		lineRenderer.enabled = false;
	}
	
	public void TurnOn() {
		lineRenderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
