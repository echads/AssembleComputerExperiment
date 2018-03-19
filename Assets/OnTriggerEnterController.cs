using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals(this.name))
        {
            LogicManager.Instance.SetComponents(other.gameObject.name, false);
            LogicManager.Instance.Setposition(other.gameObject.name, true);
            LogicManager.Instance.SetValueColor(other.gameObject.name,0, false);
        }
    }
}
