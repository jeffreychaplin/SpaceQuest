using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour {

    private TextMeshProUGUI timerText;
    private float startTime;

	// Use this for initialization
	void Start () {
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float t = (Time.time - startTime);
        string hour = ((int)t / 3600).ToString("d2");
        string minutes = ((int)t / 60).ToString("d2");
        string seconds = (t % 60).ToString("f2");

        //timerText.text = hour + " : " + minutes + " : " + seconds;

        TimeSpan timeSpan = TimeSpan.FromSeconds(t);
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }
}
