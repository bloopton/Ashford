using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public bool hasSpecHead;
	public float hueG;
	// Use this for initialization
	void Awake () {
		hasSpecHead = false;
		if (Random.Range (1, 10) <= 2) {
			hasSpecHead = true;
		}
		hueG = Random.value;
		hueG *= 100;
		hueG = Mathf.RoundToInt (hueG);
		hueG *= .01f;
		Debug.Log ("hueG in manager" + hueG);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
