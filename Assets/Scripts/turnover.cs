using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using DG.Tweening;
public class turnover : MonoBehaviour
{
    private int enable = 0;
    public Vector3 val = new Vector3(0, 0, 0);
    public GameObject convex_len;
    private GameObject Lit;
    private RayTracing OurRay;
    private Vector3 ori_pos;
    private Quaternion ori_rot;

    private void Start()
    {
        Lit = GameObject.Find("Omni002");
        OurRay = Lit.GetComponent("RayTracing") as RayTracing;
    }
    private void delay()
    {

    }
    public void click()
    {
        OurRay.LightEnable = false;

        //Debug.Log(convex_len);

        ori_pos = convex_len.transform.position;
        ori_rot = convex_len.transform.rotation;
        Sequence turn_it_over = DOTween.Sequence();
        turn_it_over.Append(convex_len.transform.DOMove(ori_pos + new Vector3(0, 50, 0), 1.0f));
        turn_it_over.Append(convex_len.transform.DORotate(new Vector3(0, 0, 180), 3.0f));
        turn_it_over.Append(convex_len.transform.DOMove(ori_pos + new Vector3(0, 0, 0), 1.0f));

        turn_it_over.Play();
        turn_it_over.Restart();

        Invoke("turnLitOn", 6);
    }
    public void turnLitOn()
    {
        convex_len.transform.position = ori_pos;
        convex_len.transform.rotation = ori_rot;
        OurRay.LightEnable = true;
    }
}
