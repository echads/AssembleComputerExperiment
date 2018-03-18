using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    private enum state
    {
        BEGIN,
        VIEW,
        CHOICE,
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


    private void Awake()
    {
        Instance = this;
    }

    void update()
    {
        switch (currentstate)
        {
            case state.BEGIN:
                print("Begin...");
                OnBeginState();
                break;
            case state.CHOICE:
                print("Choice...");
                OnChoiceState();
                break;
            case state.VIEW:
                print("View...");
                OnViewState();
                break;
            case state.TEST:
                print("Test...");
                OnTestState();
                break;
            case state.GUIDEASSEMBLE:
                print("Guideassemble...");
                OnGuideassembleState();
                break;
            case state.MARK:
                print("Mark...");
                OnMarkState();
                break;
        }
        switch (curGuideassemblestate)
        {
            case Guideassemblestate.MAINBORADSTATE:
                //处于主板状态执行代码
                OnMarkState();
                break;
            case Guideassemblestate.SOURCESTATE:
                //处于电源设备状态执行的代码
                OnMainboardState();
                break;
            case Guideassemblestate.CHASSISSTATE:
                //处于机箱设备状态执行的代码
                OnSourceState();
                break;
            case Guideassemblestate.PERIPHERALSTATE:
                //处于外设状态执行的代码
                OnPeripheralState();
                break;




        }
    }

    public void OnBeginState()
    {   //开始状态执行的方法

        //更新当前状态
        currentstate = state.CHOICE;

    }
    //选择状态执行的方法
    public void OnChoiceState()
    {

    }
    //观看状态执行的方法
    public void OnViewState()
    {

    }
    //测试状态执行的方法
    public void OnTestState()
    {

    }
    //指导组装状态执行的方法
    public void OnGuideassembleState()
    { //指导电脑的安装，装错会报错
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
    //测试组装状态执行的方法
    public void OnMarkState()
    {

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
	
}
