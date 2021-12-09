using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class enter_check : MonoBehaviour
{
    // public int flag_ConvexLens = 0;
    // public int flag_ConcaveLens = 0;
    // public int flag_Screen = 0;
    public GameObject WA_dialog;
    public int flag1 = 0;
    // flag1 = 0 ： 第一个实验尚未开始，不能拖动物品
    // flag1 = 1 ： 第一个实验正在进行，可以拖动物品
    // flag1 = 2 ： 第二个实验尚未开始（正在进行物品选择），不能拖动物品
    // flag1 = 3 ： 第二个实验正在进行，可以拖动物品
    public GameObject ConvexLens;
    public GameObject ConcaveLens;
    public GameObject Screen;
    public GameObject Dialog;
    public GameObject Button;
    private GameObject Lit;
    private RayTracing OurRay;
    // Start is called before the first frame update
    
    

    
    void Start()
    {
        Lit = GameObject.Find("Omni002");
        OurRay = Lit.GetComponent("RayTracing") as RayTracing;
    }

    // Update is called once per frame
 
    public void click()
    {   
        // 实验1
        if(flag1 == 0)
        {
            if((ConvexLens.activeSelf == true) && (ConcaveLens.activeSelf == false) && (Screen.activeSelf == true))
            {
                // 关闭道具选择按钮，避免重复选择
                //Button.GetComponent<CanvasGroup>().alpha = 0;
                Dialog.GetComponent<CanvasGroup>().alpha = 0;
                //Button.SetActive(false);
                //Dialog.SetActive(false);
                flag1 = 1;// 第一个实验正在进行，可以拖动物品
                //开灯 模式1
                OurRay.type = 1;
                OurRay.check_fst = true;
                OurRay.LightEnable = true;
            }
 
            else
            {
                //弹出对话框，提示重选
                WA_dialog.SetActive(true); 
            }
        }
        // 实验2
        else
        {
            flag1 = 2;// 第二个实验尚未开始（正在进行物品选择），不能拖动物品
            if ((ConvexLens.activeSelf == true) && (ConcaveLens.activeSelf == true) && (Screen.activeSelf == true) && OurRay.check_fst)
            {
                flag1 = 3;// 第二个实验正在进行，可以拖动物品
                //开灯 模式2

                // 位置初始化的代码我在button_next脚本里也复制了一份，不确定这里是否还需要
                ConvexLens.transform.position = OurRay.vlens_initpos;
                ConcaveLens.transform.position = OurRay.clens_initpos;
                Screen.transform.position = OurRay.screen_initpos;
                OurRay.type = 2;
                OurRay.LightEnable = true;

                // 关闭道具选择按钮，避免重复选择
                //Button.GetComponent<CanvasGroup>().alpha = 0;
                Dialog.GetComponent<CanvasGroup>().alpha = 0;
                //Button.SetActive(false);
                //Button.SetActive(false);
                //Dialog.SetActive(false);
            }
            else
            {
                //弹出对话框，提示重选
                WA_dialog.SetActive(true); 
            }
        }
        

        
    }
}
