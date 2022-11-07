using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Cut : MonoBehaviour
{

    Material mat;
    GameObject kesobj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Slice"))
        {
            mat = other.GetComponent<MeshRenderer>().material;
            kesobj = other.gameObject;
        }
    }

    void Update()
    {

        if (Globals.goEzySlice && kesobj != null)
        {
            SlicedHull Kesilen = Kes(kesobj, mat);
            GameObject kesilenust = Kesilen.CreateUpperHull(kesobj, mat);
            kesilenust.AddComponent<MeshCollider>().convex = true;
            //kesilenust.AddComponent<Rigidbody>();
            kesilenust.layer = LayerMask.NameToLayer("Slice");
            GameObject kesilenalt = Kesilen.CreateLowerHull(kesobj, mat);
            kesilenalt.AddComponent<MeshCollider>().convex = true;
            kesilenalt.AddComponent<Rigidbody>();
            kesilenalt.layer = LayerMask.NameToLayer("Slice");
            Destroy(kesobj);
            Globals.goEzySlice = false;
        }


        /*
        if (Input.GetMouseButtonDown(1) && kesobj != null)
        {
            SlicedHull Kesilen = Kes(kesobj, mat);
            GameObject kesilenust = Kesilen.CreateUpperHull(kesobj, mat);
            kesilenust.AddComponent<MeshCollider>().convex = true;
            //kesilenust.AddComponent<Rigidbody>();
            kesilenust.layer = LayerMask.NameToLayer("Slice");
            GameObject kesilenalt = Kesilen.CreateLowerHull(kesobj, mat);
            kesilenalt.AddComponent<MeshCollider>().convex = true;
            kesilenalt.AddComponent<Rigidbody>();
            kesilenalt.layer = LayerMask.NameToLayer("Slice");
            Destroy(kesobj);
        }
        */

    }
    public SlicedHull Kes(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

}
