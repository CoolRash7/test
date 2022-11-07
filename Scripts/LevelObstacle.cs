using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacle : MonoBehaviour
{
    public int level = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (Globals.level <= level)
            GameObject.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
