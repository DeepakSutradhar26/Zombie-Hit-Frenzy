using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateZombieDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent != null && agent.enabled == true){
            if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance){
                IncrementWaypointIndex();
                UpdateZombieDestination();  
            }
        }
    }

    // For zombie to wander around arera, this code is for their next destination
    void UpdateZombieDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    // Zombie after reaching their desination will get their next destination 
    void IncrementWaypointIndex()
    {
        int L = waypoints.Length;
        if(L > 0) waypointIndex = (waypointIndex + 1) % L;
    }
}
