using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;

public class PitchScript : MonoBehaviour
{
    public string volumestr;
    public string pitchstr;
    public AudioMixer MainMixer;
    bool condition_vibrato;
    bool condition_volume;
    bool condition_bpm;
    float timer;
    float volume_inc;
    float bpm_inc;

    void Start()
    {
        condition_vibrato = false;
        condition_volume = false;
        condition_bpm = false;
        timer = 0;
        volume_inc = -10;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (condition_volume == true)
            Volume();
        else
            MainMixer.SetFloat(volumestr, -10);
        if (condition_vibrato == true)
            Vibrato();
        else
            MainMixer.SetFloat(pitchstr, 1);
    }

    public void Vibrato_Switch()
    {
        condition_vibrato = !condition_vibrato;
    }
    public void Volume_Switch()
    {
        condition_volume = !condition_volume;
    }

    public void BPM_Switch()
    {
        condition_bpm = !condition_bpm;
    }

    void Vibrato()
    {
        MainMixer.SetFloat(pitchstr, 1 + oscillate(timer, 5, 0.50f));
    }

    void Volume()
    {
        volume_inc -= 0.01f;
        MainMixer.SetFloat(volumestr, volume_inc);
    }

    float oscillate(float time, float speed, float scale)
    {
        return Mathf.Cos(time * speed / Mathf.PI) * scale;
    }
}
