using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : MonoBehaviour
{
    [System.NonSerialized]
    public bool completed = false;

    public float delay;
    private float timer;

    private void OnEnable()
    {
        completed = false;
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
}
