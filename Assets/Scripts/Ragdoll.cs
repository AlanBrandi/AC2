using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public Ray ray;
    public LayerMask mask;
    public GameObject BloodFX;
    public float bulletForce = 1000;

    AudioSource audioDie;

    private void Start()
    {
        audioDie = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 20, mask))
        {
           audioDie.Play();

            hit.collider.GetComponent<Rigidbody>().AddForce(ray.direction * bulletForce);
            Instantiate(BloodFX, hit.point, Quaternion.LookRotation(hit.normal), hit.collider.transform);
            enabled = false;
        }
    }
}
