using UnityEngine;
using System.Collections;

public class Baby2 : MonoBehaviour {

	public int timer = 1;

	private bool babyFed;
	private GameObject bottle;

	// Update is called once per frame
	void Update () {
		if(babyFed == true){
			timer = timer - 1; 
		} else{
			bottle = this.transform.Find("Bottle").gameObject;
			if(bottle != null){
				babyFed = true;
		}
			
		if(timer <=0){
			Destroy(bottle);
	} 
}
}
}