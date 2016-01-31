using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {
	
	public Sprite hotSprite;
	public SpriteRenderer renderer;

	public static bool heat;

	void Update () {
		if(transform.root.name == "Stove"){
			heat = true;
			renderer.sprite = hotSprite;
		}
	}
}
