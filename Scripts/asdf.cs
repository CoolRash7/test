using System.Collections;
using UnityEngine;
using BzKovSoft.ObjectSlicer;

public class asdf : MonoBehaviour
{

    public LayerMask layerMask;
    public Vector3 positionRay, directionRay;
    public GameObject fx_obj;

    bool dontSpam1 = false, dontSpam2 = false;


    void Start()
    {
        //startPosition = transform.position;
    
        fx_obj.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position + (-transform.right * positionRay.z), (-transform.right) * 100, Color.green);
        
        /*
        Debug.DrawRay(transform.position+ (-transform.right * positionRay.z), (-transform.right) * 100, Color.green);
        Debug.DrawRay(transform.position + (-transform.right * positionRay.z) + new Vector3(0, range1, 0), (-transform.right) * 100, Color.green);
        Debug.DrawRay(transform.position + (-transform.right * positionRay.z) + new Vector3(0, range2, 0), (-transform.right) * 100, Color.green);
        Debug.DrawRay(transform.position + (-transform.right * positionRay.z) + new Vector3(0, range3, 0), (-transform.right+ directionRay) * 100, Color.green);

        */
        //Debug.DrawRay( (transform.position + new Vector3(0, range, 0) ), (-transform.right) * 10, Color.green);

      
        //transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == 6 && Globals.timbersawState == Globals.TIMBERSAWSTATE.GO)
        {
            Vector3 f = transform.TransformPoint(other.GetComponent<MeshFilter>().sharedMesh.bounds.center);
            StartCoroutine(SliceSawMove());
            //StartCoroutine(SliceSaw(f.y) );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (Globals.enabledSound && !dontSpam1)
            {

                GetComponent<AudioSource>().Play();
                dontSpam1 = true;
            }

            if (Globals.enabledVibro && !dontSpam2)
            {
                Vibrator.Vibrate();
                dontSpam2 = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer == 6)
        {
            dontSpam1 = false;
            dontSpam2 = false;
        }

    }




    
    IEnumerator SliceSawMove()
    {


        Ray ray = new Ray((transform.position) + (-transform.right * positionRay.z), (-transform.right));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20, layerMask))
        {
            IBzSliceableAsync sliceable = hit.transform.GetComponent<IBzSliceableAsync>();
            Vector3 direction = Vector3.Cross(ray.origin, ray.direction);
            Plane plane = new Plane(direction, ray.origin);

            if (sliceable != null)
            {


                sliceable.Slice(plane, 0, null);
                fx_obj.GetComponent<ParticleSystem>().Stop();
                fx_obj.GetComponent<ParticleSystem>().Play();


            }

        }


        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator qwer()
    {
        dontSpam1 = true;
        yield return new WaitForSeconds(0.7f);
        dontSpam1 = false;
    }


    IEnumerator qwer2()
    {
        dontSpam2 = true;
        yield return new WaitForSeconds(0.7f);
        dontSpam2 = false;
    }
}