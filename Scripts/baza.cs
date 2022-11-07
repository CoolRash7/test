using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baza : MonoBehaviour
{
    [Range(0, 3)]
    public int bazaID;

    void Start()
    {
        Globals.baza[bazaID].pos =transform.position;
    }

    void Update()
    {
        
    }
}
