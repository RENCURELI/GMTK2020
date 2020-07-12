using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public enum Status
{
    ENNEMI = -1,
    INDIFFERENT = 0,
    AMI = 1,
}

public class AiBehaviourScript : MonoBehaviour
{
    public int probvalue;
    public Status statusAI1;
    public Status statusAI2;
    public Status statusAI3;
    public Status statusAI4;
    public Status statusAI5;
    public GameObject AudioTrack;
    // Start is called before the first frame update
    void Start()
    {
        SetStatus();
        probvalue = 5 + (int)statusAI1 + (int)statusAI2 + (int)statusAI3 + (int)statusAI4 + (int)statusAI5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetStatus()
    {
        statusAI1 = StatusRandomizer();
        statusAI2 = StatusRandomizer();
        statusAI3 = StatusRandomizer();
        statusAI4 = StatusRandomizer();
        statusAI5 = StatusRandomizer();
    }

    Status StatusRandomizer()
    {
        return (Status)UnityEngine.Random.Range(-1, 2);
    }
}
