using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float startTime;
    private float timeRunning;
    private float pauseTime;
    private float resumeTime;
    private bool pause = false;
    private float seconds;
    private float minutes;
    public bool setToPause = false;
    public bool setToResume = false;

    private string timerText;
    public Text timerTextGame;
    public Text timerTextEnd;
    public Text timerTextPause;
    public Text timerTextKill;

    private void Awake()
    {
        startTime = Time.time;
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (setToPause)
        {
            PauseTimer();
            if (setToResume)
            {
                ResumeTimer();
                setToPause = false;
                setToResume = false;
            }
        }
        if (!pause)
        {
            timeRunning = Time.time - startTime;
        }

        seconds = Mathf.Floor(timeRunning) % 60;
        minutes = Mathf.Floor(timeRunning / 60);
        // Debug.Log(minutes + ":" + seconds);
        timerText = TimeToString(minutes, seconds);
        timerTextEnd.text = timerText;
        timerTextGame.text = timerText;
        timerTextPause.text = timerText;
        timerTextKill.text = timerText;
	}

    /*void StartTime()
    {
        pause = false;
        startTime = Time.time;
    }

    void UpdateTime()
    {
        timeRunning = Time.time - startTime;
    }*/

    public void PauseTimer()
    {
        pause = true;
        //return timeRunning;
    }

    public void ResumeTimer()
    {
        pause = false;
        startTime = Time.time - timeRunning;
        
    }

    string TimeToString(float minutes, float seconds)
    {
        if (minutes < 1)
        {
            if (seconds < 10)
            {
                return "00:0" + seconds.ToString();
            }
            else
            {
                return "00:" + seconds.ToString();
            }
        }
        else if (minutes >= 1 && minutes < 10)
        {
            if (seconds < 10)
            {
                return "0" + minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                return "0" + minutes.ToString() + ":" + seconds.ToString();
            }
        }
        else
        {
            if (seconds < 10)
            {
                return minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                return minutes.ToString() + ":" + seconds.ToString();
            }
        }
    }


}
