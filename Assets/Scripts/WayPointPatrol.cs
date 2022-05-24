using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WayPointPatrol : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public Transform[] waypoints;

    private int currentWaypointIndex;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //se manda al primer waypoint al iniciar la partida
        navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        
    }

    // Update is called once per frame
    void Update()
    {
        //si llega al punto se debe detener
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance){
            //sistema de rutas predecible
            //se dirge a otro punto al sumarle 1 
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}
