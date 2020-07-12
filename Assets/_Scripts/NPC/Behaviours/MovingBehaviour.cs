using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingBehaviour : MonoBehaviour
{
    [System.NonSerialized]
    public bool completed = false;

    private NavMeshAgent agent;
    
    float minDist = 10.0f;
    private float distToPoint = 1.5f;
    bool reachedDest = false;
    Vector3 prevPos;

    public float delay;
    private float timer;

    private void OnEnable()
    {
        completed = false;
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        reachedDest = false;
        agent.SetDestination(GenerateRandomDest());
        prevPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(agent.destination, agent.transform.position) <= distToPoint)
        {
            reachedDest = true;
            completed = true;
        }
    }

    private Vector3 GenerateRandomDest()
    {
        Vector3 dest;
        float xMod, zMod; //Modifiers applied to determine destination
        xMod = Random.Range(-50.0f, 50.0f);
        zMod = Random.Range(-50.0f, 50.0f);
        if (xMod < 0)
            xMod -= minDist;
        else
            xMod += minDist;

        if (zMod < 0)
            zMod -= minDist;
        else
            zMod += minDist;

        dest = new Vector3(this.gameObject.transform.position.x + xMod, this.gameObject.transform.position.y, this.gameObject.transform.position.z + zMod);

        NavMeshPath m_Path = new NavMeshPath();
        agent.CalculatePath(dest, m_Path);
        if (m_Path.status == NavMeshPathStatus.PathPartial)
        {
            Debug.Log("Pathfinding error");
            dest = prevPos;
        }
        return dest;
    }

    /*public void GotoDiscussState()
    {
        agent.isStopped = true;
        this.GetComponent<MoveTo>().Transition(STATETYPE.DISCUSS); //Exit to discussion state
        completed = true;
    }*/
}
