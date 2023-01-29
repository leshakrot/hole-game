using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject canvasPortrait;
    public GameObject canvasLandscape;
    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt) levelButtons[i].interactable = false;
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Level " + gameObject.name);
    }

    private void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            canvasPortrait.SetActive(true);
            canvasLandscape.SetActive(false);
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            canvasPortrait.SetActive(false);
            canvasLandscape.SetActive(true);
        }
    }
}
