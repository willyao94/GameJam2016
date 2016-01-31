using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public static int ritualsDone = 0;

    private Timer timer;

    void Awake() { 

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(ritualsDone); 
    }

    // Placeholder for handling the end score
    // Will need to break up text to fit
    void EndScore() {
        string endText;
        if (ritualsDone >= 9)
        { 
            endText = "“FINAL REPORT: You followed the baby’s bedtime rituals to the letter! " +
                "The child will grow into an excellent specimen of humanity. " + 
                "Parents turn out in droves to purchase Robot Nannies and pass off their caretaking to you and your kind." +
                "Good job!”";
        } else if (ritualsDone >= 6)
        { 
            endText = "“FINAL REPORT: You met the baby’s basic needs with only minor deviation from their set night-time rituals. " +
                "The baby will grow up with minor neuroses requiring therapy, but will otherwise be a productive member of society." +
                "Good job!”";
        } else if (ritualsDone >= 3)
        {
            endText = "“FINAL REPORT: While you met the baby’s basic needs, your inability to follow its routines and rituals exactly resulted in stunted growth and lasting emotional damage to the child. " +
                "Good job!”";
        } else
        {
            endText = "“FINAL REPORT: Not only did you fail to follow the bedtime rituals, you failed to pretty much do anything. " + 
                "As a result, the baby died and Robot Nannies were recalled to the factory to be destroyed. You perish in a fiery inferno." +
                "Good job!”";
        }
    }
}
