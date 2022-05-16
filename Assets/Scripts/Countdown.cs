/* 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour

{
    float initialTime = 100;
    float Seconds = 0;
    float currentTime;
    public Text timerText;
    // Start is called before the first frame update

    public void EasyClick()
    {
        initialTime = 30;
    }

    public void MediumClick()
    {
        initialTime = 20;
    }

    public void HardClick()
    {
        initialTime = 10;
    }

    void Update()
    {
        Seconds += Time.deltaTime;
        currentTime = initialTime - Seconds;
        timerText.text = "Time: " + (int)currentTime + "s";
        bool TimerPastZero = false;

        if (currentTime <= 0)
        {
            if (TimerPastZero == false)
                //print("GAMEOVER");
                TimerPastZero = true;
        }
        else
            TimerPastZero = true;

    }

    // Update is called once per frame




}

*/