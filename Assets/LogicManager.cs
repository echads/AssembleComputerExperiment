using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour {
    public static LogicManager Instance { set; get; }
    public Material[] materials;
    public GameObject[] components;
    public GameObject[] values;
    public GameObject[] positions;
    private void Awake()
    {
        Instance = this;
        foreach(GameObject gameObject in positions)
        {
            gameObject.SetActive(false);
        }

       // Setposition("xianka", true);
    }
    /// <summary>
    /// 设置Color
    /// </summary>
    /// <param name="index"></param>
    public void SetValueColor(string name,int index,bool active)
    {
        foreach(GameObject gameObject in values)
        {
            if(name==gameObject.name)
            {
                gameObject.GetComponent<MeshRenderer>().material = materials[index];
                gameObject.SetActive(active);
            }
        }
    }

    
    /// <summary>
    /// 设置Components
    /// </summary>
    /// <param name="name"></param>
    /// <param name="index"></param>
    public void SetComponents(string name,bool index)
    {
        foreach (GameObject gameObject in components)
        {
            if (name == gameObject.name)
            {
                gameObject.SetActive(index);
            }
        }
    }
    /// <summary>
    /// 设置position
    /// </summary>
    /// <param name="name"></param>
    /// <param name="index"></param>

    public void Setposition(string name,bool index)
    {
        foreach (GameObject gameObject in positions)
        {
            if (gameObject.name.Equals(name + "_position"))
            {
                gameObject.SetActive(index);
            }
        }
    }

    public GameObject GetPosition(string name)
    {
        foreach (GameObject gameObject in positions)
        {
            if (gameObject.name.Equals(name+"_position"))
            {
                return gameObject;
            }
        }
        return null;
    }

}
