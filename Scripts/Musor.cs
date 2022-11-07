using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musor : MonoBehaviour
{
    public int ID;
    
    void Start()
    {
        ID = Globals.ID.Count;
        Globals.ID.Add(ID);
        Globals._musor tempMusor;
        tempMusor.isAlive = true;
        tempMusor.pos = transform.position;
        Globals.musor.Add(ID, tempMusor);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (!Globals.musor[ID].isAlive)
                Destroy(gameObject);
        } catch (System.Exception e)
        {

        }
    }
}
