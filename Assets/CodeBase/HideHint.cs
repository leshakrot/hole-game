using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHint : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private GameObject pausePanel;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void Update()
    {
        if (HoleController.Instance.horizontalInput > 0 || HoleController.Instance.verticalInput > 0) StartCoroutine(Hide());
        if (pausePanel.gameObject.activeSelf == true) gameObject.SetActive(false);
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
