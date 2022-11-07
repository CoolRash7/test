using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshtest : MonoBehaviour
{
    public Globals.TRAKTORSTATE state;
    public float idiotStamina = 0;
    private NavMeshAgent agent;
    Vector3 startPosition;
    

    float startSpeed;
    void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        startSpeed = agent.speed;
        state = Globals.TRAKTORSTATE.GO_MUSOR;
        StartCoroutine(start());
    }

    void Update()
    {
        //agent.speed = startSpeed * Globals.rpg.world_speed.multiply_speed;
        //&& Globals.rpg.musor_count < Globals.rpg.musor_max
        if (agent.destination == agent.pathEndPosition && agent.velocity == Vector3.zero )
        {
            idiotStamina += 0.1f;
        }
        else
            idiotStamina = 0;

        if (idiotStamina >= 10)
        {
            agent.SetDestination(searchAliveMusor());
            state = Globals.TRAKTORSTATE.GO_MUSOR;
        }
        /*
        if (Globals.rpg.musor_count >= Globals.rpg.musor_max)
        {
            agent.Stop();
        }

        if (Globals.rpg.musor_count < Globals.rpg.musor_max)
        {
            agent.Resume();
        }
        */
    }


    private void OnTriggerStay(Collider other)
    {
        switch (state)
        {
            case Globals.TRAKTORSTATE.GO_BAZA:
                if (other.gameObject.CompareTag("Baza"))
                {
                    agent.velocity = Vector3.zero;
                    //Globals.rpg.musor_count++;
                    //Globals.rpg.musor_count = Mathf.Clamp(Globals.rpg.musor_count, 0, Globals.rpg.musor_max);
                    state = Globals.TRAKTORSTATE.GO_MUSOR;
                    agent.SetDestination(searchAliveMusor());

                }

                break;

            case Globals.TRAKTORSTATE.GO_MUSOR:
                if (other.gameObject.CompareTag("Musor"))
                {
                    agent.velocity =Vector3.zero;

                    state = Globals.TRAKTORSTATE.GO_BAZA;
                    int musorID = other.gameObject.GetComponent<Musor>().ID;

                    Globals._musor tempMusor;
                    tempMusor.isAlive = false;
                    tempMusor.pos = Globals.musor[musorID].pos;
                    Globals.musor[musorID] = tempMusor;
                    agent.SetDestination(searchBaza());
                }
                break;
        }
    }

    IEnumerator start()
    {
        yield return new WaitForFixedUpdate();
        agent.SetDestination(searchAliveMusor());
    }
    Vector3 searchAliveMusor()
    {

        Vector3 result = startPosition;
        bool aliveOnce = false;

        foreach (int q in Globals.ID)
            if (Globals.musor[q].isAlive)
                aliveOnce = true;

        if (aliveOnce)
        {
            bool finded = false;
            int rand = Random.Range(0, Globals.musor.Count);
            do
            {
                if (Globals.musor[rand].isAlive)
                {
                    result = Globals.musor[rand].pos;
                    finded = true;
                }
                rand = Random.Range(0, Globals.musor.Count);
            } while (!finded);
        }
        //Debug.Log("MUSOR VECTOR: " + result);
        return result;
    }

    Vector3 searchBaza()
    {

        Vector3 result = Globals.baza[Random.Range(0, Globals.baza.Length)].pos;
        //Debug.Log("BAZA VECTOR: " + result);
        return result;
    }
}
