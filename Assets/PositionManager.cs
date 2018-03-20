using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour {
    public static PositionManager Instance { set; get; }


    public GameObject[] initalTransform;


    public GameObject[] gameObjects;

	// Use this for initialization
	void Start () {
        Instance = this;
        gameObjects[3].transform.DOMove(GetInital(gameObjects[3]).transform.position,1f);
        
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
    /// <summary>
    /// 设置所有初始位置
    /// </summary>
    public void SetInitalAll()
    {
        for(int i = 0; i < initalTransform.Length; i++)
        {
            gameObjects[i].transform.position = initalTransform[i].transform.position;
            gameObjects[i].transform.rotation = initalTransform[i].transform.rotation;
        }
    }
}
