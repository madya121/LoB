using UnityEngine;
using System.Collections;

public class OneControllerScript : MonoBehaviour {

	public MainCameraScript mainCamera;
	public GameObject graphic;
	public Animator animatorGraphic;
	public ParticleSystem particleSys, deadParticleSystem;
	public Transform groundCheckLeft, groundCheckRight;
	public bool isFacingRight = true;
	public AudioClip jumpClip, deadClip;
	
	Rigidbody2D rgbd2D;
	float maks = 0;
	bool moving = false;
	bool isDead = false;
	AudioSource SFX;
	
	void Awake () {
		particleSys.enableEmission = false;
		deadParticleSystem.enableEmission = false;
		rgbd2D = GetComponent<Rigidbody2D>();
		SFX = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead)
			InputManager();
		maks = Mathf.Min(maks, rgbd2D.velocity.y);
	}
	
	bool IsGrounded () {
		bool left = Physics2D.Linecast(transform.position, groundCheckLeft.position, 
			1 << LayerMask.NameToLayer("Ground"));
		bool right = Physics2D.Linecast(transform.position, groundCheckRight.position, 
		    1 << LayerMask.NameToLayer("Ground"));
		return left | right;
	}
	
	void Flip() {
		isFacingRight ^= true;
		Vector3 scale = graphic.transform.localScale;
		scale.x *= -1;
		graphic.transform.localScale = scale;
	}
	
	void OnDisable() {
		animatorGraphic.SetBool("Walk", false);
		moving = false;
		particleSys.enableEmission = false;
	}
	
	void InputManager() {
		bool isInGround = IsGrounded();
		
		if (isInGround) animatorGraphic.SetBool("In Air", false);
		else animatorGraphic.SetBool("In Air", true);
	
		if (Input.GetKey(KeyCode.LeftArrow)) {
			if (isFacingRight) Flip ();
			moving = true;
			rgbd2D.velocity = new Vector2(-20, rgbd2D.velocity.y);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			if (!isFacingRight) Flip ();
			moving = true;
			rgbd2D.velocity = new Vector2(20, rgbd2D.velocity.y);
		} else if (moving) {
			rgbd2D.velocity = new Vector2(0, rgbd2D.velocity.y);
			moving = false;
		}
		
		if (Input.GetKeyDown(KeyCode.Space) && isInGround) {
			rgbd2D.velocity = new Vector2(0, 50);
			SFX.PlayOneShot(jumpClip);
		}
		
		if (Input.GetKeyDown(KeyCode.Return))
			Application.LoadLevel(Application.loadedLevel);
		
		if (Input.GetKey(KeyCode.LeftControl))
			mainCamera.ZoomOut();
		else mainCamera.ZoomIn();
	}
	
	void FixedUpdate() {
		if (isDead) return;
		
		bool grounded = IsGrounded();
		
		//if (grounded) rgbd2D.isKinematic = true;
		//else rgbd2D.isKinematic = false;
		
		if (rgbd2D.velocity.y <= -50) {
			rgbd2D.velocity = new Vector2(rgbd2D.velocity.x, -50);
		}
		
		if (moving && grounded) particleSys.enableEmission = true;
		else particleSys.enableEmission = false;
		
		if (grounded) {
			if (moving) animatorGraphic.SetBool("Walk", true);
			else animatorGraphic.SetBool("Walk", false);
		}
	}
	
	public void Dead() {
		if (isDead) return;
		SFX.PlayOneShot(deadClip);
		deadParticleSystem.enableEmission = true;
		Destroy(graphic);
		isDead = true;
		moving = false;
		rgbd2D.isKinematic = true;
		particleSys.enableEmission = false;
		Invoke("RestartLevel", 1f);
	}
	
	public void RestartLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
