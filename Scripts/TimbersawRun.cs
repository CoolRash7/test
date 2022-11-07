using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BzKovSoft.ObjectSlicer;

public class TimbersawRun : MonoBehaviour
{

    public LayerMask layerMask;
    public float speed;
    [Range(0f, 10f)]
    public float range1;
    [Range(0f, 10f)]
    public float range2;
    [Range(0f, 10f)]
    public float range3;
    public Vector3 positionRay, directionRay;
    public GameObject fx_obj;
    public AudioSource audio;

    bool dontSpam1 = false, dontSpam2 = false;
    bool success_slice = false;
    Vector3 startPosition;
    Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        fx_obj.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        Debug.DrawRay(transform.position + (-transform.right * positionRay.z) + (transform.up * positionRay.y), (-transform.right + directionRay) * 100, Color.green);
       // Debug.DrawRay(transform.position + (-transform.right * positionRay.z) + new Vector3(0, range1, 0), (-transform.right + directionRay) * 100, Color.green);
       // Debug.DrawRay(transform.position + (-transform.right * positionRay.z) + new Vector3(0, range2, 0), (-transform.right + directionRay) * 100, Color.green);
        //Debug.DrawRay(transform.position + (-transform.right * positionRay.z) + new Vector3(0, range3, 0), (-transform.right + directionRay) * 100, Color.green);
        //Debug.DrawRay( (transform.position + new Vector3(0, range, 0) ), (-transform.right) * 10, Color.green);

        switch (Globals.timbersawState)
        {
            case Globals.TIMBERSAWSTATE.NONE:
                transform.position = new Vector3(-23.3400002f, -4.11000013f, -5.4000001f);
                break;

            case Globals.TIMBERSAWSTATE.READY:
                success_slice = false;

                rb.velocity = Vector3.zero;
                transform.position = Globals.timbersawStartPoint;
                transform.LookAt(Globals.vectorCursor);
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0);

                break;

