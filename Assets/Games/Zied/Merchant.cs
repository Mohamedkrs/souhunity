using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    private GameObject quote;

    void Start()
    {
        quote = transform.GetChild(1).gameObject;
        quote.SetActive(false);
    }

    public void Quote(bool hasItem)
    {
        if (hasItem)
        {
            quote.GetComponent<TextMesh>().text = "Ah! I'll buy it at a high price!";
        }
        quote.SetActive(true);
    }

    public void RemoveQuote()
    {
        quote.SetActive(false);
    }
}
