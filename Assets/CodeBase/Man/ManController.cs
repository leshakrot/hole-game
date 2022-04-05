using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ManController : MonoBehaviour
{
    AborigeneController aborigene;
    public bool IsOnGround { get; set; }
    private void Start()
    {
        aborigene = FindObjectOfType<AborigeneController>();
    }

    private void Update()
    {
        if (transform.position.y < 2f) IsOnGround = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out AborigeneController aborigene))
        {
            aborigene.IsStopped = true;
            Debug.Log("GAME OVER!");
        }
    }
}
