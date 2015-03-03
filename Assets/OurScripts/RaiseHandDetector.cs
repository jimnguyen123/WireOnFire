using UnityEngine;
using System.Collections;


public class RaiseHandDetector : MonoBehaviour {

	static public bool setBool;
	static public bool drawBool;

	static public bool turnOnPhysics;
	static public bool undoBool;

	static public bool footUp;

	public GameObject setHand;
	public GameObject setElbow;

	public GameObject drawHand;
	public GameObject drawElbow;

	public GameObject foot;
	public GameObject knee;

	public GameObject undoFoot;
	public GameObject undoKnee;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (drawHand.transform.position.y > drawElbow.transform.position.y)
		    drawBool = true;

		else
		    drawBool = false;

		if (setHand.transform.position.y > setElbow.transform.position.y)
			setBool = true;

		else
			setBool = false;

		if (foot.transform.position.y > knee.transform.position.y) {
						turnOnPhysics = true;
						//Debug.Log ("Found lel");
				}
			//while(foot.transform.position.y > knee.transform.position.y)

		
		else
			turnOnPhysics = false;

		if (undoFoot.transform.position.y > undoKnee.transform.position.y) {
						//footUp = true;
						undoBool = true;
				} else
						undoBool = false;
		/*
		if ((undoFoot.transform.position.y < undoKnee.transform.position.y) && footUp) {
			footUp = false;
			//undoBool = true;
		}
`		*/

	}
}
