using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HoleTriggerNoGrow : MonoBehaviour
{
    [SerializeField] private float yDeathBorder = -2f;
    private int counter = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = 9;        
        Debug.Log("Enter");
    }

    private void OnTriggerStay(Collider other)
    {   
        if (other.gameObject.transform.position.y < yDeathBorder)
        {
            if (other.gameObject.CompareTag("Aborigene")) ReloadScene();
            Destroy(other.gameObject);
            if (other.gameObject.CompareTag("Column")) counter++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.layer = 0;                
        Debug.Log("Exit");
    }

    private void Update()
    {
        if(counter == 38) ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
