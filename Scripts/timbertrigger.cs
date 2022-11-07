using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timbertrigger : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj_upscore;
    public AudioSource audio;
    bool dontSpam1 = false;
    bool dontSpam2 = false;
    bool dontSpam3 = false;
    float timerSound = 0;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        audio.enabled = Globals.enabledSound;
        timerSound -= 0.2f * Time.deltaTime;
        audio.volume = timerSound;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Slice"))
            Dohod(other.gameObject);

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == 6 || other.gameObject.layer == 7)
        {
            if (Globals.enabledSound)
            {
                timerSound = 1;
            }

            if (Globals.enabledVibro && !dontSpam2)
            {
                Vibrator.Vibrate();
                StartCoroutine(qwer2());
            }

            if (!dontSpam3)
            {
                Instantiate(obj, transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
               
                StartCoroutine(qwer3());
            }

        }
        
    }
    
    void Dohod(GameObject obj)
    {

        //Globals.GATGETTYPE type = obj.GetComponent<Notebook>().type;

        GameObject score_obj = obj_upscore;
        float dohod = Globals.rpg.new_object.dohod;
        obj_upscore.GetComponent<UpScore>().dollar = dohod;
        Instantiate(score_obj, new Vector3(Mathf.Sin(Random.Range(0, 360)) * 2, -5.07f, 7.32f), Quaternion.identity);
        Globals.rpg.money += dohod;

    }

    IEnumerator qwer ()
    {
        dontSpam1 = true;
        yield return new WaitForSeconds(0.5f);
        dontSpam1 = false;
    } 
    
    IEnumerator qwer2 ()
    {
        dontSpam2 = true;
        yield return new WaitForSeconds(0.1f);
        dontSpam2 = false;
    } IEnumerator qwer3 ()
    {
        dontSpam3 = true;
        yield return new WaitForSeconds(0.05f);
        dontSpam3 = false;
    }
}
