using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportController : MonoBehaviour {
    public Transform BT;

	public void Move(GameObject obj)
    {
        obj.transform.DOMove(BT.position, 2);
    }

    /// <summary>
    /// 移动到指定位置动画
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="destination"></param>
    public void MoveDestination(GameManager obj, Transform destination)
    {
        obj.transform.DOMove(destination.position, 2);

    }
}
