using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUp : MonoBehaviour {

    /// <summary>
    /// 抓取物体到手柄动画
    /// </summary>
    /// <param name="obj"></param>
    public void PutObject(GameObject obj)
    {
        transform.DOMove(obj.transform.position, 2);
    }

    /// <summary>
    /// 移动到指定位置动画
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="destination"></param>
    public void MoveDestination(Transform destination)
    {
        transform.DOMove(destination.position, 2);

    }
}
