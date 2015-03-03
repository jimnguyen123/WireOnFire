using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestScript : MonoBehaviour {

	List<GameObject> drawnObjects = new List<GameObject>();
	List<Vector3> listVect = new List<Vector3>();

	static public bool grav = false;

	Vector3 pos1;
	Vector3 pos2;
	bool turnOnGrav = false;
	bool localFootUp = false;
	bool firstPtTouchGround = false;

	public GameObject Wire;
	

	public GameObject drawingCube;

	float objectHeight = 2.0F;
	
	static public bool finishedDrawing = false;
	bool firstPoint = false;

	GameObject capsule;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (RaiseHandDetector.setBool) {
			if(!firstPoint)
			{
				capsule = (GameObject) Instantiate(Wire);
				pos1 = drawingCube.transform.position;
				firstPoint = true;
			}
			if(firstPoint)
			{
				Vector3 groundBelowP1 = pos1;
				groundBelowP1.y = 0;
				float distToGroundP1 = Mathf.Abs (Vector3.Distance (pos1, groundBelowP1));
				if((distToGroundP1 < 0.5F) && !firstPtTouchGround)
				{
					pos1 = groundBelowP1;
					firstPtTouchGround = true;
				}
				//Debug.Log (distToGround);

				else if(listVect.Count > 0)
				{
					float dist = Mathf.Abs(Vector3.Distance(pos1, listVect[0]));
					Vector3 tempVect = pos1;
					for(int i =0; i < listVect.Count; i++)
					{
						if(dist > Mathf.Abs(Vector3.Distance(pos1, listVect[i])))
						{
							//float lel = Mathf.Abs(Vector3.Distance(pos1, listVect[i]));
							//Debug.Log("Magnitude Pos1: " + lel);
							tempVect =listVect[i];
							dist = Mathf.Abs(Vector3.Distance(pos1, listVect[i]));
						}
					}
					if(dist < 2.0F)
					{
						pos1 = tempVect;
					}
				}


				pos2 = drawingCube.transform.position ;	


				Vector3 groundBelowP2 = pos2;
				groundBelowP2.y = 0;
				float distToGroundP2 = Mathf.Abs (Vector3.Distance (pos1, groundBelowP1));
				if((distToGroundP2 < 0.5F) && !firstPtTouchGround)
				{
					pos2 = groundBelowP2;
				}

				else if(listVect.Count > 0)
				{
					Vector3 tempVect = pos2;
					float dist = Mathf.Abs(Vector3.Distance(pos2, listVect[0]));
					for(int i =0; i < listVect.Count; i++)
					{
						if(dist > Mathf.Abs(Vector3.Distance(pos2, listVect[i])))
						{
							//float lel = Mathf.Abs(Vector3.Distance(pos1, listVect[i]));
							//Debug.Log("Magnitude Pos2: " + lel);
							tempVect = listVect[i];
							dist = Mathf.Abs(Vector3.Distance(pos2, listVect[i]));
						}
					}
					if((pos1!=pos2) && (dist < 2.0F))
					{
						pos2 = tempVect;
					}
				}

				
				Vector3 v3 = pos2 - pos1;
				capsule.transform.position = pos1 + (v3) /2.0F;
				Vector3 auxScale = transform.localScale;
				auxScale.y = v3.magnitude/objectHeight;
				capsule.transform.localScale = auxScale;
				capsule.transform.rotation = Quaternion.FromToRotation(Vector3.up, v3);


			}
			finishedDrawing = false;
			firstPtTouchGround = false;
		}
		
		else if (!RaiseHandDetector.setBool && !finishedDrawing) { //Permenantly places object in world in list 

			bool snapFound = false;

			if(capsule != null)
			{
				//capsule.AddComponent<Rigidbody>();
				//capsule.rigidbody.useGravity = false;
				//capsule.rigidbody.isKinematic = true;


				drawnObjects.Add (capsule);
				listVect.Add (pos1);
				listVect.Add (pos2);
				listVect.Add (capsule.transform.position);
				

				firstPoint = false;
				finishedDrawing = true;
				
				//Debug.Log (drawnObjects.Count);
			}
		}

		if(RaiseHandDetector.turnOnPhysics){ //Turns on gravity
			for(int i = 0; i < drawnObjects.Count; i++){
				drawnObjects[i].rigidbody.isKinematic = false;
				drawnObjects[i].rigidbody.useGravity = true;
				drawnObjects[i].rigidbody.collider.isTrigger = false;
			}
			grav = true;
		}

		if(RaiseHandDetector.undoBool && !localFootUp){ //When foot is up
			if(drawnObjects.Count > 0)
			{
				Object.Destroy(drawnObjects[drawnObjects.Count - 1]);
				drawnObjects.RemoveAt(drawnObjects.Count - 1);

				listVect.RemoveAt(listVect.Count -1);
				listVect.RemoveAt(listVect.Count -1);
				listVect.RemoveAt (listVect.Count-1);

				localFootUp = true;
			}
		}

		if (!RaiseHandDetector.undoBool && localFootUp) { //When foot is down
						localFootUp = false;
				}

	}

}
