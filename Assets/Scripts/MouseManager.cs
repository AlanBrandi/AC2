using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMouseClickInteractable;
    public LayerMask mask;
    public Texture2D arrow;
    public Texture2D doorWay;
    public Texture2D doorWayBack;
    public Texture2D target;
    public  float rayDistance = 200;
    RaycastHit hit;
    Ray ray;
    DoorWay door;
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance, mask))
        {
            switch (hit.collider.tag)
            {
                case "Rock":
                    Cursor.SetCursor(arrow, Vector3.zero, CursorMode.Auto);
                    break;
                case "DoorWay":
                        Cursor.SetCursor(doorWay, Vector3.zero, CursorMode.Auto);
                    if (Input.GetMouseButton(1))
                    {
                        door = hit.collider.GetComponent<DoorWay>();
                        OnMouseClickInteractable.Invoke(door.vectorPosition);
                    }
                    break;
                case "DoorWayBack":
                    Cursor.SetCursor(doorWayBack, Vector3.zero, CursorMode.Auto);
                    if (Input.GetMouseButton(1))
                    {
                        door = hit.collider.GetComponent<DoorWay>();
                        OnMouseClickInteractable.Invoke(door.vectorPosition);
                    }
                    break;
                default:
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    if (Input.GetMouseButton(1))
                    {
                        Debug.Log(hit.collider.tag);
                        OnMouseClickInteractable.Invoke(hit.point);
                    }
                    break;
            }   
        }
        else
        {
            Cursor.SetCursor(arrow, Vector3.zero, CursorMode.Auto);
        }
    }
}
