using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatationSelf : MonoBehaviour {
    public float index;
	// Update is called once per frame
	void Update () {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + index, this.transform.eulerAngles.z);
	}
}
