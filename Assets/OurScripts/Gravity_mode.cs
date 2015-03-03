using UnityEngine;
using System.Collections;

public class Gravity_mode : MonoBehaviour {

	public GUIText gravityText;

	// Use this for initialization
	void Start () {
		gravityText.text = "Gravity: Off";
	}
	
	// Update is called once per frame
	void Update () {
		if(TestScript.grav)
			gravityText.text = "Gravity: On";
		else if(TestScript.grav)
			gravityText.text = "Gravity: Off";
	}
}
