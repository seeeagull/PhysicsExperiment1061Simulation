using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_convex : MonoBehaviour
{
    private Vector3 depth;
    private Vector3 offset;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        depth = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, depth.y, depth.z);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);

    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, depth.y, depth.z);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition)+offset;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Optical")
        {
            print("���󣺾��������\n");
        }
    }
}
