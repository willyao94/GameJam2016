﻿using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {
	
	public Sprite hotSprite;

	private bool heat;

	void Update () {
		if(transform.root.name == "Stove"){
			//heat = true;
			GetComponent<SpriteRenderer>().sprite = hotSprite;
		}
	}
}
