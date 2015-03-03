using UnityEngine;
using System.Collections;

public class TextScript : MonoBehaviour {

	public GUIText cursorText;
	public GameObject cursor;

	// Use this for initialization
	void Start () {  
		cursorText.text = "Cursor Position: (" + cursor.transform.position.x.ToString()+
			", " + cursor.transform.position.y.ToString() + ", " +
				cursor.transform.position.z.ToString()+ ")";
	}
	
	// Update is called once per frame
	void Update () {
		cursorText.text = "Cursor Position: (" + cursor.transform.position.x.ToString()+
			", " + cursor.transform.position.y.ToString() + ", " +
				cursor.transform.position.z.ToString()+ ")";
	}
}
