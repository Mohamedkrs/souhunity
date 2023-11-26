using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject time;
    void Start()
    {

        print(time.GetComponent<Text>().text);
        print(this.gameObject.GetComponent<Text>());
        this.gameObject.GetComponent<Text>().text = time.GetComponent<Text>().text;
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     print(time.GetComponent<Text>().text);
    //     this.gameObject.GetComponent<Text>().text = time.GetComponent<Text>().text;
    // }
}
