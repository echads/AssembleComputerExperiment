using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestEcentHandler : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler,
    IDropHandler,
    IPointerHoverHandler
{
    private WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
    //开始时颜色
    [SerializeField]
    private Material blue;
    //选中时颜色
    [SerializeField]
    private Material green;
    //圆桶内的模型
    [SerializeField]
    private GameObject gameObjectSelf;
    #region override event handling function
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.gameObject.GetComponent<MeshRenderer>().material = green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<MeshRenderer>().material = blue;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }
    /// <summary>
    /// 如果射线进入并且按下bumper将物体拿回手中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerHover(PointerEventData eventData)
    {
        if (WaveVR_Controller.Input(wvr.WVR_DeviceType.WVR_DeviceType_Controller_Right).GetPressDown(wvr.WVR_InputId.WVR_InputId_Alias1_Bumper))
        {
            if (GameManager.Instance.controller == null)
            {
                GameManager.Instance.PutObject(gameObjectSelf);
                GameManager.Instance.BecomeChild(gameObjectSelf);
                GameManager.Instance.controller = gameObjectSelf;
            }
        }
    }
    #endregion
}
