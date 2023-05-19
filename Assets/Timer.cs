using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timerFormats = new Dictionary<TimerFormats, string>();

    void Start()
    {
        timerFormats.Add(TimerFormats.Whole, "0");
        timerFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timerFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }



    // Update is called once per frame
    void Update()
    {
        currentTime =countDown ? currentTime -= Time.deltaTime : currentTime + Time.deltaTime;
        
        if(hasLimit && ((countDown && currentTime <= timerLimit) || (! countDown && currentTime >= timerLimit )))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red ;
            enabled = false ;
        }
        SetTimerText();
    }

    private void SetTimerText()
{
    timerText.text = hasFormat ? currentTime.ToString(timerFormats[format]) : currentTime.ToString();
}


    public enum TimerFormats 
    {
        Whole,
        TenthDecimal,
        HundrethsDecimal
    }
}
