using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    [Header("Saw Speed")]
    public float speed = 10;
    public bool inverse = false;

    Rigidbody rb;
    float tempRotate =0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        tempRotate += speed * Time.deltaTime;
        if (tempRotate >= 360) tempRotate = 0;
        rb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x,  inverse ? tempRotate : -tempRotate, transform.rotation.eulerAngles.z));
        //transform.Rotate(0,0, !inverse ? speed: speed); 
    }

    void boxColliderKill(GameObject obj)
    {
        Component[] array;
        array = obj.transform.GetComponents(typeof(Collider));

        foreach (Collider tempCollider in array)
            tempCollider.isTrigger = true;
    }
}
