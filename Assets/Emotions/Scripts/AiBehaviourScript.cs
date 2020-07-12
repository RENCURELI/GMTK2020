using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public enum Status
{
    AMI = 0,
    INDIFFERENT = 1,
    ENNEMI = 2
}

public class AiBehaviourScript : MonoBehaviour
{
    int probvalue;
    public Status statusAI1;
    public Status statusAI2;
    public Status statusAI3;
    public Status statusAI4;
    public Status statusAI5;
    // Start is called before the first frame update
    void Start()
    {
        probvalue = 50;
        SetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetStatus()
    {
        statusAI1 = StatusRandomizer();
        print(statusAI1);
        statusAI2 = StatusRandomizer();
        print(statusAI2);
        statusAI3 = StatusRandomizer();
        print(statusAI3);
        statusAI4 = StatusRandomizer();
        print(statusAI4);
        statusAI5 = StatusRandomizer();
        print(statusAI5);
    }

    Status StatusRandomizer()
    {
        return (Status)UnityEngine.Random.Range(0, 3);
    }
}
