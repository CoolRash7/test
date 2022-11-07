using System.Collections;
using UnityEngine;


public class Timbersaw : MonoBehaviour
{
    public LayerMask layerMask;


    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.up);

        Debug.DrawRay(transform.position + new Vector3(0, 0, 0.4f), transform.up, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0, 0.8f), transform.up, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0, 1.2f), transform.up, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0, 1.6f), transform.up, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, 0, 2f), transform.up, Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            //Debug.Log("TIMBERSAW TRIGGER, size obj:" + Globals.getSizeGameObject(other.gameObject));
            //for (int i = 0; i  < 27; i++)


           
        }

    }

    private void OnTriggerStay(Collider other)
    {
     

    }

 

    void boxColliderKill(GameObject obj)
    {
        Component[] array;
        array =obj.transform.GetComponents(typeof(Collider));

        foreach (Collider tempCollider in array)
            tempCollider.isTrigger = true;
    }
}
