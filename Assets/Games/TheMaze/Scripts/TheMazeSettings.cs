using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheMazeSettings : MonoBehaviour
{
    public static int rows = 10;
    public static float volume = 1.0f;
    public static bool noCollision = false;
    public static TheMazeSettings Instance;

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
            rows = 10;
        }
        else if (diffculty == 2)
        {
            rows = 15;
        }
        else if (diffculty == 3)
        {
            rows = 20;
        }
    }
    public void SetNoCollision()
    {
        noCollision = !noCollision;
        print(noCollision);
    }
    public void GetNoColl(GameObject checkBox)

    {
        print(noCollision);
        checkBox.GetComponent<Toggle>().enabled = noCollision;
    }

}
