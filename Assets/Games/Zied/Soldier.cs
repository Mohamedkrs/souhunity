using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private GameObject quote;

    void Start()
    {
        quote = transform.GetChild(1).gameObject;
        quote.SetActive(false);
    }

    public void Quote(bool hasBones)
    {
        if (hasBones)
        {
            quote.GetComponent<TextMesh>().text = "From bones to reward, your valor is our treasure";
        }
        quote.SetActive(true);
    }

    public void RemoveQuote()
    {
        quote.SetActive(false);
    }
}
