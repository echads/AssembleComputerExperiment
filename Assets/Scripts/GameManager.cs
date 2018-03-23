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
    public GameObject Scoremenu;
    public GameObject parents;
    public Image info;
    public int count=0;
    public Sprite[] infoSprite;
    public ArrayList infoname = new ArrayList();
    public GameObject controller=null;
    public GameObject[] modelPosition;
    public GameObject sprite;
    public GameObject WaveVR;
    public GameObject Initial;
    public GameObject Study;
    public GameObject Test;
    public GameObject bg;
    public int score=100;
    public bool isGuide;
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
    public GameObject BT;
    public bool isColliter=true;
    public GameObject _zhuban;
    public bool isZhuban;
    public Text scoreui;
    private void Start()
    {
        Instance = this;
        sprite.SetActive(true);
        WaveVR.transform.position = Initial.transform.position;
        isZhuban = true;
        infoname.Add("cpu");
        infoname.Add("neicuntiao");
        infoname.Add("xianka");
        infoname.Add("zhuban");
        infoname.Add("yingpan");
        infoname.Add("dianyuan");



        //test
        //PositionManager.Instance.SetInitalAll();

    }
    private void Update()
    {
        if(WaveVR_Controller.Input(wvr.WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressUp(wvr.WVR_InputId.WVR_InputId_Alias1_Bumper)&& controller != null&& isColliter)
        {
            MoveDestination(PositionManager.Instance.GetInital(controller));
            LeaveParent();

            controller = null;
        }
        if (modelPosition[0].activeSelf && modelPosition[1].activeSelf && modelPosition[2].activeSelf)
        {
            
            isZhuban = false;
            _zhuban.SetActive(true);
        }
    }
    

    public void setscore(int index)
    {
        scoreui.text = (score -= index).ToString();
        if(score <=0)
        {
            scoreui.text = "0";
        }
    }

    public void SetInfo()
    {
        count++;
        info.sprite = infoSprite[count];
  
        if(count==3)
        {
            isZhuban = false;
        }
    }

    /// <summary>
    /// 获取状态
    /// </summary>
    /// <returns>string</returns>
    public string GetCurrentstate()
    {
        return currentstate.ToString();
    }
    public void SetModelPositionActive(GameObject gameObject,bool index)
    {
        foreach(GameObject child in modelPosition)
        {
            if (child.name.Equals(gameObject.name + "_position"))
            {
                Debug.Log("开始进入");
                child.SetActive(index);
            }
        }
    }

    //////////////////////////-------------------UI部分------------------------------\\\\\\\\\\\\\\\\\\
    /// <summary>
    /// 进入mainMenuh界面
    /// </summary>
    public void  GomainMenu()
    {
        mainmenu.SetActive(true);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        guidemenu.SetActive(false);
        Scoremenu.SetActive(false);
        Study.SetActive(false);
        Test.SetActive(false);
    }
    public void GostudyMenu()
    {
        mainmenu.SetActive(false);
        studymenu.SetActive(true);
        viewmenu.SetActive(false);
        guidemenu.SetActive(false);
        Scoremenu.SetActive(false);
        Study.SetActive(false);
        Test.SetActive(false);
    }
    public void GoviewMenu()
    {
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(true);
        guidemenu.SetActive(false);
        Scoremenu.SetActive(false);
        Study.SetActive(true);
        Test.SetActive(false);
    }
    public void Goguidemenu()
    {
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        guidemenu.SetActive(true);
        Scoremenu.SetActive(false);
        Test.SetActive(true);
        isGuide = true;
        count = 0;
        _zhuban.SetActive(false);
        SourceManager.Instance.Playyindaochengxu();
        //初始化物体
        foreach(GameObject child in modelPosition)
        {
            child.SetActive(false);
        }
        info.sprite = infoSprite[count];
        PositionManager.Instance.SetInitalAll();

    }
    public void Goscoremenu()
    {
        mainmenu.SetActive(false);
        studymenu.SetActive(false);
        viewmenu.SetActive(false);
        guidemenu.SetActive(false);
        Scoremenu.SetActive(true);
        Test.SetActive(true);
        isGuide = false;
        _zhuban.SetActive(false);
        score = 100;
        scoreui.text = score.ToString();

        foreach (GameObject child in modelPosition)
        {
            child.SetActive(false);
        }
        count = 0;
        info.sprite = infoSprite[0];
        PositionManager.Instance.SetInitalAll();
    }
    //////////////////////-------------------------END-------------------\\\\\\\\\\\\\\\\\\\\\\\\\
    
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





}
