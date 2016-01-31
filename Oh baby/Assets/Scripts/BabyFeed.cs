using UnityEngine;
using System.Collections;

public class BabyFeed : MonoBehaviour {

    private float timeBabyWasFed;
	private bool babyFed = false;
    private bool onTime = false;
	private GameObject bottle;

    private string hintText1 = "OBSERVATION: Baby’s mouth opening, closing. Displaying searching behaviour.";
    private string hintText2 = "OBSERVATION: Baby has spat out cold milk.";

    private string[] goodCompletionText = { "OBSERVATION: baby latching to bottle, feeding. Signs of contentment.",
        "CONCLUSION: baby fed according to schedule.",
        "PROJECTED RESULT: Disruption of bedtime schedule. Lifelong fear of water." };

    private string[] badCompletionText = { "OBSERVATION: baby latches to bottle, ingests milk improperly.",
        "CONCLUSION: baby fed at incorrect time.",
        "PROJECTED RESULTS: Nighttime indigestion. Future eating disorders." };

    private string instructionText;

	void Awake(){
		bottle = GameObject.Find("Bottle");
	}

	// Update is called once per frame
	void Update () {
		if (babyFed) {
            timeBabyWasFed += 1;

            if (onTime) {
                if (timeBabyWasFed <= 5)
                    instructionText = goodCompletionText[0];
                else if (timeBabyWasFed <= 10)
                    instructionText = goodCompletionText[1];
                else if (10 < timeBabyWasFed)
                    instructionText = goodCompletionText[2];
            } else {
                if (timeBabyWasFed <= 5)
                    instructionText = badCompletionText[0];
                else if (timeBabyWasFed <= 10)
                    instructionText = badCompletionText[1];
                else if (10 < timeBabyWasFed)
                    instructionText = badCompletionText[2];
            }
		} else {
			if (bottle.transform.IsChildOf(transform.root)) {
                //Debug.Log(bottle.GetComponent<Bottle>());
                babyFed = true;
                Destroy(bottle);
                timeBabyWasFed = 0;
                // If between 7-8pm
                if (1512000 < Timer.getCurrentTime() && Timer.getCurrentTime() < 1728000) {
                    Score.ritualsDone += 2;
                    onTime = true;
                }
                else
                    Score.ritualsDone += 1;
			}
		}
		/*	
		if(timer <= 0) {
			Destroy(bottle);
			this.enabled = false;
		}
        */
	}
}