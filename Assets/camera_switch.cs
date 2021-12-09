using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_switch : MonoBehaviour
{
    public GameObject target_camera;
    public GameObject other_camera1;
    public GameObject other_camera2;

    void Start()
    {
        target_camera.SetActive(true);
        target_camera.SetActive(false);
        other_camera1.SetActive(false);
        other_camera2.SetActive(false);
    }

    // Update is called once per frame
    public void click () {

        if(target_camera.activeSelf == false)
        {
            target_camera.SetActive(true);
            other_camera1.SetActive(false);
            other_camera2.SetActive(false);
        }
        else
        {
            target_camera.SetActive(false);
        }
         
            // countint ++ ;
            // if (countint % 2 == 0)
            // {
            //     Seting.SetActive(false);
            // }
            // else
            // {
            //     Seting.SetActive(true);
            // }       

     }
}
