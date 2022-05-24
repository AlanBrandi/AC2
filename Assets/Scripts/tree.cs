using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public LayerMask mask;
    public Material defaultMaterial;
    public Material AlphaMaterial;
    MeshRenderer meshRenderer;
    GameObject player;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        player = GameObject.Find("Player");
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(player.transform.position);
        if (Physics.Raycast(ray, out hit, 200, mask))
        {
        
            meshRenderer.material = AlphaMaterial;
        }
        else
        {
            meshRenderer.material = defaultMaterial;
        }
    }
}


