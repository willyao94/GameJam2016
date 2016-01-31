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
			if(1296000 < Timer.getCurrentTime() && Timer.getCurrentTime() < 1512000){
				Score.ritualsDone += 2;
			}
			else {
				Score.ritualsDone += 1;
			}
			this.enabled = false;
		}
	}
}
