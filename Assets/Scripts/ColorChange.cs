using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	Renderer[] renderers;
	ProcGen[] names;
	float hue;
	float hue2;
	float hue3;
	//public Color color;
	// Use this for initialization
	void Start () {
	//	hue = Random.value;
	//	hue *= 100;
	//	hue = Mathf.RoundToInt (hue);
	//	hue *= .01f;
		GameObject wholeBody = transform.gameObject;
		Manager ms = wholeBody.GetComponent<Manager> ();
		//string part;
		Debug.Log("HueG in color" + ms.hueG);
		hue = ms.hueG;
		if (hue >= .5f) {
			hue2 = hue - Random.Range (.1f, .15f);
			hue3 = hue - Random.Range (.15f, .2f);
			//hue2 = hue - .1f;//chest, decor shoulder
			//hue3 = hue - .15f;//head, iris
		} else {
			hue2 = hue + Random.Range (.1f, .2f);
			hue3 = hue + Random.Range (.15f, .3f);
		}
		//Random.ColorHSV ();
		//float g = Random.Range (0, 1);
	//	float b = Random.Range (0, 1);
		renderers = gameObject.GetComponentsInChildren<Renderer>();
		names = gameObject.GetComponentsInChildren<ProcGen> ();
		//color = new Color(0.9f, 0.5f, 0.7f, 1f);	
		//foreach (Renderer rend in renderers) {
		//renders should be of same length as part names; i.e. # of part types
		for(int i = 0; i < renderers.Length; i++){
			Renderer rend = renderers [i];
			//Debug.Log("Name Length is " + names.Length);
			//Debug.Log("Renderer Length is " + renderers.Length);
			//Debug.Log("i is " + i);


			ProcGen partScript = names[i];
			string partName = partScript.bodypart;
			if (partName == "Chest" || partName == "Decor" || partName == "Shoulder") {
				rend.material.color = Color.HSVToRGB (hue2, 1, 1); 
			} else if (partName == "Head" || partName == "Iris") {
				rend.material.color = Color.HSVToRGB (hue3, 1, 1);
			} else if (partName == "EyeWhite" || partName == "Mouth") {
				//dont change eye white color
			}
			else {
				rend.material.color = Color.HSVToRGB (hue, 1, 1);
			}
			//rend.material.SetColor ("_TintColor", Color.green);
		}
		Debug.Log ("Hue: " + hue);
		//GetComponent<Renderer> ().material.color = Color.HSVToRGB( Random.Range (0, 1), 1,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
