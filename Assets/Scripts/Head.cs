using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {

    public Transform head;

    void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(0, head.localEulerAngles.y, 0);
        transform.localPosition = new Vector3(head.localPosition.x, 0, head.localPosition.z);
    }
}
