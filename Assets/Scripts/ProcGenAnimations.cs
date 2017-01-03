using UnityEngine;
using System.Collections;
using System.IO;

public class ProcGenAnimations : MonoBehaviour {
	public string bodypart;//string name of body part; capital
	public int numberOfParts;//number of part types in body part folder
	private int whichSprite;//the randomly chosen part within that folder

	// Use this for initialization
	void Start () {
		GameObject wholeBody = transform.parent.gameObject;
		Manager ms = wholeBody.GetComponent<Manager> ();

		numberOfParts = 0;
		int counter = 1;
		string testPath = "Assets/Resources/" + bodypart + "z" + "/" + bodypart + counter + "-p";//e.g. Headz/Head1
		//calculate how many sprites there are by checking validity of directory paths
		while(Directory.Exists (testPath)) {
			Debug.Log(testPath + "exists");
			counter++;
			testPath = "Assets/Resources/" + bodypart + "z" + "/" + bodypart + counter + "-p";
			numberOfParts++;//will exit on correct directory
		}
		whichSprite = (int)(Random.value * numberOfParts) + 1;

		//ensure left/right shoulders are same.  Should repeat if left/right arms are different
		if(bodypart.Contains("Shoulder")){
			if (ms.whichShoulder == 0) {
				ms.whichShoulder = whichSprite;
			} else {
				whichSprite = ms.whichShoulder;
			}
		}
		string path = bodypart + "z" + "/" + bodypart + whichSprite + "-p/Animations/" + bodypart + "_Ov";
		Debug.Log ("Number of parts is " + numberOfParts);
		Debug.Log (path);
		Animator animator = gameObject.GetComponent<Animator>();
		animator.runtimeAnimatorController = Resources.Load(path) as RuntimeAnimatorController;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
