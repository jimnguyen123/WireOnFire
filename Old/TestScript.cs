using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestScript : MonoBehaviour {

	List<GameObject> drawnObjects = new List<GameObject>();
	
	Vector3 pos1;
	Vector3 pos2;
	bool turnOnGrav = false;
	bool localFootUp = false;

	public GameObject Wire;
	

	public GameObject drawingCube;

	float objectHeight = 2.0F;

	bool initPointDetected = false;
	bool finishedDrawing = false;

	GameObject capsule;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (RaiseHandDetector.setBool && !initPointDetected) {
			//Instantiate(CylinderPrefab, new Vector3(0,0,0), Quaternion.identity);
			//pos1.Set(Input.mousePosition.x, Input.mousePosition.y, (Camera.main.nearClipPlane + 0.5F));
			capsule = (GameObject) Instantiate(Wire);

			pos1 = drawingCube.transform.position;
			//pos1 = Camera.main.ScreenToWorldPoint(pos1); 
			pos2 = drawingCube.transform.position ;
			
			
			Vector3 v3 = pos2 - pos1;
			capsule.transform.position = pos1 + (v3) /2.0F;
			Vector3 auxScale = transform.localScale;
			auxScale.y = v3.magnitude/objectHeight;
			capsule.transform.localScale = auxScale;
			capsule.transform.rotation = Quaternion.FromToRotation(Vector3.up, v3);
			initPointDetected= true;

			finishedDrawing = false;
		}
		
		else if (!RaiseHandDetector.setBool && initPointDetected) {
			//GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			bool snapFound = false;
			//pos2.Set(Input.mousePosition.x, Input.mousePosition.y, (Camera.main.nearClipPlane + 0.5F));
			//pos2 = Camera.main.ScreenToWorldPoint(pos2);



			//for(int i = 0; i < drawnObjects.Count; i++){
				//if(drawnObjects[i].collides with capsule){
					//Connect drawnObjects[i] with CapsuleCollider;
					//snapFound = true;
					//continue;
				//}
			//}

			///if (snapFound){
			//	drawnObjects.Add (capsule);
			//}
			//else{
			//	Object.Destroy(capsule);
			//}

			//snapFound = false;
			drawnObjects.Add (capsule);
			initPointDetected= false;
			finishedDrawing = true;		
		}

		if(RaiseHandDetector.globalDraw && !turnOnGrav){
			Debug.Log ("I lel");
			for(int i = 0; i < drawnObjects.Count; i++){
				drawnObjects[i].rigidbody.isKinematic = false;
				drawnObjects[i].rigidbody.useGravity = true;
			}
			turnOnGrav = true;
		}

		if(RaiseHandDetector.undoBool && !localFootUp){
			if(drawnObjects.Count > 0)
			{
				Object.Destroy(drawnObjects[drawnObjects.Count - 1]);
				drawnObjects.RemoveAt(drawnObjects.Count - 1);
				localFootUp = true;
			}
		}

		if (!RaiseHandDetector.undoBool && localFootUp) {
						Debug.Log ("undo out");
						localFootUp = false;
				}

	}

}
