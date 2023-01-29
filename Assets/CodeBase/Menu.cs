using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("levelAt") == 0) SceneManager.LoadScene("Level " + 1);
        else SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("levelAt"));
    }

    public void EnterLevelsMenu()
    {
        SceneManager.LoadScene("Levels");
    }
}
