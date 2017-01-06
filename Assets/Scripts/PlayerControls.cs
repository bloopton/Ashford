using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	public KeyCode jump, moveRight, moveLeft;
	Rigidbody2D playerRB;
	private Animator animator;
	MovementScript ms;


	// Use this for initialization
	void Start () {
		playerRB = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator> ();
		ms = gameObject.GetComponent<MovementScript>();

		jump = KeyCode.W;
		moveRight =  KeyCode.D;
		moveLeft = KeyCode.A;
	}

	void Update(){
	/*	if (playerRB.velocity.y > 0) {
			animator.SetBool ("Ground", false);
			animator.SetBool ("Jumping", true);
		} else if (playerRB.velocity.y < 0 ) {
			animator.SetBool ("Falling", true);
			animator.SetBool ("Jumping", false);
		} else{ 
			animator.SetBool ("Falling", false);
			animator.SetBool ("Jumping", false);
			animator.SetBool ("Ground", true);
		}
		*/
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (moveRight)) {
			//animator.SetInteger ("Direction", 0);
			if (playerRB.velocity.y == 0)
				animator.SetBool ("Running", true);
			ms.moveRight ();
		} else if (Input.GetKey (moveLeft)) {
			//animator.SetInteger ("Direction", 1);
			if (playerRB.velocity.y == 0)
				animator.SetBool ("Running", true);
			ms.moveLeft ();
		} else
			animator.SetBool ("Running", false);

		if (Input.GetKeyDown (jump)) {
			
			if (Mathf.Abs(playerRB.velocity.y) <= 0.01f) {
			ms.jump ();
			}
		}
	}


}
