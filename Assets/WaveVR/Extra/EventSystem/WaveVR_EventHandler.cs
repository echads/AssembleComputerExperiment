﻿// "WaveVR SDK 
// © 2017 HTC Corporation. All Rights Reserved.
//
// Unless otherwise required by copyright law and practice,
// upon the execution of HTC SDK license agreement,
// HTC grants you access to and use of the WaveVR SDK(s).
// You shall fully comply with all of HTC’s SDK license agreement terms and
// conditions signed by you and all SDK and API requirements,
// specifications, and documentation provided by HTC to You."

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WaveVR_Log;
using wvr;

public class WaveVR_EventHandler : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler,
    IDropHandler,
    IPointerHoverHandler
{
    private const string LOG_TAG = "WaveVR_EventHandler";
    private WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
    private Vector3 goPosition;
    private float goPositionZ;

    public GameObject img;

    private GameObject InstallPosition;

    private void TeleportRandomly()
    {
        Vector3 direction = UnityEngine.Random.onUnitSphere;
        direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
        direction.z = Mathf.Clamp(direction.z, 3f, 10f);
        float distance = 2 * UnityEngine.Random.value + 1.5f;
        transform.localPosition = direction * distance;
    }

    private void Rotate()
    {
        transform.Rotate(72 * (10 * Time.deltaTime), 0, 0);
        transform.Rotate(0, 72 * (10 * Time.deltaTime), 0);
    }

    #region override event handling function
    public void OnPointerEnter(PointerEventData eventData)
    {
        //#if UNITY_EDITOR
        //Debug.Log("OnPointerEnter, camera: " + eventData.enterEventCamera);
        //#endif
        //Log.d (LOG_TAG, "OnPointerEnter, camera: " + eventData.enterEventCamera);
        Debug3D.Instance.Debug("显示");
        img.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Do nothing
        Debug3D.Instance.Debug("不现实");
        img.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //#if UNITY_EDITOR
        //Debug.Log("WaveVR_EventHandler::OnPointerDown");
        //#endif
        //Rotate ();
    }
    // Called when the pointer enters our GUI component.
    // Start tracking the mouse
    public void OnBeginDrag(PointerEventData eventData)
    {
        //goPosition = transform.position;
        //goPositionZ = transform.position.z;

        //#if UNITY_EDITOR
        //Debug.Log("WaveVR_EventHandler::OnBeginDrag, position: " + goPosition);
        //#endif
        //Log.d (LOG_TAG, "OnBeginDrag() position: " + goPosition);

        //StartCoroutine( "TrackPointer" );
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Camera _cam = eventData.enterEventCamera;
        //goPosition = _cam.ScreenToWorldPoint (new Vector3 (eventData.position.x, eventData.position.y, goPositionZ));
        //Log.d (LOG_TAG, "OnDrag() camera: " + c + ", position: " + goPosition);
    }

    // Called when the pointer exits our GUI component.
    // Stop tracking the mouse
    public void OnEndDrag(PointerEventData eventData)
    {
        //#if UNITY_EDITOR
        //Debug.Log("WaveVR_EventHandler::OnEndDrag, position: " + goPosition);
        //#endif
        //Log.d (LOG_TAG, "OnEndDrag() position: " + goPosition);

        //StopCoroutine( "TrackPointer" );
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Camera c = eventData.enterEventCamera;
        //goPosition = c.ScreenToWorldPoint (new Vector3 (eventData.position.x, eventData.position.y, goPositionZ));

        //#if UNITY_EDITOR
        //Debug.Log("WaveVR_EventHandler::OnDrop, position: " + goPosition);
        //#endif
    }

    public void OnPointerHover(PointerEventData eventData)
    {



        if (GameManager.Instance.controller == null)
        {

            if (GameManager.Instance.GetCurrentstate().Equals("MARK"))
            {
                Debug3D.Instance.Debug("mark"+this.gameObject.name);
                if (WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Bumper)&&this.gameObject.layer==4)
                {
                    Debug3D.Instance.Debug("开始捡去物体");
                    GameManager.Instance.PutObject(this.gameObject);
                    //GameManager.Instance.SetColliderEnableFalse(this.gameObject);
                    GameManager.Instance.BecomeChild(this.gameObject);
                    if (this.gameObject.name.Equals(GameManager.Instance.curGuideassemblestate.ToString()))
                    {
                        if(this.gameObject.name=="jiban")
                        {
                            SourceManager.Instance.PlayTrue();
                            LogicManager.Instance.SetComponents("jiban", false);
                            LogicManager.Instance.Setposition("jiban", true);
                            LogicManager.Instance.SetValueColor("jiban", 1, false);
                            //GameManager.Instance.SetcurGuideassemblestate("jiban");
                            GameManager.Instance.controller = null;
                        }

                        LogicManager.Instance.SetValueColor(this.gameObject.name, 0, true);
                    }
                    else
                    {
                        SourceManager.Instance.PlayError();
                        LogicManager.Instance.SetValueColor(this.gameObject.name, 2, true);
                    }
                }
            }
        }



        if (GameManager.Instance.controller != null)
        {
            Debug3D.Instance.Debug("kaishimark+:"+this.name);
            if (GameManager.Instance.GetCurrentstate().Equals("MARK"))
            {
                Debug3D.Instance.Debug("jiaixngmark:"+this.name);
                if(this.gameObject.layer==1)
                {
                    GameManager.Instance.isColliter = false;
                    Debug3D.Instance.Debug("开始move"+this.name);
                    if(WaveVR_Controller.Input(WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressUp(WVR_InputId.WVR_InputId_Alias1_Bumper))
                        if(this.gameObject.name.Equals(GameManager.Instance.curGuideassemblestate.ToString()))
                        {
                            GameManager.Instance.MoveDestination(this.gameObject);
                            GameManager.Instance.LeaveParent();
                          //  GameManager.Instance.SetColliderEnableTrue();
                            GameManager.Instance.controller = null;
                        }
                }
            }
        }
        GameManager.Instance.isColliter = true;


    }
    #endregion

    IEnumerator TrackPointer()
    {
        while (true)
        {
            yield return waitForEndOfFrame;

            transform.position = goPosition;
        }
    }
    
}