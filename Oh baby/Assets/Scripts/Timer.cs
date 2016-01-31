using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float maxTime = 1296000; // start countdown at this
    private float currentTime;
    public Text textTime; 


    // Use this for initialization
    void Start() {
        currentTime = maxTime;
        textTime = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        currentTime += 30;

        string hours = ((int)currentTime / 216000).ToString();
        int rawMinutes = ((int) currentTime / 3600)%60;
        string minutes = rawMinutes.ToString();

        if (rawMinutes < 10) {
            minutes = "0" + rawMinutes.ToString();
        }

        textTime.text = hours + ":" + minutes + " PM";
    }

    public float getCurrentTime() {
        return currentTime;
    }
}