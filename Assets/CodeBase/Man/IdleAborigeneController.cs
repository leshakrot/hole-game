using UnityEngine;

public class IdleAborigeneController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
        //animator.SetBool("Idle", !animator.GetBool("Idle"));
    }
}
