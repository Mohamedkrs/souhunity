using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static int forwardSpeed = 10;
    public static float volume = 1.0f;
    public static bool noCollision = false;
    public static bool vibrate = true;
    public static Settings Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
   
    public void SetVolume(GameObject slider)
    {

        volume = slider.GetComponent<Slider>().value;
    }
    public void SetVibration()
    {

        vibrate = !vibrate;

    }
    public void GetVolume()
    {
        this.GetComponent<Slider>().value = volume;

    }
}
