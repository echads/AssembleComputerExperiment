using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour {
    public static PositionManager Instance { set; get; }


    public GameObject[] initalTransform;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 初始化gameobject位置
    /// </summary>
    /// <param name="gameObject"></param>
    public GameObject GetInital(GameObject gameObject)
    {
        foreach(GameObject child in initalTransform)
        {
            if(child.name.Equals(gameObject.name+ " (1)"))
            {
                return child;
            }
        }
        return null;
    }
}
