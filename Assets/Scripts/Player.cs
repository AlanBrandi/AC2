using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent<Vector3> OnMouseClickInteractable;
    NavMeshAgent agent;
    MouseManager manager;
    Animator animator;
    public float magnitude;

    private void Start()
    {
        manager = FindObjectOfType<MouseManager>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        manager.OnMouseClickInteractable.AddListener(Move);
    }
    private void Update()
    {
        magnitude = agent.velocity.magnitude;
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
    public void Move(Vector3 Location)
   {
        agent.SetDestination(Location);
   }
}
