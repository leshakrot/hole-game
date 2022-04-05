using UnityEngine;
using UnityEngine.AI;

public class HoleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private float yDeathBorder = -2f;
    [SerializeField] private int objectsToGrow;
    [SerializeField] private float forceFactor = 100f;
    [SerializeField] private Vector3 scaleChange;
    AborigeneController aborigene;
    GameManager gameManager;
    HoleController holeController;
    private int counter = 0;

    private void Start()
    {
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
        aborigene = FindObjectOfType<AborigeneController>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = 9;
        if (IsAborigene(other))
        {
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            other.gameObject.GetComponent<AborigeneController>().enabled = false;
        } 
        Debug.Log("Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsAborigene(other))
        {
            Swallow(other);    
        }   
        if (other.gameObject.transform.position.y < yDeathBorder)
        {
            if (other.gameObject.CompareTag("Aborigene") && !winPanel.activeSelf) 
            {
                gameOverPanel.SetActive(true);
                restartButton.SetActive(false);
                pauseButton.SetActive(false);
                gameManager.PauseOn();
                holeController.PauseOn();
            } 
            else
                {
                    gameManager.Subtract();
                    counter++;
                    Destroy(other.gameObject);
                }
            if (counter % objectsToGrow == 0) gameObject.transform.localScale += scaleChange;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.layer = 0;
        if (IsAborigene(other))
        {
            other.gameObject.GetComponent<NavMeshAgent>().enabled = true;
            other.gameObject.GetComponent<AborigeneController>().enabled = true;
        }
                
        Debug.Log("Exit");
    }

    private void Swallow(Collider other)
    {
        other.gameObject.GetComponent<AborigeneController>().enabled = false;
        other.gameObject.GetComponent<Animator>().enabled = false;
        other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * forceFactor * Time.smoothDeltaTime, ForceMode.Impulse);
    }

    private bool IsAborigene(Collider other)
    {
        return other.gameObject.TryGetComponent(out AborigeneController aborigene);
    }
}