            case Globals.TIMBERSAWSTATE.GO:
                rb.velocity = transform.right * speed * Time.deltaTime;
                break;
        }
        transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == 6 && Globals.timbersawState == Globals.TIMBERSAWSTATE.GO)
        {
            //Vector3 f = transform.TransformPoint(other.GetComponent<MeshFilter>().sharedMesh.bounds.center);
            StartCoroutine(SliceSaw2());


        }
    }

    IEnumerator SliceSaw(float range)
    {

        Ray ray = new Ray(new Vector3(transform.position.x, range, transform.position.z) + (-transform.right * positionRay.z), (-transform.right + directionRay));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            IBzSliceableAsync sliceable = hit.transform.GetComponent<IBzSliceableAsync>();
            Vector3 direction = Vector3.Cross(ray.origin, ray.direction);
            Plane plane = new Plane(direction, ray.origin);

            if (sliceable != null)
            {
                if (Globals.enabledSound && !dontSpam1)
                {

                    audio.Play();
                    StartCoroutine(qwer());
                }

                if (Globals.enabledVibro && !dontSpam2)
                {
                    Vibrator.Vibrate();
                    StartCoroutine(qwer2());
                }

                //Debug.Log("SUCCESS SLICE BOUNDS CENTER");
                sliceable.Slice(plane, 0, null);
                fx_obj.GetComponent<ParticleSystem>().Stop();
                fx_obj.GetComponent<ParticleSystem>().Play();
                success_slice = true;
                yield return null;

            }
        }

        yield return new WaitForSeconds(0.05f);
        Ray ray1 = new Ray(new Vector3(transform.position.x, 0, transform.position.z) + (-transform.right * positionRay.z), (-transform.right + directionRay));
        RaycastHit hit1;
        if (Physics.Raycast(ray1, out hit1, Mathf.Infinity, layerMask) && !success_slice)
        {
            IBzSliceableAsync sliceable = hit1.transform.GetComponent<IBzSliceableAsync>();
            Vector3 direction = Vector3.Cross(ray1.origin, ray1.direction);
            Plane plane = new Plane(direction, ray1.origin);

            if (sliceable != null)
            {
                if (Globals.enabledSound && !dontSpam1)
                {

                    audio.Play();
                    StartCoroutine(qwer());
                }

                if (Globals.enabledVibro && !dontSpam2)
                {
                    Vibrator.Vibrate();
                    StartCoroutine(qwer2());
                }

                if (Globals.enabledVibro)
                    Vibrator.Vibrate();
                Debug.Log("SUCCESS SLICE 0");
                sliceable.Slice(plane, 0, null);
                fx_obj.GetComponent<ParticleSystem>().Stop();
                fx_obj.GetComponent<ParticleSystem>().Play();
                success_slice = true;
                yield return null;

            }
        }

        yield return new WaitForSeconds(0.05f);

        Ray ray2 = new Ray(new Vector3(transform.position.x, range1, transform.position.z) + (-transform.right * positionRay.z), (-transform.right + directionRay));
        RaycastHit hit2;
        if (Physics.Raycast(ray2, out hit2, Mathf.Infinity, layerMask) && !success_slice)
        {
            IBzSliceableAsync sliceable = hit2.transform.GetComponent<IBzSliceableAsync>();
            Vector3 direction = Vector3.Cross(ray2.origin, ray2.direction);
            Plane plane = new Plane(direction, ray2.origin);

            if (sliceable != null)
            {
                if (Globals.enabledSound && !dontSpam1)
                {

                    audio.Play();
                    StartCoroutine(qwer());
                }

                if (Globals.enabledVibro && !dontSpam2)
                {
                    Vibrator.Vibrate();
                    StartCoroutine(qwer2());
                }
                sliceable.Slice(plane, 0, null);
                fx_obj.GetComponent<ParticleSystem>().Stop();
                fx_obj.GetComponent<ParticleSystem>().Play();
                Debug.Log("SUCCESS SLICE RANGE1");
                success_slice = true;
                yield return null;
            }
        }

        yield return new WaitForSeconds(0.05f);

        Ray ray3 = new Ray(new Vector3(transform.position.x, range2, transform.position.z) + (-transform.right * positionRay.z), (-transform.right + directionRay));
        RaycastHit hit3;
        if (Physics.Raycast(ray3, out hit3, Mathf.Infinity, layerMask) && !success_slice)
        {
            IBzSliceableAsync sliceable = hit3.transform.GetComponent<IBzSliceableAsync>();
            Vector3 direction = Vector3.Cross(ray3.origin, ray3.direction);
            Plane plane = new Plane(direction, ray3.origin);

            if (sliceable != null)
            {
                if (Globals.enabledSound && !dontSpam1)
                {

                    audio.Play();
                    StartCoroutine(qwer());
                }

                if (Globals.enabledVibro && !dontSpam2)
                {
                    Vibrator.Vibrate();
                    StartCoroutine(qwer2());
                }
                sliceable.Slice(plane, 0, null);
                fx_obj.GetComponent<ParticleSystem>().Stop();
                fx_obj.GetComponent<ParticleSystem>().Play();
                Debug.Log("SUCCESS SLICE RANGE2");
                success_slice = true;
                yield return null;
            }
        }

        yield return new WaitForSeconds(0.05f);

        Ray ray4 = new Ray(new Vector3(transform.position.x, range3, transform.position.z) + (-transform.right * positionRay.z), (-transform.right + directionRay));
        RaycastHit hit4;
        if (Physics.Raycast(ray4, out hit4, Mathf.Infinity, layerMask) && !success_slice)
        {
            IBzSliceableAsync sliceable = hit4.transform.GetComponent<IBzSliceableAsync>();
            Vector3 direction = Vector3.Cross(ray4.origin, ray4.direction);
            Plane plane = new Plane(direction, ray4.origin);

            if (sliceable != null)
            {
                if (Globals.enabledSound && !dontSpam1)
                {

                    audio.Play();
                    StartCoroutine(qwer());
                }

                if (Globals.enabledVibro && !dontSpam2)
                {
                    Vibrator.Vibrate();
                    StartCoroutine(qwer2());
                }

                if (Globals.enabledVibro)
                    Vibrator.Vibrate();

                sliceable.Slice(plane, 0, null);
                fx_obj.GetComponent<ParticleSystem>().Stop();
                fx_obj.GetComponent<ParticleSystem>().Play();
                Debug.Log("SUCCESS SLICE RANGE3");
                success_slice = true;
                yield return null;
            }
        }

        yield return new WaitForSecondsRealtime(0.1f);
    }

    IEnumerator SliceSaw2()
    {
        yield return null;

        Ray ray = new Ray(transform.position + (-transform.right * positionRay.z) + (transform.up * positionRay.y), (-transform.right + directionRay));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                IBzSliceableAsync sliceable = hit.transform.GetComponent<IBzSliceableAsync>();
                //ector3 direction = Vector3.Cross(ray.origin, ray.direction);
                //Vector3 dirr = Vector3.ProjectOnPlane(ray.origin, ray.direction);
                Plane plane = new Plane(transform.forward, ray.origin);



                if (sliceable != null)
                {


                sliceable.Slice(plane, 0, null);
                fx_obj.GetComponent<ParticleSystem>().Stop();
                fx_obj.GetComponent<ParticleSystem>().Play();
                success_slice = true;


                if (Globals.enabledSound && !dontSpam1)
                {

                    audio.Play();
                    StartCoroutine(qwer());
                }

                if (Globals.enabledVibro && !dontSpam2)
                {
                    Vibrator.Vibrate();
                    StartCoroutine(qwer2());
                }



                }

            }


     
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