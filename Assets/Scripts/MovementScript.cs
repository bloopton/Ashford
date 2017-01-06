using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public Vector2 initPos;
	public float jumpPower;
	public float runForce;
	public float runVel;
	public float crawlForce;
	public float crawlVel;
	Rigidbody2D playerRB;
	public int dir;

	// Use this for initialization
	void Start () {
		dir = -1;
		playerRB = gameObject.GetComponent<Rigidbody2D>();
		initPos = playerRB.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0.02f) {
			transform.rotation = Quaternion.Euler(0,0,0);//face right
			dir = -1;
			//Debug.Log ("Switch to Right");

		} else if (gameObject.GetComponent<Rigidbody2D>().velocity.x < -0.02f) {
			transform.rotation = Quaternion.Euler(0,180,0);//face left
			dir = 1;
			//Debug.Log ("Switch to Left");

		}
	}


	// Update is called once per frame
	void Update () {
	
	}

	public void moveRight(){
		if (Mathf.Abs (playerRB.velocity.x) < runVel)
			playerRB.AddForce (new Vector2 (runForce, 0), ForceMode2D.Force);
	}

	public void moveLeft(){
		if (Mathf.Abs (playerRB.velocity.x) < runVel)
			playerRB.AddForce (new Vector2 (-runForce, 0), ForceMode2D.Force);
	}
	public void jump(){
		playerRB.AddForce (new Vector2 (0, jumpPower), ForceMode2D.Impulse);
	}
}
