using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent agent;
    MouseManager manager;
    Animator animator;

    private void Start()
    {
        manager = FindObjectOfType<MouseManager>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        manager.OnMouseClickInteractable.AddListener(Move);
    }
    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
    public void Move(Vector3 Location)
   {
        agent.SetDestination(Location);
   }
}
