using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour {
	
	private Transform holdPos;
	tranform.parent.gameObject.FindChild("Holding positoion");
	// Use this for initialization
	
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
			if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("g")) {
			holdPos = other.transform.parent.gameObject.FindChild("Holding position");
			transform.parent = holdPos;
			transform.rotation = holdPos.rotation;
			transform.position = holdPos.position;

			//GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().isKinematic = false;

			} else {
			
		}
			
		
	}
	
}