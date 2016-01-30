using UnityEngine;
using System.Collections;

public class TakeMe : MonoBehaviour {
	
	private Transform taker;
	private Transform player;
	private Transform holdPos;
	private float grabDist = 10f;
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		holdPos = player.FindChild ("Holding position");

	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("g")) {

			var distance = Vector3.Distance(this.transform.position, player.position);
			Debug.Log("distance from " + distance);

			if (distance <= grabDist){
				transform.parent = holdPos;
				transform.rotation = holdPos.rotation;
				transform.position = holdPos.position;

				GetComponent<Rigidbody>().useGravity = false;
				GetComponent<Rigidbody>().isKinematic = true;
				GetComponent<Collider>().isTrigger = true;
			} else {
				Debug.Log("too far");
			}
			
		} else {}
	
	}

}