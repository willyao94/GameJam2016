using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {
	
	public Sprite hotSprite;

	private SpriteRenderer sRenderer;
	private bool heat = false;

	void Awake(){
		sRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if(transform.root.name == "Stove" && heat == false){
			heat = true;
			sRenderer.sprite = hotSprite;
			this.enabled = false;
		}
	}
}
