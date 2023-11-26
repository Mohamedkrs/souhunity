using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class Well : MonoBehaviour
{
    private GameObject title;
    private GameObject subtitle;
    private GameObject chest;
    private GameObject openChest;
    private Vector3 initialAcceleration;
    private float accumulatedAcceleration = 0f;

    void Start()
    {
        title = transform.GetChild(0).gameObject;
        subtitle = transform.GetChild(1).gameObject;
        openChest = transform.GetChild(2).gameObject;
        chest = transform.GetChild(3).gameObject;
        title.SetActive(false);
        subtitle.SetActive(false);
        openChest.SetActive(false);
        // InputSystem.EnableDevice(Accelerometer.current);
        initialAcceleration = Input.acceleration;
    }

    public void CheckAcceleration()
    {
        Vector3 currentAcceleration = Input.acceleration;

        float deltaAcceleration = Vector3.Distance(currentAcceleration, initialAcceleration);

        accumulatedAcceleration += deltaAcceleration;

        float rotationThreshold = 60f;

        Debug.Log(accumulatedAcceleration);

        // Check if the accumulated acceleration exceeds the threshold, indicating rotation
        if (accumulatedAcceleration >= rotationThreshold)
        {
            title.SetActive(true);
            subtitle.SetActive(true);
            chest.SetActive(false);
            openChest.SetActive(true);
            accumulatedAcceleration = 0f;
        }

        // Update the initial acceleration for the next frame
        initialAcceleration = currentAcceleration;
    }
}
