using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_pole : MonoBehaviour
{
    private Vector3 depth;
    private Vector3 offset;
    private bool movable = false;
    private bool isCollided = false;
    private Vector3 set_pos;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        GameObject enable_ctrl = GameObject.Find("Button_enter");
        //Debug.Log(enable_ctrl);
        if (enable_ctrl.gameObject.GetComponent<enter_check>().flag1 == 1 || enable_ctrl.gameObject.GetComponent<enter_check>().flag1 == 3)
        {
            if (isCollided)
            {
                transform.position = set_pos;
                isCollided = false;
            }
            movable = true;
        }
        depth = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, depth.y, depth.z);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);

    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, depth.y, depth.z);
        if (movable)
        {
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
            //print(transform.position);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Optical" || collision.gameObject.tag == "Screen" || collision.gameObject.name == "ruler")
        {
            movable = false;
            isCollided = true;
            if (tag == "Optical")
            {
                if (collision.gameObject.name == "SpotLit" || collision.gameObject.name == "ConvexLens")
                    set_pos = transform.position - new Vector3((float)10, 0, 0);
                else if (collision.gameObject.name == "Screen" || collision.gameObject.name == "ConcaveLens")
                    set_pos = transform.position + new Vector3((float)10, 0, 0);

            }
            else
            {
                if (collision.gameObject.tag == "Optical")
                    set_pos = transform.position - new Vector3((float)10, 0, 0);
                else if (collision.gameObject.name == "ruler")
                    set_pos = transform.position + new Vector3((float)10, 0, 0);
            }
            print("两光具距离过近！\n");
        }
    }
}
