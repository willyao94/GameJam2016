﻿using UnityEngine;
using System.Collections;

public class BabyFeed : MonoBehaviour {

	public int timer = 50;

	private bool babyFed;
	private GameObject bottle;

	void Awake(){
		bottle = GameObject.Find("Bottle");
	}

	// Update is called once per frame
	void Update () {
		if(babyFed == true){
			timer = timer - 1; 
		} else {
			if(bottle.transform.IsChildOf(transform.root)){
				babyFed = true;
				Score.ritualsDone += 1;
			}
		}
			
		if(timer <=0) {
			Destroy(bottle);
			this.enabled = false;
		}
	}
}