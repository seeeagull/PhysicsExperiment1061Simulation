using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_pole_ud1 : MonoBehaviour
{
    public bool movable=false;
    public float speed = 0.1f;
    private void OnMouseDown()
    {
        speed = 0.1f;
        GameObject enable_ctrl = GameObject.Find("Button_enter");
        if (enable_ctrl.gameObject.GetComponent<enter_check>().flag1 == 0 || enable_ctrl.gameObject.GetComponent<enter_check>().flag1 == 2)
            movable = false;
        else movable = !movable;
        print("Scroll this! Now the movable is");
        print(movable);
        if(movable)
        {
            GameObject Concave = GameObject.Find("CLensExPole");
            drag_pole_ud2 ctrl= Concave.GetComponent<drag_pole_ud2>();
            ctrl.movable = false;
        }
    }
    private void Update()
    {
        float del_y = Input.mouseScrollDelta.y;
        Vector3 new_pos = transform.position;
        new_pos.y += del_y*speed;
        if (movable)
        {
            //print(speed);
            transform.position = new_pos;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pole")
        {
            movable = false;
            print("不能再往上了！\n");
        }
        if(collision.gameObject.tag=="Ground")
        {
            movable = false;
            print("不能再往下了！\n");
        }
    }
}
