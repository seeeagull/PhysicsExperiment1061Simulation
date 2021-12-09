using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_next : MonoBehaviour
{
    public GameObject WA_dialog;
    public GameObject ConvexLens;
    public GameObject ConcaveLens;
    public GameObject Screen;
    public GameObject Dialog;
    public GameObject Button_selection;
    public GameObject Button_next;
    public GameObject Button_enter;
    private GameObject Lit;
    private RayTracing OurRay;
//    public int flag1;

    // Start is called before the first frame update
    void Start() 
    {
        Lit = GameObject.Find("Omni002");
        OurRay = Lit.GetComponent("RayTracing") as RayTracing;
        ConvexLens.SetActive(false);
        ConcaveLens.SetActive(false);
        Screen.SetActive(false);
    }

    // Update is called once per frame
    public void click()
    {
        // 修改flag1，防止物品被拖动
        Button_enter.gameObject.GetComponent<enter_check>().flag1 = 2;
        // 将物品移动到合适的位置，并初始化为false
        ConvexLens.transform.position = OurRay.vlens_initpos;
        ConcaveLens.transform.position = OurRay.clens_initpos;
        Screen.transform.position = OurRay.screen_initpos;
        ConvexLens.SetActive(false);
        ConcaveLens.SetActive(false);
        Screen.SetActive(false);
        // 按钮初始化
        Button_selection.SetActive(true);
        Dialog.SetActive(false);
        Button_next.SetActive(false);

        //下面一段代码实现实验二的初始化  可以根据情况剪切到新按钮脚本中
        // if ((ConvexLens.activeSelf == true) && (ConcaveLens.activeSelf == true) && (Screen.activeSelf == true) && OurRay.check_fst)
        // {
        //     //开灯 模式2
        //     ConvexLens.transform.position = OurRay.vlens_initpos;
        //     ConcaveLens.transform.position = OurRay.clens_initpos;
        //     Screen.transform.position = OurRay.screen_initpos;
        //     OurRay.type = 2;
        //     OurRay.LightEnable = true;

        // }
        // else
        // {
        //     //弹出对话框，提示重选
        //     WA_dialog.SetActive(true); 
        // }
    }
}
