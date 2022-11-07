using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    
    public Globals.GATGETTYPE type;
    Rigidbody rb;

    private void Update()
    {
        if (transform.position.y < -5 || transform.position.z >= 18 || Globals.destroyAllNotebook)
            Destroy(gameObject);
    }

    void Start()
    {
        Globals.imFuckingWinner = false;
        //Debug.Log(Globals.imFuckingWinner);
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    { 
        Globals.imFuckingWinner = false;
    }

    private void LateUpdate()
    {
        rb.velocity += Vector3.forward * 2 * Time.deltaTime;
        Globals.imFuckingWinner = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Runner"))
        {
            rb.velocity += Vector3.forward * Globals.speedRunner * Time.deltaTime;
        }

        if (collision.gameObject.CompareTag("Left"))
        {
            rb.velocity += Vector3.right * Globals.speedLeft * Time.deltaTime;
        }

        if (collision.gameObject.CompareTag("Right"))
        {
            rb.velocity += -Vector3.right * Globals.speedRight * Time.deltaTime;
        }
    }
}
