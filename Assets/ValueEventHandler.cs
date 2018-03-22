using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ValueEventHandler : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler,
    IDropHandler,
    IPointerHoverHandler
{
    [SerializeField]
    private Material green;
    [SerializeField]
    private Material red;
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.isColliter = false;
        if(this.name.Equals(GameManager.Instance.controller.name))
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            Debug3D.Instance.Debug(GameManager.Instance.infoname[GameManager.Instance.count]);
            if (GameManager.Instance.isGuide)
            {
                if (this.name.Equals(GameManager.Instance.infoname[GameManager.Instance.count]))
                { 
                    this.GetComponent<MeshRenderer>().material = green;
                 }
               else
                 {
                    this.GetComponent<MeshRenderer>().material = red;
                 }
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = green;
            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            if (GameManager.Instance.isGuide)
            {
                this.GetComponent<MeshRenderer>().material = red;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = green ;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.isColliter = true;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void OnPointerHover(PointerEventData eventData)
    {
      
       if (WaveVR_Controller.Input(wvr.WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressUp(wvr.WVR_InputId.WVR_InputId_Alias1_Bumper))
        {
            //Debug3D.Instance.Debug("FailName:");
            if (this.name.Equals(GameManager.Instance.controller.name))
            {
                GameManager.Instance.MoveDestination(this.gameObject);
                GameManager.Instance.LeaveParent();
                GameManager.Instance.SetInfo();
            }
            else
            {
                SourceManager.Instance.PlayError();
                GameManager.Instance.MoveDestination(PositionManager.Instance.GetInital(GameManager.Instance.controller));
                GameManager.Instance.LeaveParent();
                GameManager.Instance.controller = null;
                if(GameManager.Instance.isGuide)
                {
                    GameManager.Instance.setscore(5);
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + other.gameObject.layer);
        if (other.gameObject.layer==10)
        {
            GameManager.Instance.SetModelPositionActive(other.gameObject, true);
            GameManager.Instance.controller.SetActive(false);
            GameManager.Instance.controller = null;
        }
    }
}
