using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    // public static event Action OnCountdownEnd;
    float initialTime = 0;
    float currentTime;
    bool isCounting = true;

    private void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        // if (isCounting)
        // {
        //     if (currentTime < 1)
        //     {
        //         print("im being called");
        //         countdownText.text = "00:00";
        //         isCounting = false;
        //         OnCountdownEnd?.Invoke();

        //     }
        //     else
        //     {
        //         currentTime -= Time.deltaTime;
        //         int minutes = Mathf.FloorToInt(currentTime / 60);
        //         int seconds = Mathf.FloorToInt(currentTime % 60);
        //         countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //     }
        // }
        currentTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);


        this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void ResetTimer()
    {
        isCounting = true;
        this.GetComponent<TextMeshProUGUI>().text = "00:00";

    }
}
