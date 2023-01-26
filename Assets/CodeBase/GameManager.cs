using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int eatableObjectsCount;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Slider hungerSlider;
    HoleController holeController;

    public static GameManager Instance;

    private void Start()
    {
        holeController = GetComponent<HoleController>();
        pausePanel.SetActive(false);
        hungerSlider.maxValue = eatableObjectsCount;
    }
    private void Update()
    {
        if(eatableObjectsCount <= 0)
        {
            winPanel.SetActive(true);
            restartButton.SetActive(false);
            pauseButton.SetActive(false);
            hungerSlider.gameObject.SetActive(false);
        }
    }

    public void Subtract()
    {
        eatableObjectsCount--;
        hungerSlider.value++;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        restartButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
