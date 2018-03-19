using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public GameObject mainmenu;
    public GameObject studymenu;
    public GameObject viewmenu;
    public GameObject guidemenu;
    public GameObject testmenu;
    public Image info;
    public Sprite[] infoSprite;
    private enum state
    {
        BEGIN,
        VIEW,
        CHOICE,
        STUDY,
        TEST,
        GUIDEASSEMBLE,
        MARK
    }
    private enum Guideassemblestate
    {
        MAINBORADSTATE,
        SOURCESTATE,
        CHASSISSTATE,
        PERIPHERALSTATE,
    }


    public static GameManager Instance { get; set; }
    private state currentstate;
    private Guideassemblestate curGuideassemblestate;
    public bool isMAINBORADSTATE;//是否是主板状态

    public GameManager BT;

    
    private void Awake()
    {
        Instance = this;
    }

    //void Update()
    //{
    //    switch (currentstate)
    //    {
    //        case state.BEGIN:
    //            print("Begin...");
    //            OnBeginState();
    //            break;
    //        case state.CHOICE:
    //            print("Choice...");
    //            OnChoiceState();
    //            break;
    //        case state.VIEW:
    //            print("View...");
    //            OnViewState();
    //            break;
    //        case state.TEST:
    //            print("Test...");
    //            OnTestState();
    //            break;
    //        case state.GUIDEASSEMBLE:
    //            print("Guideassemble...");
    //            OnGuideassembleState();
    //            break;
    //        case state.MARK:
    //            print("Mark...");
    //            OnMarkState();
    //            break;
    //    }
    //    switch (curGuideassemblestate)
    //    {
    //        case Guideassemblestate.MAINBORADSTATE:
    //            //处于主板状态执行代码
    //            OnMarkState();
    //            break;
    //        case Guideassemblestate.SOURCESTATE:
    //            //处于电源设备状态执行的代码
    //            OnMainboardState();
    //            break;
    //        case Guideassemblestate.CHASSISSTATE:
    //            //处于机箱设备状态执行的代码
    //            OnSourceState();
    //            break;
    //        case Guideassemblestate.PERIPHERALSTATE:
    //            //处于外设状态执行的代码
    //            OnPeripheralState();
    //            break;




    //    }
    //}
    /// <summary>
    /// 进入开始状态
    /// </summary>
    public void OnBeginState()
    {   //开始状态执行的方法
        currentstate = state.BEGIN;

        //更新当前状态
        currentstate = state.CHOICE;

    }
    /// <summary>
    /// 进入选择状态
    /// </summary>
    public void OnChoiceState()
    {
        currentstate = state.CHOICE;
        

    }
    public void OnStudy()
    {
        currentstate = state.STUDY;
        mainmenu.SetActive(false);
        studymenu.SetActive(true);
        viewmenu.SetActive(false);
        testmenu.SetActive(false);
        guidemenu.SetActive(false);
    }
    /// <summary>
    /// 进入观看状态
    /// </summary>
    public void OnViewState()
    {
        currentstate = state.VIEW;
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(true);
        testmenu.SetActive(false);
        guidemenu.SetActive(false);
    }
    /// <summary>
    /// 进入测试状态
    /// </summary>
    public void OnTestState()
    {
        currentstate = state.TEST;
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        testmenu.SetActive(true);
        guidemenu.SetActive(false);

    }

    /// <summary>
    /// 进入指导组装状态
    /// </summary>
    public void OnGuideassembleState()
    { //指导电脑的安装，装错会报错
        currentstate = state.GUIDEASSEMBLE;
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        testmenu.SetActive(false);
        guidemenu.SetActive(true);



        if (isMAINBORADSTATE)
        {
            //安装CPU，内存，显卡
            OnMainboardState();

        }
        else
        {

            Debug.Log("发生错误");
        }


    }
   /// <summary>
   /// 进入测试组装状态
   /// </summary>
    public void OnMarkState()
    {
        currentstate = state.MARK;
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        testmenu.SetActive(true);
        guidemenu.SetActive(false);

    }




    //主板状态执行的方法
    public void OnMainboardState()
    {
        //安装cpu 内存条，显卡

    }

    //电源状态执行的方法
    public void OnSourceState()
    {

    }

    //机箱状态执行的方法
    public void OnChassisState()
    {

    }


    //主外设状态执行的方法
    public void OnPeripheralState()
    {

    }

    /// <summary>
    /// 抓取物体到手柄动画
    /// </summary>
    /// <param name="obj"></param>
    //public void PutObject(GameObject obj)
    //{
    //    obj.transform.DOMove(BT.transform.position, 2);
    //}

    /// <summary>
    /// 移动到指定位置动画
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="destination"></param>
    //public void MoveDestination(GameManager obj, Transform destination)
    //{
    //    obj.transform.DOMove(destination.position, 2);
        
    //}

}
