using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	public enum BoxBehavior {MOVE_THEN_STOP, KEEP_MOVING, STOP_THEN_MOVING, JUST_STOP}

	public BoxBehavior boxBehavior;
	public Transform point1, point2;
	public SpriteRenderer point1Sprite, point2Sprite;
	public bool isVertical = false;
	public int speed;
	public Sprite move, stop, shutdown;
	
	private Rigidbody2D rgbd2D;
	private float second = 2;
	private bool isMoving = true;
	
	private float minX, maxX, minY, maxY;
	
	private bool isShutdown = false, playerIsOnTheBox = false;
	
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		ErrorCheck();
		spriteRenderer = GetComponent<SpriteRenderer>();
		rgbd2D = GetComponent<Rigidbody2D>();
		
		if (boxBehavior == BoxBehavior.KEEP_MOVING || boxBehavior == BoxBehavior.MOVE_THEN_STOP) {
			spriteRenderer.sprite = move;
			if (isVertical)
				rgbd2D.velocity = new Vector2(0, speed);
			else rgbd2D.velocity = new Vector2(speed, 0);
		} else spriteRenderer.sprite = stop;
		
		minX = Mathf.Min(point1.position.x, point2.position.x);
		maxX = Mathf.Max(point1.position.x, point2.position.x);
		minY = Mathf.Min(point1.position.y, point2.position.y);
		maxY = Mathf.Max(point1.position.y, point2.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ErrorCheck() {
		if (Vector3.Distance(point1.position, point2.position) == 0f)
			Debug.LogError("Two point cannot be same");
		if (isVertical && point1.position.x != point2.position.x)
			Debug.LogError("X coordinate must be same if isVertical is selected");
		if (!isVertical && point1.position.y != point2.position.y)
			Debug.LogError("Y coordinate must be same if isVertical is not selected");
			
		if (Application.isPlaying) {
			Destroy(point1Sprite);
			Destroy(point2Sprite);
		}
	}
	
	void UpdatePosition() {
		if (!isMoving) return;
		
		float x = transform.position.x;
		float y = transform.position.y;
		Vector3 position = transform.position;
		
		if (!isVertical) {
			if (x < minX) {
				position.x = minX;
				transform.position = position;
				FlipMovement();
			} else if (x > maxX) {
				position.x = maxX;
				transform.position = position;
				FlipMovement();
			}
		} else {
			if (y < minY) {
				position.y = minY;
				transform.position = position;
				FlipMovement();
			} else if (y > maxY) {
				position.y = maxY;
				transform.position = position;
				FlipMovement();
			}
		}
	}
	
	void LateUpdate() {
		UpdatePosition();
	}
	
	void FlipMovement() {
		speed *= -1;
		
		if (isVertical) rgbd2D.velocity = new Vector2(0, speed);
		else rgbd2D.velocity = new Vector2(speed, 0);
	}
	
	public void StopBox() {
		CancelInvoke();
		rgbd2D.velocity = Vector2.zero;
		isMoving = false;
		spriteRenderer.sprite = stop;
	}
	
	public void StartBox() {
		isMoving = true;
		//Invoke("MovingBox", 1.5f);
		MovingBox();
	}
	
	public void MoveBoxImmediately() {
		isMoving = true;
		if (isVertical) rgbd2D.velocity = new Vector2(0, speed);
		else rgbd2D.velocity = new Vector2(speed, 0);
	}
	
	public void StopBoxImmediately() {
		isMoving = false;
		rgbd2D.velocity = Vector2.zero;
	}
	
	public void PlayerOnBox() {
		playerIsOnTheBox = true;
		if (isShutdown) return;
		if (boxBehavior == BoxBehavior.MOVE_THEN_STOP)
			StopBox();
		if (boxBehavior == BoxBehavior.STOP_THEN_MOVING)
			StartBox();
	}
	
	public void PlayerLeaveBox() {
		playerIsOnTheBox = false;
		if (isShutdown) return;
		if (boxBehavior == BoxBehavior.MOVE_THEN_STOP)
			StartBox();
		if (boxBehavior == BoxBehavior.STOP_THEN_MOVING)
			StopBox();
	}
	
	void MovingBox() {
		if (isMoving == false) return;
		if (isVertical) rgbd2D.velocity = new Vector2(0, speed);
		else rgbd2D.velocity = new Vector2(speed, 0);
		spriteRenderer.sprite = move;
	}
	
	public void Shutdown() {
		isShutdown = true;
		StopBoxImmediately();
		spriteRenderer.sprite = shutdown;
	}
	
	public void TurnOn() {
		isShutdown = false;
		if (boxBehavior == BoxBehavior.KEEP_MOVING || boxBehavior == BoxBehavior.MOVE_THEN_STOP) {
			MoveBoxImmediately();
			spriteRenderer.sprite = move;
		} else spriteRenderer.sprite = stop;
	}
}
