using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Slice"))
        {
            Globals.goEzySlice = true;
        }
    }

}
