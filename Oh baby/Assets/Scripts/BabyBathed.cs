using UnityEngine;
using System.Collections;

public class BabyBathed : MonoBehaviour {

    private GameObject bathtub;
    private GameObject go;
    //private Instructions instructions;

    private bool babyBathed = false;
    private bool onTime = false;
    private bool finishedPrinting = false;

    private float timeBabyWasBathed;

    private string hintText1 = "OBSERVATION: baby and baby clothes covered in milk expectoration.";
    private string hintText2 = "OBSERVATION: baby playing in empty tub.";

    private string[] goodCompletionText = { "OBSERVATION: baby clean, giggling, engaging in water play.",
        "CONCLUSION: bathing schedule followed.",
        "PROJECTED RESULT: child will grow to be professional swimmer." };

    private string[] badCompletionText = { "OBSERVATION: baby clean, but displays confused behaviour.",
        "CONCLUSION: bathed child at irregular time.",
        "PROJECTED RESULTS: Disruption of bedtime schedule. Lifelong fear of water." };

    private string instructionText;

    void Awake()
    {
        bathtub = GameObject.Find("Bathtub");
        if (go != null)
            go = GameObject.Find("InstructionText");
        //if (instructions != null)
        //    instructions = (Instructions)GameObject.getComponent(typeof(Instructions));
    }

    // Update is called once per frame
    void Update()
    {
        if (babyBathed)
        {
            timeBabyWasBathed += 1;

            if (!finishedPrinting)
            {
                if (onTime)
                {
                    if (timeBabyWasBathed <= 300)
                        instructionText = goodCompletionText[0];
                    else if (timeBabyWasBathed <= 600)
                        instructionText = goodCompletionText[1];
                    else if (600 < timeBabyWasBathed && timeBabyWasBathed <= 900)
                        instructionText = goodCompletionText[2];
                    else
                        finishedPrinting = true;
                }
                else {
                    if (timeBabyWasBathed <= 300)
                        instructionText = badCompletionText[0];
                    else if (timeBabyWasBathed <= 600)
                        instructionText = badCompletionText[1];
                    else if (600 < timeBabyWasBathed && timeBabyWasBathed <= 900)
                        instructionText = badCompletionText[2];
                    else
                        finishedPrinting = true;
                }
            }

        }
        else {
            if (bathtub.transform.IsChildOf(transform.root))
            {
                babyBathed = true;
                timeBabyWasBathed = 0;
                // If between 9-10pm
                if (1944000 < Timer.getCurrentTime() && Timer.getCurrentTime() < 2160000)
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
