using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

	private Text textBox;

	// Use this for initialization
	void Awake () {
		textBox = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetText(string gameText){
		textBox.text = gameText;
	}
}
