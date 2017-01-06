using UnityEngine;
using System.Collections;

public class StandControls : MonoBehaviour {

	public bool bound;
	public GameObject player;
	public float offset;
	private MovementScript ms;
	// Use this for initialization
	void Start () {
		ms = player.GetComponent<MovementScript> ();
		offset = 1.5f;
		bound = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (bound) {
			gameObject.transform.position = new Vector2 (player.transform.position.x + offset * ms.dir, player.transform.position.y + offset);
			if (ms.dir == -1) {
				transform.rotation = Quaternion.Euler(0,0,0);//face right
				//Debug.Log ("Switch to Right");

			} else if (ms.dir == 1) {
				transform.rotation = Quaternion.Euler(0,180,0);//face left				//Debug.Log ("Switch to Left");

			}
		
		
		}
	}
}
