using UnityEngine;
using System.Collections;

public class Diapers : MonoBehaviour {

	public AudioClip laugh;
	public AudioClip coo;

	private GameObject diapers;
	private Transform parent;
	private AudioSource aSource;
	private bool started = false;

	void Awake(){
		diapers = GameObject.Find("Diapers");
		aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer.getCurrentTime() > 1728000 && started != true){
			aSource.clip = laugh;
			aSource.Play();
			started = true;
		}
		parent = transform.root;
		if(diapers.transform.IsChildOf(parent) && parent.name == "ChangingTable"){
			aSource.clip = coo;
			aSource.Play();
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
