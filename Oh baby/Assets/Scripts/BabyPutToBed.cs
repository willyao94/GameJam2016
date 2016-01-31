using UnityEngine;
using System.Collections;

public class BabyPutToBed : MonoBehaviour {
    
    private GameObject crib;
    private GameObject go;
    //private Instructions instructions;

    private bool babyPutToBed = false;
    private bool onTime = false;
    private bool finishedPrinting = false;

    private float timeBabyWasPutToBed;

    private string hintText1 = "OBSERVATION: Olfactory sensors detect odor.";
    private string hintText2 = "WARNING: Inefficient location for diaper change.";

    private string[] goodCompletionText = { "OBSERVATION: baby displaying contentment, falling asleep.",
        "CONCLUSION: bedtime rituals followed exactly.",
        "PROJECTED RESULTS: proper sleeping habits, future successful game jammer." };

    private string[] badCompletionText = { "OBSERVATION: baby’s sleep is restless.",
        "CONCLUSION: Bedtime rituals not followed exactly.",
        "PROJECTED RESULT:  Improper sleep patterns leading to fatigue, DEATH." };

    private string instructionText;

    void Awake()
    {
        crib = GameObject.Find("Crib");
        if (go != null)
            go = GameObject.Find("InstructionText");
        //if (instructions != null)
        //    instructions = (Instructions)GameObject.getComponent(typeof(Instructions));
    }

    // Update is called once per frame
    void Update()
    {
        if (babyPutToBed)
        {
            timeBabyWasPutToBed += 1;

            if (!finishedPrinting)
            {
                if (onTime)
                {
                    if (timeBabyWasPutToBed <= 300)
                        instructionText = goodCompletionText[0];
                    else if (timeBabyWasPutToBed <= 600)
                        instructionText = goodCompletionText[1];
                    else if (600 < timeBabyWasPutToBed && timeBabyWasPutToBed <= 900)
                        instructionText = goodCompletionText[2];
                    else
                        finishedPrinting = true;
                }
                else {
                    if (timeBabyWasPutToBed <= 300)
                        instructionText = badCompletionText[0];
                    else if (timeBabyWasPutToBed <= 600)
                        instructionText = badCompletionText[1];
                    else if (600 < timeBabyWasPutToBed && timeBabyWasPutToBed <= 900)
                        instructionText = badCompletionText[2];
                    else
                        finishedPrinting = true;
                }
            }

        }
        else {
            if (crib.transform.IsChildOf(transform.root))
            {
                babyPutToBed = true;
                timeBabyWasPutToBed = 0;
                // If after 10pm
                if (2160000 < Timer.getCurrentTime())
                {
                    Score.ritualsDone += 2;
                    onTime = true;
                }
                else
                    Score.ritualsDone += 1;
            }
        }
        //this.enabled = false;

        //if baby is picked up, display hintText1
        //if player puts diaper object on baby object BEFORE putting it on change table object, display hintText2
    }
}
