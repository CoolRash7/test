using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode : MonoBehaviour
{
    Camera cam;

    Vector3 zavodPosition = new Vector3(0, 12.39f, -8.87f);
    Vector3 worldPosition = new Vector3(0, 265.600006f, -248.399994f);

    Vector3 zavodEuler = new Vector3(55.305191f, 0, 0);
    Vector3 worldEuler = new Vector3(50.4000015f, 45, 0);

    float zavodNear = 0.3f;
    float zavodFar = 1000;

    float worldNear = -3000;
    float worldFar = 3330;

    float worldSize = 260;
    float zavodSize = 12;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        switch (Globals.gameState)
        {
            case Globals.GAMESTATE.WORLD:

                cam.orthographic = true;
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, worldEuler, 10 * Time.deltaTime);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, worldSize, 10 * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, worldPosition, 10 * Time.deltaTime);
                cam.nearClipPlane = worldNear;
                cam.farClipPlane = Mathf.Lerp(cam.farClipPlane, worldFar, 10 * Time.deltaTime);
                break;

            case Globals.GAMESTATE.ZAVOD:
                cam.orthographic = false;
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, zavodEuler, 10 * Time.deltaTime);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zavodSize, 10 * Time.deltaTime);
          
                transform.position = Vector3.Lerp(transform.position, zavodPosition, 10 * Time.deltaTime);

                cam.nearClipPlane = zavodNear;
                cam.farClipPlane = Mathf.Lerp(cam.farClipPlane, zavodFar, 10 * Time.deltaTime);
                break;
        }


        if (Globals.gameState == Globals.GAMESTATE.WORLD)
        {
            if (Input.GetMouseButton(0) )
            {

                float velX = Input.GetAxis("Mouse X");
                float velY = Input.GetAxis("Mouse Y");
                worldPosition -= (transform.right * (velX*3)) + (transform.up *( velY*3) );

                if (worldPosition.magnitude >= 1200)
                    worldPosition += (transform.right * (velX * 6)) + (transform.up * (velY * 6));

            }
        }


        //Debug.Log("Magnituted camrea: " + transform.position.magnitude);    
    }
}