using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour {
    [SerializeField]
    private Sprite[] sprite;
    [SerializeField]
    private Image bai;
    [SerializeField]
    private Image shi;
    [SerializeField]
    private Image ge;
    public void chargeUI(int index)
    {
        if (index == 100)
        {
            bai.GetComponent<Image>().sprite = sprite[1];
            shi.GetComponent<Image>().sprite = sprite[0];
            ge.GetComponent<Image>().sprite = sprite[0];
        }

       else {
            bai.GetComponent<Image>().sprite = sprite[0];
            shi.GetComponent<Image>().sprite = sprite[index / 10];
            ge.GetComponent<Image>().sprite = sprite[index % 10];
            }
        }
}
