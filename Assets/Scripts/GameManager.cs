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
    public GameObject markmenu;
    public GameObject Scoremenu;
    public GameObject parents;
    public Image info;
    public Sprite[] infoSprite;
    public GameObject controller=null;
    public GameObject studyGameObject;
    public GameObject guideGameObject;

    public GameObject sprite;
    public GameObject WaveVR;
    public GameObject Initial;
    public GameObject Study;
    public GameObject Guide;
    public bool isController=false;
    public GameObject zhuban;
    public GameObject jixiang;

    public GameObject mainUI;

    public GameObject bg;
    public enum state
    {
        BEGIN,
        VIEW,
        CHOICE,
        STUDY,
        TEST,
        GUIDEASSEMBLE,
        MARK,
        Score,
    }
    public enum Guideassemblestate
    {
        cpu,
        neicuntiao,
        xianka,
        zhuban,
        dianyuan,
        yingpan,
        jiban,
        jixiang,
        xianshi
    }


    public static GameManager Instance { get; set; }
    public state currentstate;
    public Guideassemblestate curGuideassemblestate;
    public bool isMAINBORADSTATE;//是否是主板状态

    public GameObject BT;

    public bool isColliter=true;
    
    private void Awake()
    {
        Instance = this;
        sprite.SetActive(true);
        WaveVR.transform.position = Initial.transform.position;
        zhuban.gameObject.layer = 3;
        jixiang.gameObject.layer = 5;
        //LogicManager.Instance.Setposition("xianka", true);
        studyGameObject.SetActive(false);
        guideGameObject.SetActive(false);
       
    }
    
    private void Update()
    {
        if(WaveVR_Controller.Input(wvr.WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressUp(wvr.WVR_InputId.WVR_InputId_Alias1_Bumper)&& controller != null&& isColliter)
        {

            Debug3D.Instance.Debug(controller.name + "moveinital");
            MoveDestination(PositionManager.Instance.GetInital(controller));
            Debug3D.Instance.Debug(controller.name + "setvalurcolor");
            LogicManager.Instance.SetValueColor(controller.name, 1, false);
            Debug3D.Instance.Debug(controller.name + "set");
            SetColliderEnableTrue();
            controller = null;
            //SetColliderEnableTrue();
            //if(currentstate==state.GUIDEASSEMBLE)
            //{
            //    LogicManager.Instance.SetValueColor(controller.name, 0, false);
            //}
            //controller = null;
        }
        if (currentstate.ToString().Equals("MARK") && WaveVR_Controller.Input(wvr.WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressDown(wvr.WVR_InputId.WVR_InputId_Alias1_Touchpad))
        {
            mainUI.SetActive(!mainUI.activeSelf);
        }
    }

    /// <summary>
    /// 更新撞击状态
    /// </summary>
    /// <param name="name"></param>
    public void SetcurGuideassemblestate(string name)
    {
        if(name=="cpu")
        {
            bg.SetActive(false);
            curGuideassemblestate = Guideassemblestate.neicuntiao;
            info.sprite = infoSprite[2];
        }
        else if(name == "neicuntiao")
        {
            curGuideassemblestate = Guideassemblestate.xianka;
            info.sprite = infoSprite[4];
        }
        else if(name == "xianka")
        {
            curGuideassemblestate = Guideassemblestate.zhuban;
            info.sprite = infoSprite[1];
            zhuban.gameObject.layer=4;
           // jixiang.gameObject.layer = 3;
            
        }
        else if(name == "zhuban")
        {
            curGuideassemblestate = Guideassemblestate.dianyuan;
            info.sprite = infoSprite[3];
        }
        else if(name == "dianyuan")
        {
            curGuideassemblestate = Guideassemblestate.yingpan;
            info.sprite = infoSprite[6];
        }
        else if(name == "yingpan")
        {
            curGuideassemblestate = Guideassemblestate.jiban;
            info.sprite = infoSprite[8];
        }
        else if(name == "jiban")
        {
            curGuideassemblestate = Guideassemblestate.jixiang;
            info.sprite = infoSprite[5];
            mainUI.SetActive(true);
            SourceManager.Instance.PlayFinish();
            //jixiang.gameObject.layer = 4;
        }
        else if(name == "jixiang")
        {
            curGuideassemblestate = Guideassemblestate.xianshi;
            info.sprite = infoSprite[5];
        }
    }


    public string GetCurrentstate()
    {
        return currentstate.ToString();
    }


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
        sprite.SetActive(false);


        currentstate = state.CHOICE;
        mainmenu.SetActive(true);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        testmenu.SetActive(false);
        //guidemenu.SetActive(false);
        markmenu.SetActive(false);
        //Scoremenu.SetActive(false);
        WaveVR.transform.position = Initial.transform.position;
        guideGameObject.SetActive(false);
        studyGameObject.SetActive(false);
    }
    /// <summary>
    /// 进入学习状态
    /// </summary>
    public void OnStudy()
    {
        sprite.SetActive(false);
        currentstate = state.STUDY;
        mainmenu.SetActive(false);
        studymenu.SetActive(true);
        viewmenu.SetActive(false);
        testmenu.SetActive(false);
        //guidemenu.SetActive(false);
        markmenu.SetActive(false);
        //Scoremenu.SetActive(false);

       

    }
    /// <summary>
    /// 进入观看状态
    /// </summary>
    public void OnViewState()
    {
        sprite.SetActive(false);
        currentstate = state.VIEW;
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(true);
        testmenu.SetActive(false);
        //guidemenu.SetActive(false);
        markmenu.SetActive(false);
        //Scoremenu.SetActive(false);
        WaveVR.transform.position = Study.transform.position;
        studyGameObject.SetActive(true);
    }


    //}
    /// <summary>
    /// 进入测试状态
    /// </summary>
    public void OnTestState()
    {
        sprite.SetActive(false);
        currentstate = state.TEST;
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        testmenu.SetActive(true);
        //guidemenu.SetActive(false);
        markmenu.SetActive(false);
       // Scoremenu.SetActive(false);

    }

   
   /// <summary>
   /// 进入测试组装状态
   /// </summary>
    public void OnMarkState()
    {
        sprite.SetActive(false);
        currentstate = state.MARK;
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        testmenu.SetActive(false);
        //guidemenu.SetActive(false);
        markmenu.SetActive(true);
        //Scoremenu.SetActive(false);
        WaveVR.transform.position = Guide.transform.position;

        guideGameObject.SetActive(true);

        curGuideassemblestate = Guideassemblestate.cpu;

        PositionManager.Instance.SetInitalAll();


        bg.SetActive(true);

        mainUI.SetActive(false);




    }




    //主板状态执行的方法
    public void OnMainboardState(int index)
    {
       
       

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
    public void PutObject(GameObject obj)
    {
        obj.transform.DOMove(BT.transform.position, 2);
    }
    
    /// <summary>
    /// 移动到指定位置动画
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="destination"></param>
    public void MoveDestination(GameObject obj)
    {
        controller.transform.DOMove(obj.transform.position, 2);

    }


    public void BecomeChild(GameObject obj)
    {
        obj.transform.parent = BT.transform;
        obj.transform.parent.rotation = BT.transform.rotation;
    }
    public void LeaveParent()
    {
        if(controller!=null)
            controller.transform.parent = parents.transform;
    }

    /// <summary>
    /// 关闭Collider
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="index"></param>
    public void SetColliderEnableFalse(GameObject obj)
    {
        if (controller == null)
        {
            Debug3D.Instance.Debug(obj.name + "开始减去mesh");
            obj.GetComponent<Collider>().enabled = false;
            Debug3D.Instance.Debug(obj.name + "开始减去ganti");
            obj.GetComponent<Rigidbody>().useGravity = false;
            controller = obj;
            Debug3D.Instance.Debug(controller.name + "关闭");
        }
    }
    /// <summary>
    /// 开启
    /// </summary>
    public void SetColliderEnableTrue()
    {
        if (controller != null)
        {
            Debug3D.Instance.Debug(controller.name + "Begin");
            try
            {
                controller.GetComponent<Collider>().enabled = true;
                controller.GetComponent<Rigidbody>().useGravity = false;
            }
            catch
            {
            }
            LeaveParent();
            Debug3D.Instance.Debug(controller.name + "开始离开" + controller.GetComponentInParent<Transform>().name);
        }
    }

}
