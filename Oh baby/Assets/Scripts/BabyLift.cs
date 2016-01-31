using UnityEngine;
using System.Collections;

public class BabyLift : MonoBehaviour {

	//private bool babyHeld = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.root.name == "Player"){
			//babyHeld = true;
			Score.ritualsDone += 1;
			this.enabled = false;
		}
	}
}
