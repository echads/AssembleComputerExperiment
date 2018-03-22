using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StudyEventHandler : MonoBehaviour,
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
    [SerializeField]
    private Material blue;
    [SerializeField]
    private Material green;
    [SerializeField]
    private GameObject img;
    #region override event handling function
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.gameObject.GetComponent<MeshRenderer>().material = green;
        img.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<MeshRenderer>().material = blue;
        img.SetActive(false);
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

    public void OnPointerHover(PointerEventData eventData)
    {
    }
    #endregion
}
