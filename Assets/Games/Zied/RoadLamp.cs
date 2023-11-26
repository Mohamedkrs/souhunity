using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLamp : MonoBehaviour
{
    private GameObject litObject;
    private GameObject darkness1;
    private GameObject darkness2;
    private GameObject darkness3;
    private GameObject popUp;

    void Start()
    {
        litObject = transform.GetChild(4).gameObject;
        popUp = transform.GetChild(8).gameObject;
        litObject.SetActive(false);
        popUp.SetActive(false);
    }

    public bool isItDark()
    {
        if (!GetComponent<LightSensorController>().isItDark())
        {
            darkness1 = transform.GetChild(5).gameObject;
            darkness2 = transform.GetChild(6).gameObject;
            darkness3 = transform.GetChild(7).gameObject;

            litObject.SetActive(true);
            darkness1.SetActive(false);
            darkness2.SetActive(false);
            darkness3.SetActive(false);
            popUp.SetActive(false); 
            return false;
        }
        else{
            popUp.SetActive(true); 
            return true;
        }
    }
}
