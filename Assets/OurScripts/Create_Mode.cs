using UnityEngine;
using System.Collections;

public class Create_Mode : MonoBehaviour {

	public GUIText createText;

	// Use this for initialization
	void Start () {
		createText.text = "Create Mode: Off";
	}
	
	// Update is called once per frame
	void Update () {
		if (RaiseHandDetector.setBool) 
			createText.text = "Create Mode: On";

		else if (!RaiseHandDetector.setBool) 
			createText.text = "Create Mode: Off";
	}
}
