using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public static int ritualsDone = 0;
	public GameObject textBox; 

    void Start() { 
		DontDestroyOnLoad (gameObject);
		textBox = transform.Find("HUDCanvas/BottomRight").gameObject;
		textBox.SetActive (false);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(ritualsDone); 
		if (Timer.getCurrentTime() >= 2376000){
			UnityEngine.SceneManagement.SceneManager.LoadScene ("End");
			EndScore ();
			transform.Find ("HUDCanvas/TopCenter").gameObject.SetActive (false);
			this.enabled = false;
		}
    }

    // Placeholder for handling the end score
    void EndScore() {
        string endText;
        if (ritualsDone >= 9)
        { 
            endText = "FINAL REPORT: You followed the baby’s bedtime rituals to the letter! " +
                "The child will grow into an excellent specimen of humanity. " + 
                "Parents turn out in droves to purchase Robot Nannies and pass off their caretaking to you and your kind." +
                "Good job!";
        } else if (ritualsDone >= 6)
        { 
            endText = "FINAL REPORT: You met the baby’s basic needs with only minor deviation from their set night-time rituals. " +
                "The baby will grow up with minor neuroses requiring therapy, but will otherwise be a productive member of society." +
                "Good job!";
        } else if (ritualsDone >= 3)
        {
            endText = "FINAL REPORT: While you met the baby’s basic needs, your inability to follow its routines and rituals exactly resulted in stunted growth and lasting emotional damage to the child. " +
                "Good job!";
		} else if (ritualsDone <= -50){
			endText = "FINAL REPORT: You have murdered the baby" + 
				"Politicians use this as an excuse to push legislature to ban robots and distract the public from the latest scandal";
		} else
        {
            endText = "FINAL REPORT: Not only did you fail to follow the bedtime rituals, you failed to pretty much do anything. " + 
                "As a result, the baby died and Robot Nannies were recalled to the factory to be destroyed. You perish in a fiery inferno." +
                "Good job!";
        }
		textBox.SetActive (true);
		textBox.GetComponentInChildren<TextBox>().SetText(endText);
    }
}
