using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    private float shakeThreshold = 2.0f; 
    private Vector3 lastAcceleration;
    private bool isPlaying = false;
    private GameObject quote;

    void Start()
    {
        lastAcceleration = Input.acceleration;
        quote = transform.GetChild(0).gameObject;
        quote.SetActive(false);
    }

    public bool GotBones()
    {
            if(!isPlaying)
            {
                isPlaying = true;
                audioSource.PlayOneShot(audioClip);
            }

            Vector3 currentAcceleration = Input.acceleration;
            float deltaAcceleration = Vector3.Distance(currentAcceleration, lastAcceleration);

            if (deltaAcceleration > shakeThreshold)
            {
                Debug.Log("Shake detected!");
                audioSource.Stop();
                quote.SetActive(true);
                return true;
            }
            
            Handheld.Vibrate();
            lastAcceleration = currentAcceleration;
            return false;
    }

}
