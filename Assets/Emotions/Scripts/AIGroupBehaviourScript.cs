using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGroupBehaviourScript : MonoBehaviour
{
    public GameObject BasseAI;
    public GameObject PianoAI;
    public GameObject BatterieAI;
    public GameObject GuitareAI;
    public GameObject ViolonAI;
    public GameObject SaxoAI;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}
