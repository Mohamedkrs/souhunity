using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    // public static AudioSource Music;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }
    public void StartTheMaze(bool menu)
    {
        if (menu)
        {
            SceneManager.LoadScene("TheMazeMainMenu");
        }
        else
        {
            SceneManager.LoadScene("TheMaze");

        }

    }

    public void StartTheJump(bool menu)
    {
        if (menu)
        {
            SceneManager.LoadScene("TheJumpMainMenu");
        }
        else
        {
            SceneManager.LoadScene("TheJump");

        }

    }
    public void StartTheJumper(bool menu)
    {
        if (menu)
        {
            SceneManager.LoadScene("TheJumperMainMenu");
            Screen.orientation = ScreenOrientation.Portrait;


        }
        else
        {
            SceneManager.LoadScene("TheJumper");

        }

    }
    public void StartTheEscapeRoom()
    {
        SceneManager.LoadScene("TheEscapeRoom");
    }
    public void StartTheCarSurfer(bool menu)
    {
        if (menu)
        {
            SceneManager.LoadScene("TheCarSurferMainMenu");
        }
        else
        {
            SceneManager.LoadScene("TheCarSurfer");

        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
