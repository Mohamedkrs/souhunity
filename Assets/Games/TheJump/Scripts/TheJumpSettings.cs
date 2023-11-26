using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheJumpSettings : MonoBehaviour
{
    public static int speed = 10;
    public static TheJumpSettings Instance;

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
    public void SetDifficulty(int diffculty)
    {
        if (diffculty == 1)
        {
            speed = 10;
        }
        else if (diffculty == 2)
        {
            speed = 50;
        }
        else if (diffculty == 3)
        {
            speed = 200;
        }
    }
   

}
