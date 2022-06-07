using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Paresite : MonoBehaviour
{

    public List<Point> lstPoints;
    NavMeshAgent agent;
    public Transform Player;
    Animator animator;
    public float Distance;
    public float minDistance = 51;

    public int indexSorteado = 0;
    private void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        for (int x = 0; x < lstPoints.Count; x++)
        {
            lstPoints[x].index = x;
        }
        agent.SetDestination(lstPoints[indexSorteado].transform.position);
    }

    private void Update()
    {
        Distance = Vector3.Distance(this.transform.position, Player.transform.position);

        if (Distance <= minDistance)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
            agent.SetDestination(Player.position);
        }
        else
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
            agent.SetDestination(lstPoints[indexSorteado].transform.position);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {

        while (other.GetComponent<Point>().index == indexSorteado)
        {

            indexSorteado = Random.Range(0, lstPoints.Count);
        }

        agent.SetDestination(lstPoints[indexSorteado].transform.position);
    }

}
