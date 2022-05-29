using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol_points_random : MonoBehaviour
{
    public List<Point> lstPoints;
    NavMeshAgent agent;

    int indexSorteado = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(lstPoints[indexSorteado].transform.position);

        for (int x = 0; x < lstPoints.Count; x++)
        {
            lstPoints[x].index = x;
        }
    }


   
}
