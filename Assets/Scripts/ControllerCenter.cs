using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;
using WaveVR_Log;

public class ControllerCenter : MonoBehaviour
{
    public WVR_DeviceType device = WVR_DeviceType.WVR_DeviceType_HMD;

    public Transform player;
    public Transform dic;
    public float speed = 1;


    // private WaveVR_Reticle rp;

    private void Update()
    {
        if (WaveVR_Controller.Input(wvr.WVR_DeviceType.WVR_DeviceType_Controller_Right).GetTouch(wvr.WVR_InputId.WVR_InputId_Alias1_Touchpad))
        {
            var axis = WaveVR_Controller.Input(device).GetAxis(WVR_InputId.WVR_InputId_Alias1_Touchpad);
            float angle = VectorAngle(new Vector2(1, 0), axis);

            //上
            if (angle < -45 && angle > -135)
            {
                player.Translate(dic.forward * Time.deltaTime * speed);
                //transform.Translate(transform.forward * Time.deltaTime * speed);
            }
            //下
            else if (angle > 45 && angle < 135)
            {
                player.Translate(-dic.forward * Time.deltaTime * speed);
                //transform.Translate(-transform.forward * Time.deltaTime * speed);
            }
            //左
            else if ((angle < 180 && angle > 135) || (angle < -135 && angle > -180))
            {
                player.Translate(-dic.right * Time.deltaTime * speed);
                //transform.Translate(-transform.forward * Time.deltaTime * speed);
            }
            //右
            else if ((angle > 0 && angle < 45) || (angle < 0 && angle > -45))
            {
                player.Translate(dic.right * Time.deltaTime * speed);
                //transform.Translate(transform.forward * Time.deltaTime * speed);
            }
        }
    }



    private void HandleConnectionStatus(bool _value)
    {
        Debug.Log(device + " is " + (_value ? "connected" : "disconnected"));
    }
    private void HandlePressDownMenu()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Menu + " press down");
    }

    private void HandlePressUpMenu()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Menu + " press up");
    }

    private void HandlePressDownGrip()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Grip + " press down");
    }

    private void HandlePressUpGrip()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Grip + " press up");
    }

    private void HandlePressDownTouchpad()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Touchpad + " press down" + WaveVR_ControllerListener.Instance.Input(device).GetAxis());

    }

    private void HandlePressUpTouchpad()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Touchpad + " press up");


    }
    private void HandlePressDownTrigger()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Trigger + " press down");
    }

    private void HandlePressUpTrigger()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Trigger + " press up");
    }



    private void HandleTouchUpTouchpad()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Touchpad + " touch up");


    }

    private void HandleTouchDownTouchpad()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Touchpad + " touch down");
        
    }

    private void HandleTouchDownTrigger()
    {
        // Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Trigger + " touch down");
    }

    private void HandleTouchUpTrigger()
    {
        //Debug3D.Instance.Debug(WVR_InputId.WVR_InputId_Alias1_Trigger + " touch up");
    }

    //private void HandlePressDownBumper()
    //{

    //}

    //private void HandlePressUpBumper()
    //{

    //}


    float VectorAngle(Vector2 from, Vector2 to)
    {
        float angle;
        Vector3 cross = Vector3.Cross(from, to);
        angle = Vector2.Angle(from, to);
        return cross.z > 0 ? -angle : angle;
    }

    void Start()
    {
        Debug.Log("Start");
        // Debug3D.Instance.Debug("Start");
        OnEnable();
    }

    private void OnEnable()
    {


        var _ctrllsn = WaveVR_ControllerListener.Instance;
        _ctrllsn.Input(device).ConnectionStatusListeners += HandleConnectionStatus;
        _ctrllsn.Input(device).PressDownListenersMenu += HandlePressDownMenu;
        _ctrllsn.Input(device).PressDownListenersGrip += HandlePressDownGrip;
        _ctrllsn.Input(device).PressDownListenersTouchpad += HandlePressDownTouchpad;
        _ctrllsn.Input(device).PressDownListenersTrigger += HandlePressDownTrigger;
        _ctrllsn.Input(device).PressUpListenersMenu += HandlePressUpMenu;
        _ctrllsn.Input(device).PressUpListenersGrip += HandlePressUpGrip;
        _ctrllsn.Input(device).PressUpListenersTouchpad += HandlePressUpTouchpad;
        _ctrllsn.Input(device).PressUpListenersTrigger += HandlePressUpTrigger;
        _ctrllsn.Input(device).TouchDownListenersTouchpad += HandleTouchDownTouchpad;
        _ctrllsn.Input(device).TouchDownListenersTrigger += HandleTouchDownTrigger;
        _ctrllsn.Input(device).TouchUpListenersTouchpad += HandleTouchUpTouchpad;
        _ctrllsn.Input(device).TouchUpListenersTrigger += HandleTouchUpTrigger;

    }
}

