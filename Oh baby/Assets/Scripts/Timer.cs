using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float maxTime = 1296000; // start clock at 6pm at this
    public Text textTime; 

	private static float currentTime;
    // Use this for initialization
    void Start() {
        currentTime = maxTime;
        textTime = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
		currentTime += 120; //number of in game seconds advanced per frame of real life

        string hours = ((int)currentTime / 216000).ToString();
        int rawMinutes = ((int) currentTime / 3600)%60;
        string minutes = rawMinutes.ToString();

        if (rawMinutes < 10) {
            minutes = "0" + rawMinutes.ToString();
        }
		//Debug.Log(currentTime);
        textTime.text = hours + ":" + minutes + " PM";
    }

    public static float getCurrentTime() {
        return currentTime;
    }
}