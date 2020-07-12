using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : MonoBehaviour
{
    [System.NonSerialized]
    public bool completed = false;

    [System.NonSerialized]
    public StateMachine stateMachine; //State machine the instance belongs too

    public float delay;
    private float timer;

    private void OnEnable()
    {
        completed = false;
        stateMachine = this.GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("IdleState");
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            completed = true;
        }
    }

    public void Transition(STATETYPE type)
    {
        if (stateMachine.states.ContainsKey(type))
        {
            stateMachine.nextState = stateMachine.states[type];

            stateMachine.EnterState(stateMachine.nextState, type);
        }
    }
}
