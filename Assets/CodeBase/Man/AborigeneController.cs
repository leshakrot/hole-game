using UnityEngine;
using UnityEngine.AI;

public class AborigeneController : MonoBehaviour
{
    [SerializeField] private float reactionDistanceToHole;
    [SerializeField] private float navMeshSpeed;
    Animator animator;
    NavMeshAgent navMeshAgent;
    HoleController hole;
    ManController man;

    public bool IsStopped { get; set; }
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        hole = FindObjectOfType<HoleController>();
        man = FindObjectOfType<ManController>();
    }

    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, hole.transform.position);
        if (distance < reactionDistanceToHole)
        {
            animator.SetBool("Move", !animator.GetBool("Move"));
            navMeshAgent.speed = navMeshSpeed;
            navMeshAgent.SetDestination(hole.transform.position);
        }

        else if(distance > reactionDistanceToHole)
        {
            animator.SetBool("Move", false);
            navMeshAgent.speed = 0f;
        }
        else if(man.IsOnGround)
        {
            animator.enabled = true;
            animator.SetBool("Move", !animator.GetBool("Move"));
            if (navMeshAgent.enabled) navMeshAgent.SetDestination(man.transform.position);
            if (IsStopped)
            {
                animator.enabled = false;
                navMeshAgent.enabled = false;
            }
        }       
        
        else
        {
            IsStopped = true;
            //navMeshAgent.enabled = false;
            //animator.enabled = false;     
        }
    }
}
