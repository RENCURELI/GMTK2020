using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    public AudioMixer MainMixer;
    public float pitch_nbr;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        MainMixer.SetFloat("pitchval", pitch_nbr);
    }
}
