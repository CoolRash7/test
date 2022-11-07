using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTrucks : MonoBehaviour
{

    public GameObject truck;
    public int currentTruck = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (currentTruck < Globals.rpg.world_truck.level)
        {
            Instantiate(truck, transform.position + new Vector3(currentTruck * 5, 0, 0), Quaternion.identity);
            currentTruck++;
        }
    }
}
