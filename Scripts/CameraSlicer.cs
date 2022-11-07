using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BzKovSoft.ObjectSlicer;

public class CameraSlicer : MonoBehaviour
{
    public LayerMask layerMask;
    public LayerMask layerMaskIgnore;
    public GameObject objPoint;
    public GameObject objPoint2;
    [Header("Globals.destroySize")]
    public float destroySize = 15;

    public float maxFlyY = 10;

    Ray worldRay;
    bool is_success_pressed = false;
    bool delay_saw = false;
    
    void Start()
    {
    }

    void Update()
    {

        worldRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit, hit2;

        if (Physics.Raycast(worldRay, out hit))
        {
            objPoint.transform.position = hit.point;
            transform.LookAt(hit.point);
            transform.position = new Vector3((float)hit.point.x, transform.position.y, transform.position.z);
        }

        if (Physics.Raycast(worldRay, out hit2, Mathf.Infinity, layerMaskIgnore))
        {
            Globals.vectorCursor = hit2.point;
            objPoint2.transform.position = hit2.point;
            
        }

        if (Globals.state == Globals.STATE.NONE && Input.GetMouseButtonDown(0))
        {
            Globals.state = Globals.STATE.PLAY;
        }
        //if play state
        if (Globals.state == Globals.STATE.PLAY)
        {

            //gamestate control
            switch (Globals.gameState)
            {
                case Globals.GAMESTATE.ZAVOD:
                    if (Globals.cut > 0)
                    {
                        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < Globals.percent(Screen.height, 80) && Input.mousePosition.y >= Globals.percent(Screen.height, 10)  && !delay_saw )
                        {
                            Globals.timbersawStartPoint = Globals.vectorCursor;
                            Globals.timbersawState = Globals.TIMBERSAWSTATE.READY;
                            is_success_pressed = true;
                        }

                        if (Input.GetMouseButtonUp(0) && is_success_pressed)
                        {
                            Globals.timbersawState = Globals.TIMBERSAWSTATE.GO;
                            //Globals.cut--;
                            is_success_pressed = false;
                            StartCoroutine(DelaySaw());
                        }
                    }

                    break;

                case Globals.GAMESTATE.WORLD:
                  
                    break;

                case Globals.GAMESTATE.NONE:
                    if (Input.GetMouseButtonDown(0))
                    {
                        Globals.timbersawStartPoint = Globals.vectorCursor;
                        Globals.timbersawState = Globals.TIMBERSAWSTATE.READY;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        Globals.timbersawState = Globals.TIMBERSAWSTATE.GO;
                    }
                    break;
            }
        }

       

        //Debug.DrawRay(transform.position, transform.forward);
    }

    void FixedUpdate()
    {

    }

    IEnumerator SliceCamera()
    {
        yield return null;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20, layerMask)) {
            IBzSliceableAsync sliceable = hit.transform.GetComponent<IBzSliceableAsync>();
            Vector3 direction = Vector3.Cross(ray.origin, ray.direction);
            Plane plane = new Plane(direction, ray.origin);

            if (sliceable != null)
            {
                sliceable.Slice(plane, 0, null);
            }

        }
    }

    /*
    void UpObject()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
            
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Up OBject Work!");
            hit.transform.gameObject.GetComponent<Notebook>().imFucked = true;
        }

    }
    */

    IEnumerator DelaySaw()
    {
        delay_saw = true;
        yield return new WaitForSeconds(0.0f);
        delay_saw = false;
    }
}
