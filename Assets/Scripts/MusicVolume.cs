using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<AudioSource>().volume = Settings.volume;
    }


}
