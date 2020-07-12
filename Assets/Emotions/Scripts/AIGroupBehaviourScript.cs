using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AIGroupBehaviourScript : MonoBehaviour
{
    public List<GameObject> CharacterList;
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
        CharacterList = new List<GameObject>();
        CharacterList.Add(BasseAI);
        CharacterList.Add(PianoAI);
        CharacterList.Add(BatterieAI);
        CharacterList.Add(GuitareAI);
        CharacterList.Add(ViolonAI);
        CharacterList.Add(SaxoAI);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((int)timer > 0 && (int)timer % 10 == 0)
        {
            ErrorChecker();
            timer = 0;
        }
    }

    void ErrorChecker()
    {
        for (int i = 0; i < CharacterList.Count; i++)
        {
            var tmp = CharacterList[i].GetComponent<AiBehaviourScript>();
            //print(tmp.probvalue);
            if (UnityEngine.Random.Range(0, 11) > tmp.probvalue)
            {
                //print(CharacterList[i].ToString());
                TurnOnError(CharacterList[i]);
            }
        }
    }

    void TurnOnError(GameObject Character)
    {
        var tmp = Character.GetComponent<AiBehaviourScript>();
        var audiotmp = tmp.AudioTrack.GetComponent<PitchScript>();
        int rand = UnityEngine.Random.Range(0, 2);
        if (rand == 0)
        {
            //print("VIBRATO ON");
            audiotmp.Vibrato_Switch();
        }
        else
        {
            //print("VOLUME ON");
            audiotmp.Volume_Switch();
        }

    }
}
