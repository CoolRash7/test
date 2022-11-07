using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSimple : MonoBehaviour
{

    public float speed = 10;

    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(0, 0, -speed * Time.deltaTime);
        if (transform.position.z >= -3.79f) transform.position  = new Vector3(transform.position.x, transform.position.y, -16.33f);
    }
}
