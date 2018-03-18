using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug3D : MonoBehaviour {
    public static Debug3D Instance { set; get; }
    private void Awake()
    {
        Instance = this;
    }
    public void Debug(string index)
    {
        this.GetComponent<TextMesh>().text = index;
    }
}
