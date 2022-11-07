using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BzKovSoft.ObjectSlicer;

public class DrawScreen : MonoBehaviour
{
    public GameObject obj_god;
    public Vector3 rayPlusVector;
    public float distanceRay = 10;
    public LayerMask layerMask;
    public float rangeOriginRay = 0;

    bool imLaunched = false;
    bool stopChecker = false;
    float rangeZ;
    LineRenderer lineRend;
    
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.SetColors(new Color(0, 0, 0, 0), new Color(0, 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.gameState == Globals.GAMESTATE.ZAVOD && (Globals.state == Globals.STATE.PLAY || Globals.state == Globals.STATE.NONE) )
        {
            //ray проверим внутри может ли ебанат получить луч истину ебаную
            Ray ray = new Ray(transform.position, transform.right + rayPlusVector);
            RaycastHit hit;
            Debug.DrawRay(transform.position + (transform.right * rangeOriginRay), (transform.right + rayPlusVector) * distanceRay);

            //look at camera (примерно)
            transform.LookAt(obj_god.transform.position);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,
                transform.rotation.eulerAngles.z - (Globals.angleAbar));
            //transform.rotation = Quaternion.Euler(61.101f, 0, (Globals.angleAbar) );
            if (!imLaunched)
            {
                if (Input.GetMouseButtonDown(0) && Input.mousePosition.y <= Globals.percent(Screen.height, 80) && Input.mousePosition.y >= Globals.percent(Screen.height, 10))
                {
                    stopChecker = false;
                    lineRend.SetColors(Color.cyan, Color.white);
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
                    lineRend.SetPosition(0, mousePosition);
                    transform.position = mousePosition;
                }

                if (Input.GetMouseButton(0))
                {
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
                    lineRend.SetPosition(1, mousePosition);

                    Vector2 pos1 = new Vector2(lineRend.GetPosition(0).x, lineRend.GetPosition(0).z);
                    Vector2 pos2 = new Vector2(lineRend.GetPosition(1).x, lineRend.GetPosition(1).z);

                    Globals.angleAbar = Globals.AbarAngle(pos1, pos2);
                }

                if (Input.GetMouseButtonUp(0))
                {

                    lineRend.SetColors(new Color(0, 0, 0, 0), new Color(0, 0, 0, 0));
                    Globals.goAnimCut = true;
                    //imLaunched = true;
                }
            }
        
        }
    }

    IEnumerator SliceCamera()
    {
        yield return null;

        Ray ray = new Ray(transform.position + (transform.right * rangeOriginRay), transform.right + rayPlusVector);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {

            IBzSliceableAsync sliceable = hit.transform.GetComponent<IBzSliceableAsync>();
            Vector3 direction = Vector3.Cross(ray.origin, ray.direction);
            Plane plane = new Plane(direction, ray.origin);

            if (sliceable != null)
            {
                stopChecker = true;
                sliceable.Slice(plane, 0, null);
                transform.position -= transform.forward * 2;
                rangeZ = 0;
                imLaunched = false;
            }

        }
    }
}
