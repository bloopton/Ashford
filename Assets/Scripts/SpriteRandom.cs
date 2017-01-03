using UnityEngine;
using System.Collections;

public class ProcGen : MonoBehaviour {

	public string bodypart;//string name of body part; capital
	public int numberOfParts;//number of part types in body part folder
	public int numSpecHeadparts; //should refactor to see how many folders in dir.
	private int whichSprite;//the randomly chosen part within that folder
	private SpriteRenderer spriteR;
	private Sprite spriteS;
	private bool hasSpecHead;

	// Use this for initialization
	void Start () {
		GameObject wholeBody = transform.parent.gameObject;
		Manager ms = wholeBody.GetComponent<Manager> ();
		hasSpecHead = ms.hasSpecHead;
		whichSprite = (int)Random.Range (1, numberOfParts+1);//high value is not included
	/*	bool hasSpecHead = false;
		if (Random.Range (1, 10) <= 3) {
			hasSpecHead = true;
		}*/

		//if has special head, change default head to special head
		if (hasSpecHead) {
			if(bodypart == "Head"){
				whichSprite = (int)Random.Range (1, numSpecHeadparts+1);//just in case different number
				bodypart = "SpecialHead";
				string path = bodypart + "z" + "/" + bodypart + whichSprite + "-p/" + bodypart + whichSprite;
			//	Debug.Log (path + "| whichSprite is " + whichSprite);
				spriteR = gameObject.GetComponent<SpriteRenderer> ();
				spriteS = Resources.Load<Sprite>(path);
				spriteS.texture.filterMode = FilterMode.Point;//Prevent blurry sprites
				//Debug.Log ("Array size is " + sprites.Length);
				spriteR.sprite = spriteS;
			}
		}
		if (bodypart == "Iris") {
			int isNormalRange = 10;
			isNormalRange = (int)Random.Range (0, 11);
				if(isNormalRange < 9){
					whichSprite = (int)Random.Range (1, numberOfParts);
				} else {
					whichSprite = numberOfParts;
				}
		}
		//if head is normal, proceed with facial features/back
		if(!hasSpecHead && (bodypart == "EyeWhite" || bodypart == "Back" || bodypart == "Iris" || bodypart == "Mouth" || bodypart == "Head" || bodypart == "Decor" )){
			//if decor, chance to not show
			if (bodypart == "Decor") {
				if (Random.Range (1, 10) <= 5) {
					string path = bodypart + "z" + "/" + bodypart + whichSprite + "-p/" + bodypart + whichSprite;
					//Debug.Log (path + "| whichSprite is " + whichSprite);
					spriteR = gameObject.GetComponent<SpriteRenderer> ();
					spriteS = Resources.Load<Sprite> (path);
					spriteS.texture.filterMode = FilterMode.Point;//Prevent blurry sprites
					//Debug.Log ("Array size is " + sprites.Length);
					spriteR.sprite = spriteS;
				}
			} else if(bodypart == "Back"){
				if (Random.Range (1, 10) <= 2) {
					string path = bodypart + "z" + "/" + bodypart + whichSprite + "-p/" + bodypart + whichSprite;
					//Debug.Log (path + "| whichSprite is " + whichSprite);
					spriteR = gameObject.GetComponent<SpriteRenderer> ();
					spriteS = Resources.Load<Sprite> (path);
					spriteS.texture.filterMode = FilterMode.Point;//Prevent blurry sprites
					//Debug.Log ("Array size is " + sprites.Length);
					spriteR.sprite = spriteS;
				}
			}else {
				string path = bodypart + "z" + "/" + bodypart + whichSprite + "-p/" + bodypart + whichSprite;
				//Debug.Log (path + "| whichSprite is " + whichSprite);
				spriteR = gameObject.GetComponent<SpriteRenderer> ();
				spriteS = Resources.Load<Sprite> (path);
				spriteS.texture.filterMode = FilterMode.Point;//Prevent blurry sprites

				//Debug.Log ("Array size is " + sprites.Length);
				spriteR.sprite = spriteS;
			}
		}
		//if not head part, display irregardless
		if (bodypart == "Shoulder" || bodypart == "Chest" || bodypart == "Body") {
			string path = bodypart + "z" + "/" + bodypart + whichSprite + "-p/" + bodypart + whichSprite;
			//Debug.Log (path + "| whichSprite is " + whichSprite);
			spriteR = gameObject.GetComponent<SpriteRenderer> ();
			spriteS = Resources.Load<Sprite>(path);
			spriteS.texture.filterMode = FilterMode.Point;//Prevent blurry sprites

			//Debug.Log ("Array size is " + sprites.Length);
			spriteR.sprite = spriteS;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
