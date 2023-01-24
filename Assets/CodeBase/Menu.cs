using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("J_Level1");
    }

    public void EnterLevelsMenu()
    {
        SceneManager.LoadScene("Levels");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
