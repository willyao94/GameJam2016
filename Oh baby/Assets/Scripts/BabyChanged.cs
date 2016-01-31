using UnityEngine;
using System.Collections;

public class BabyChanged : MonoBehaviour {

    private GameObject diaper;
    private GameObject go;
    //private Instructions instructions;

    private bool babyChanged = false;
    private bool onTime = false;
    private bool finishedPrinting = false;

    private float timeBabyWasChanged;

    private string hintText1 = "OBSERVATION: Olfactory sensors detect odor.";
    private string hintText2 = "WARNING: Inefficient location for diaper change.";

    private string[] goodCompletionText = { "OBSERVATION: olfactory sensors indicate pleasant smell.",
        "CONCLUSION: baby’s regular bowel movement accounted for.",
        "PROJECTED RESULT: future career as underwear model." };

    private string[] badCompletionText = { "OBSERVATION: baby uncomfortable in diaper.",
        "CONCLUSION: diapers changed at irregular time.",
        "PROJECTED RESULTS: Diaper sores, future neuroses regarding feces." };

    private string instructionText;

    void Awake()
    {
        diaper = GameObject.Find("Diaper");
        if (go != null)
            go = GameObject.Find("InstructionText");
        //if (instructions != null)
        //    instructions = (Instructions)GameObject.getComponent(typeof(Instructions));
    }

    // Update is called once per frame
    void Update()
    {
        if (babyChanged)
        {
            timeBabyWasChanged += 1;

            if (!finishedPrinting)
            {
                if (onTime)
                {
                    if (timeBabyWasChanged <= 300)
                        instructionText = goodCompletionText[0];
                    else if (timeBabyWasChanged <= 600)
                        instructionText = goodCompletionText[1];
                    else if (600 < timeBabyWasChanged && timeBabyWasChanged <= 900)
                        instructionText = goodCompletionText[2];
                    else
                        finishedPrinting = true;
                }
                else {
                    if (timeBabyWasChanged <= 300)
                        instructionText = badCompletionText[0];
                    else if (timeBabyWasChanged <= 600)
                        instructionText = badCompletionText[1];
                    else if (600 < timeBabyWasChanged && timeBabyWasChanged <= 900)
                        instructionText = badCompletionText[2];
                    else
                        finishedPrinting = true;
                }
            }

        }
        else {
            if (diaper.transform.IsChildOf(transform.root))
            {
                babyChanged = true;
                Destroy(diaper);
                timeBabyWasChanged = 0;
                // If between 8-9pm
                if (1728000 < Timer.getCurrentTime() && Timer.getCurrentTime() < 1944000)
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
