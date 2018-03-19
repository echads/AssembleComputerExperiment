using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportController : MonoBehaviour {

	public void Move(Transform controller)
    {
        transform.DOMove(controller.position, 2);
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
