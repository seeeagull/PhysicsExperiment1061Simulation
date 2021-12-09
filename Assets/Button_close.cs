using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_close : MonoBehaviour
{
    public GameObject Seting;
    // Start is called before the first frame update
    void Start()
    {
        Seting.SetActive(false);
    }

    // Update is called once per frame
    public void click () {
        Seting.SetActive(false);
    }
}
