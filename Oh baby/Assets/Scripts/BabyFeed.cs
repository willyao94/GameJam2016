using UnityEngine;
using System.Collections;

public class BabyFeed : MonoBehaviour {

	public int timer = 50;
	public AudioClip cry;
	public AudioClip coo;

	private bool babyFed;
	private GameObject bottle;
	private AudioSource aSource;
	private bool started = false;

	void Awake(){
		aSource = GetComponent<AudioSource>();
		bottle = GameObject.Find("Bottle");
	}

	// Update is called once per frame
	void Update () {
		if (Timer.getCurrentTime() > 1512000 && started != true){
			aSource.clip = cry;
			aSource.Play();
			started = true;
		}
		if(babyFed == true){
			timer = timer - 1; 
		} else {
			if(bottle.transform.IsChildOf(transform.root)){
				if(Bottle.heat == true){
					aSource.clip = coo;
					babyFed = true;
					if(1512000 < Timer.getCurrentTime() && Timer.getCurrentTime() < 1728000){
						GameManagerScript.ritualsDone += 2;
					}
					else {
						GameManagerScript.ritualsDone += 1;
					}
				}
			}
		}
			
		if(timer <= 0) {
			Destroy(bottle);
			aSource.Play();
			this.enabled = false;
		}
	}
}