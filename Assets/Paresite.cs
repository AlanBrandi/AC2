using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Paresite : MonoBehaviour
{ 
    NavMeshAgent agent;
    public Transform Player;
    Animator animator;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        agent.SetDestination(Player.position);
    }
}
