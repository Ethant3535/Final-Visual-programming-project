using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour

{
    float Seconds = 0;
    float initialTime = 5;
    float currentTime;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        Seconds += Time.deltaTime;
        currentTime = initialTime - Seconds;
        timerText.text = "Time: " + (int)currentTime + "s";
        bool TimerPastZero = false;

        if (currentTime <= 0)
        {
            if (TimerPastZero == false)
                print("GAMEOVER");
                

            TimerPastZero = true;
        }

        else
            TimerPastZero = false;




    }



}