using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug3D.Instance.Debug(other.name);
        if(other.name.Equals(this.name))
        {
            SourceManager.Instance.PlayTrue();
            LogicManager.Instance.SetComponents(other.gameObject.name, false);
            LogicManager.Instance.Setposition(other.gameObject.name, true);
            LogicManager.Instance.SetValueColor(other.gameObject.name,0, false);
            GameManager.Instance.SetcurGuideassemblestate(this.name);
        }
        if(other.name.Equals("xianshi"))
        {
            SourceManager.Instance.PlayFinish();
        }
    }
}
