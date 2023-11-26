using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TheMazeMainMenu : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Toggle>().isOn = TheMazeSettings.noCollision;
    }
}
