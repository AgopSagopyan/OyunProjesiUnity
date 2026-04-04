using UnityEngine;
using UnityEngine.AI;

public class NavMeshChaserEnemyMovement : MonoBehaviour
{
    public Transform targetPlayer;

    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetPlayer.position);

        /*

       NavMeshHit hit; 

       if(NavMesh.SamplePosition(targetPlayer.position, out hit, 2.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        */
    }
}
