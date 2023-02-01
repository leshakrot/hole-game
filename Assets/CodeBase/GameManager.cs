using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SkipLevelExtern();

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public int eatableObjectsCount;
    public int nextSceneLoad;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject volumeButton;
    [SerializeField] private GameObject musicButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Slider hungerSlider;
    public GameObject levelMusic;
    HoleController holeController;

    public static GameManager Instance;

    private void Start()
    {
        int temp = PlayerPrefs.GetInt("isMusicActive", 1);
        int temp1 = PlayerPrefs.GetInt("isGlobalSoundActive", 1);
        bool isMusicActive = Convert.ToBoolean(temp);
        levelMusic.gameObject.SetActive(isMusicActive);
        AudioListener.volume = PlayerPrefs.GetInt("isGlobalSoundActive");
        holeController = GetComponent<HoleController>();
        pausePanel.SetActive(false);
        hungerSlider.maxValue = eatableObjectsCount;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        if(eatableObjectsCount <= 0)
        {
            ShowAdv();
            winPanel.SetActive(true);
            DisableHudButtons();
            hungerSlider.gameObject.SetActive(false);
            levelMusic.gameObject.SetActive(false);
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
        SceneManager.LoadScene(nextSceneLoad);
        if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        DisableHudButtons();
        pausePanel.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        EnableHudButtons();
        pausePanel.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void VolumeOff()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("isGlobalSoundActive", 1);
        }
        else if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("isGlobalSoundActive", 0);
        }

    }

    public void MusicOff()
    {
        if (levelMusic.gameObject.activeSelf == true)
        {
            levelMusic.gameObject.SetActive(false);
            PlayerPrefs.SetInt("isMusicActive", 0);
        }
        else
        {
            levelMusic.gameObject.SetActive(true);
            PlayerPrefs.SetInt("isMusicActive", 1);
        }
    }

    void DisableHudButtons()
    {
        restartButton.SetActive(false);
        pauseButton.SetActive(false);
        volumeButton.SetActive(false);
        musicButton.SetActive(false);
    }

    void EnableHudButtons()
    {
        restartButton.SetActive(true);
        pauseButton.SetActive(true);
        volumeButton.SetActive(true);
        musicButton.SetActive(true);
    }

    public void ShowAdvButton()
    {
        SkipLevelExtern();
    }

    public void SkipLevel()
    {
        SceneManager.LoadScene(nextSceneLoad);
    }
}
