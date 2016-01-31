using UnityEngine;
using System.Collections;

public class BabyLift : MonoBehaviour {

	public AudioClip cry;
	public AudioClip coo;

	private AudioSource aSource;

	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource>();
		aSource.clip = cry;
		aSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.root.name == "Player"){
			aSource.clip = coo;
			aSource.Play();
			if(1296000 < Timer.getCurrentTime() && Timer.getCurrentTime() < 1512000){
				GameManagerScript.ritualsDone += 2;
			}
			else {
				GameManagerScript.ritualsDone += 1;
			}
			this.enabled = false;
		}
	}
}
