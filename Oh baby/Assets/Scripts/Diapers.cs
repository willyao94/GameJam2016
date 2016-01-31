using UnityEngine;
using System.Collections;

public class Diapers : MonoBehaviour {

	private GameObject diapers;
	private Transform parent;

	void Awake(){
		diapers = GameObject.Find("Diapers");
	}
	
	// Update is called once per frame
	void Update () {
		parent = transform.root;
		if(diapers.transform.IsChildOf(parent) && parent.name == "ChangingTable"){
			if(1728000 < Timer.getCurrentTime() && Timer.getCurrentTime() < 1944000){
				GameManagerScript.ritualsDone += 2;
			}
			else {
				GameManagerScript.ritualsDone += 1;
			}
			Destroy(diapers);
			this.enabled = false;
		}
	}
}
