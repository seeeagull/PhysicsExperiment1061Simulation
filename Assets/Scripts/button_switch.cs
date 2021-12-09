using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_switch : MonoBehaviour
{
    public GameObject Seting;
    private GameObject Lit;
    private RayTracing OurRay;

    // Start is called before the first frame update
    void Start()
    {
        Seting.SetActive(false);
    }

    // Update is called once per frame
    public void click () {

        if(Seting.activeSelf == false)
        {
            Seting.SetActive(true);
            if(Seting.GetComponent<CanvasGroup>())
                Seting.GetComponent<CanvasGroup>().alpha = 1;
        }
        else
        {
            Seting.SetActive(false);
        } 

     }
}
