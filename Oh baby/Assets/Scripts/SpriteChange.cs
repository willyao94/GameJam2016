using UnityEngine;
using System.Collections;

public class SpriteChange : MonoBehaviour {

	public int burnTime = 500;
	public Sprite cribSprite;
	public Sprite babySprite;
	public Sprite fireSprite;
	public Sprite bathSprite;
	public Sprite vomitSprite;
	public Sprite burntSprite;
	public Sprite happySprite;
	public Sprite chairSprite;

	private SpriteRenderer sRenderer;
	private string parentName;
	private bool burnt = false;
	private int timer;

	// Use this for initialization
	void Start () {
		sRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		parentName = transform.root.name;

		if (burnt != true){
			
			switch(parentName)
			{
			case "Stove": 
				sRenderer.sprite = fireSprite;
				timer = burnTime;
				burnt = true;
				break;
			case "Crib": 
				sRenderer.sprite = cribSprite;
				break;
			case "Player": 
				sRenderer.sprite = happySprite;
				break;
			case "Bathtub": 
				sRenderer.sprite = bathSprite;
				break;
			case "High Chair":
				sRenderer.sprite = chairSprite;
				break;
			default:
				sRenderer.sprite = babySprite;
				break;
			}
		} else{
			timer -= 1;
			if (parentName == "Bathtub"){
				burnt = false;
				timer = burnTime;
			}
			if (timer <= 0){
				sRenderer.sprite = burntSprite;
				this.enabled = false;
			}
		}
	}
}