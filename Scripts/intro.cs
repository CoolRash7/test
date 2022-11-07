using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fromStart());
    }

    // Update is called once per frame
    private IEnumerator fromStart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
