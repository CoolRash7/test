using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpScore : MonoBehaviour
{
    public float dollar = 1;

    TMPro.TextMeshPro textMesh;

    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshPro>();
        StartCoroutine(timerGo());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textMesh.text = dollar.ToString("#.##");
        transform.Translate(0, 5 * Time.deltaTime, 0);
    }

    IEnumerator timerGo()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
