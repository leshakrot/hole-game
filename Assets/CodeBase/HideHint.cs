using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHint : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
  
    private void Update()
    {
        if (HoleController.Instance.horizontalInput > 0 || HoleController.Instance.verticalInput > 0 || HoleController.Instance.touch.phase == TouchPhase.Moved) Destroy(gameObject);
        if (pausePanel.gameObject.activeSelf == true) gameObject.SetActive(false);
    }
}
