using UnityEngine;
using System.Collections;

public class BabyLift : MonoBehaviour
{

    private GameObject go;
    //private Instructions instructions;

    private bool babyHeld = false;
    private bool onTime = false;
    private bool finishedPrinting = false;

    private int timeBabyWasHeld;

    private string instructionText;
    private string hintText = "OBSERVATION: baby cooing, smiling.";

    private string[] goodCompletionText = { "OBSERVATION: baby cooing, smiling.",
        "CONCLUSION: baby’s social needs fulfilled in timely manner.",
        "PROJECTED RESULTS: growth into world-famous philanthropist adult." };

    private string[] badCompletionText = { "OBSERVATION: baby displays continued distress.",
        "CONCLUSION: did not respond to baby’s social needs at correct time.",
        "PROJECTED RESULT: stunted social development, future serial killer." };

    void Awake()
    {
        if (go != null)
            go = GameObject.Find("InstructionText");
        // if (instructions != null)
        // instructions = (Instructions) go.getComponent(typeof(Instructions));
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (babyHeld)
        {
            timeBabyWasHeld += 1;

            if (!finishedPrinting)
            {
                if (onTime)
                {
                    if (timeBabyWasHeld < 300)
                        instructionText = goodCompletionText[0];
                    else if (timeBabyWasHeld <= 600)
                        instructionText = goodCompletionText[1];
                    else if (600 < timeBabyWasHeld && timeBabyWasHeld <= 900)
                        instructionText = goodCompletionText[2];
                    else
                        finishedPrinting = true;
                }
                else {
                    if (timeBabyWasHeld <= 300)
                        instructionText = badCompletionText[0];
                    else if (timeBabyWasHeld <= 10)
                        instructionText = badCompletionText[1];
                    else if (10 < timeBabyWasHeld && timeBabyWasHeld <= 15)
                        instructionText = badCompletionText[2];
                    else
                        finishedPrinting = true;
                }
            }
            else {
                if (this.transform.root.name == "Player")
                {
                    babyHeld = true;
                    timeBabyWasHeld = 0;
                    // if between 6-7pm
                    if (1296000 < Timer.getCurrentTime() && Timer.getCurrentTime() < 1512000)
                    {
                        Score.ritualsDone += 2;
                        onTime = true;
                    }
                    else
                        Score.ritualsDone += 1;
                    //this.enabled = false;
                }
            }

            // upon entering bedroom for the first time, display hintText
            // if (/*wallCollide*/)
        }
    }
}
