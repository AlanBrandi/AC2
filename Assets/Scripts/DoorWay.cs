using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DoorWay : MonoBehaviour
{
    
    public Vector3 vectorPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CamManager.Instance.SwitchCam();
        }
    }
}
