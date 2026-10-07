using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] Transform destination;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDestination()
    {
        Vector3 destinationPosition = destination.transform.position;
        agent.SetDestination(destinationPosition);
    }
}
 