using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	bool doneOnce = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {

		if (TestScript.finishedDrawing && !doneOnce && (other.gameObject.tag == "WireTag")) {
		
			ConfigurableJoint joint = this.gameObject.AddComponent<ConfigurableJoint>();
			joint.xMotion = ConfigurableJointMotion.Locked;
			joint.yMotion = ConfigurableJointMotion.Locked;
			joint.zMotion = ConfigurableJointMotion.Locked;
			joint.angularXMotion = ConfigurableJointMotion.Locked;
			joint.angularYMotion = ConfigurableJointMotion.Locked;
			joint.angularZMotion = ConfigurableJointMotion.Locked;
			joint.projectionMode = JointProjectionMode.PositionAndRotation;
			joint.configuredInWorldSpace = true;
			joint.connectedBody = other.rigidbody;
			doneOnce = true;
		
		}

		else if (TestScript.finishedDrawing && !doneOnce && (other.gameObject.tag == "Ground")) {

			ConfigurableJoint joint = this.gameObject.AddComponent<ConfigurableJoint>();
			joint.xMotion = ConfigurableJointMotion.Locked;
			joint.yMotion = ConfigurableJointMotion.Locked;
			joint.zMotion = ConfigurableJointMotion.Locked;
			joint.angularXMotion = ConfigurableJointMotion.Locked;
			joint.angularYMotion = ConfigurableJointMotion.Locked;
			joint.angularZMotion = ConfigurableJointMotion.Locked;
			joint.projectionMode = JointProjectionMode.PositionAndRotation;
			joint.configuredInWorldSpace = true;
			joint.connectedBody = other.rigidbody;
			doneOnce = true;

		}

	}
}
