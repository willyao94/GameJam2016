using UnityEngine;
using System.Collections;

public class MoveOb : MonoBehaviour {


	private Transform holdPos;
	private int waitTime = 0;

	void LateUpdate () {
		if(waitTime > 0){
			waitTime = Mathf.Max(waitTime - 1,0);
	}

	}
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if(waitTime <= 0){
			if(other.CompareTag("Interactable") && other.transform.root.name != transform.root.name){
				if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("g")) { 
					holdPos = other.transform.root.FindChild("Holding position");
					//Debug.Log(holdPos.transform.root.name);
					transform.parent = holdPos;
					transform.rotation = holdPos.rotation;
					transform.position = holdPos.position;
					waitTime = 5;



				//GetComponent<Rigidbody>().useGravity = false;
				//GetComponent<Rigidbody>().isKinematic = true;

			} 
			}

		}


	} 

}