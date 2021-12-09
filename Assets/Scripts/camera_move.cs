using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
     public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;   

        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed; 

        transform.Translate(x, 0, z);    

        if (Input.GetKey(KeyCode.Q))

        {

            transform.Rotate(0, -25 * Time.deltaTime, 0, Space.Self);

        }      

        if (Input.GetKey(KeyCode.E))

        {

            transform.Rotate(0, 25 * Time.deltaTime, 0, Space.Self);

        }      

        if (Input.GetKey(KeyCode.Z))

        {

            transform.Rotate(-25 * Time.deltaTime, 0, 0, Space.Self);

        }        

        if (Input.GetKey(KeyCode.C))

        {

            transform.Rotate(25 * Time.deltaTime, 0, 0, Space.Self);

        }      

        if (Input.GetKey(KeyCode.H))

        {

            transform.Translate(0, 10 * Time.deltaTime, 0);

        }        

        if (Input.GetKey(KeyCode.N))

        {

            transform.Translate(0, -10 * Time.deltaTime, 0);

        }
    }
}
