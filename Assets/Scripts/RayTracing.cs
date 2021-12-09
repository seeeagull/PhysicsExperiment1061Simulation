using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]

public class RayTracing : MonoBehaviour
{
    public bool LightEnable;
    public int type;
    public Vector3 vlens_initpos, clens_initpos, screen_initpos;
    public bool check_fst;
    public GameObject imag, imag_s, imag_i, imag_c;
    public float f1, f2;
    public float u1, v1, u2, v2;
    private float k1_real, k1_imag, k2_real, k2_imag;
    private Vector3 vlens_center, clens_center, lit_center;

    void Start()
    {
        f1 = (float)40.0;
        f2 = (float)30.0;

        LightEnable = false;
        check_fst = false;
        type = 1;

        vlens_initpos = new Vector3(34.84048f, 185.275f, 8.94154f);
        clens_initpos = new Vector3(-30.73555f, 171.0f, -0.5585003f);
        screen_initpos = new Vector3(-69.6841f, 181.0f, 0.136f);

        imag.SetActive(false);
        imag_s.SetActive(false);
        imag_i.SetActive(false);
    }
    void Update()
    {
        if (LightEnable)
        {
            if (type == 1)
            {
                imag.SetActive(false);
                imag_s.SetActive(false);
                imag_i.SetActive(false);
                u1 = transform.position.x - GameObject.Find("VLens").transform.position.x;
                v1 = GameObject.Find("VLens").transform.position.x - GameObject.Find("screenitself").transform.position.x;

                float y_coord = GameObject.Find("VLens").transform.position.y * (u1 + v1) / u1 - transform.position.y * v1 / u1;
                imag.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, y_coord, transform.position.z);
                imag_s.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, y_coord, transform.position.z);
                imag_i.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, y_coord, transform.position.z);
                if (imag_c.activeSelf)
                    imag_c.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, imag_c.transform.position.y, transform.position.z);
                else
                    imag_c.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, y_coord, transform.position.z);
                
                if (u1 > f1 && v1 < f1)
                {
                    imag_i.SetActive(true);
                    k1_imag = (f1 - v1) / f1 * 0.05f;
                    imag_i.transform.localScale = new Vector3(k1_imag, k1_imag, 0.1f);
                }
                else if (u1 > f1)
                {
                    imag.SetActive(true);
                    imag_s.SetActive(true);
                    if ((v1 - f1) * u1 < f1 * v1)
                    {
                        k1_real = (v1 - f1) / f1 * 0.05f;
                        k1_imag = v1 / u1 * 0.05f;
                    }
                    else
                    {
                        k1_imag = (v1 - f1) / f1 * 0.05f;
                        k1_real = v1 / u1 * 0.05f;
                    }
                    imag.transform.localScale = new Vector3(k1_real, k1_real, 0.1f);
                    imag_s.transform.localScale = new Vector3(k1_imag, k1_imag, 0.1f);
                }
            }
            else if(type == 2)
            {
                imag.SetActive(false);
                imag_s.SetActive(false);
                imag_i.SetActive(false);
                u1 = transform.position.x - GameObject.Find("VLens").transform.position.x;

                if (u1 > f1)
                {
                    v1 = f1 * u1 / (u1 - f1);
                    u2 = v1 - (GameObject.Find("VLens").transform.position.x - GameObject.Find("CLens").transform.position.x);

                    if (u2 > f2)
                    {
                        imag.SetActive(true);
                        imag_s.SetActive(true);
                        float y1_coord = GameObject.Find("VLens").transform.position.y * (u1 + v1) / u1 - transform.position.y * v1 / u1;
                        float y2_coord = GameObject.Find("CLens").transform.position.y * (u2 - v2) / u2 + y1_coord * v2 / u2;
                        imag.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, y2_coord, transform.position.z);
                        imag_s.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, y2_coord, transform.position.z);
                        if (imag_c.activeSelf)
                            imag_c.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, imag_c.transform.position.y, transform.position.z);
                        else
                            imag_c.transform.position = new Vector3(GameObject.Find("screenitself").transform.position.x + 0.2f, y2_coord, transform.position.z);
                        float v2_cal = f2 * u2 / (u2 - f2);
                        v2 = GameObject.Find("CLens").transform.position.x - GameObject.Find("screenitself").transform.position.x;
                        if (v2 < v2_cal)
                        {
                            k2_real = v2 * (v1 - f1) / (u2 * f1) * 0.05f;
                            k2_imag = k2_real + u1 * (v2_cal - v2)/ (v1 * v2_cal) * 0.05f;
                        }
                        else
                                {
                            k2_imag = v2 * (v1 - f1) / (u2 * f1) * 0.05f;
                            k2_real = k2_imag - u1 * (v2 - v2_cal) / (v1 * v2_cal) * 0.05f;
                        }
                        clens_center = GameObject.Find("CLens").transform.position;
                        vlens_center = GameObject.Find("VLens").transform.position;
                        lit_center = transform.position;

                        imag.transform.localScale = new Vector3(k2_real, k2_real, 0.1f);
                        imag_s.transform.localScale = new Vector3(k2_imag, k2_imag, 0.1f);
                    }
                }
            }
        }
        else
        {
            imag.SetActive(false);
            imag_s.SetActive(false);
            imag_i.SetActive(false);
        }
    }
}