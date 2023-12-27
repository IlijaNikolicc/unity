using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private float t;
    public string minutes, seconds;
    private bool finnished = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (finnished)
            return;

        t = Time.time - startTime;

        minutes = ((int) t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }
    public void Finnished()
    {
        finnished = true;
        timerText.color = Color.red;
    }
}
