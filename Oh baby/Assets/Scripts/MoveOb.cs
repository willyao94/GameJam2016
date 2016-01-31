using UnityEngine;
using System.Collections;

public class MoveOb : MonoBehaviour {


	private Transform holdPos;
	private int waitTime = 0;
	private Transform hands;


	void awake(){
		hands = this.transform.Find("Hold position");
		//hands = FindHoldPos(transform);
	}

	void LateUpdate () {
		if(waitTime > 0){
			waitTime = Mathf.Max(waitTime - 1,0);
	}

	}
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if(waitTime <= 0){
			if(other.CompareTag("Interactable") && CompareName(other)){
				if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) { 
					holdPos = other.transform.Find("Holding position");
					if (FreeHands()){
					//Debug.Log(holdPos.transform.root.name);
					transform.parent = holdPos;
					transform.rotation = holdPos.rotation;
					transform.position = holdPos.position;
					waitTime = 5;
					}


				//GetComponent<Rigidbody>().useGravity = false;
				//GetComponent<Rigidbody>().isKinematic = true;

			} 
			}

		}


	} 

	bool CompareName(Collider other){
		return (other.transform.root.name != this.transform.root.name);
	}

	bool FreeHands(){
		if(hands != null){
			if (hands.childCount > 0){
				return false;
					}
		}
		return (holdPos.childCount == 0);
	}

//	Transform FindHoldPos(Transform parent){
//		foreach(Transform child in parent){ 
//			if(child.name == "Holding position"){
//				return (child);
//			}
//			else{
//				return (this.transform);
//			}
//		}
//	}
}
