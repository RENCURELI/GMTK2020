using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sight : MonoBehaviour
{
    public UnityEvent detectedInteractable;
    public UnityEvent detectedDiscussion;

    private SphereCollider trigger;

    private float g_DetectDelay = 1.0f;
    private float g_DetectTimer;

    [SerializeField]
    private float maxAngle; //Used to determine angle of view cone

    [SerializeField]
    private float viewDist; //Max distance at which NPC can see

    // Start is called before the first frame update
    void Start()
    {
        g_DetectDelay = 1.0f;
        g_DetectTimer = g_DetectDelay;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StateMachine>() != null)
        {
            Ray ray = new Ray();
            RaycastHit hit;

            ray.origin = this.transform.position;
            ray.direction = other.transform.position;

            if (Physics.Raycast(ray, out hit, viewDist))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                float angle = Vector3.Angle(ray.direction, this.transform.forward);
                if (angle > maxAngle)
                {
                    Debug.Log("Out of sight");
                    //Add logic HERE
                }
                else
                {
                    Debug.Log("In sight");
                    //Add logic HERE
                    if (other.GetComponent<StateMachine>().activeState != this.GetComponent<StateMachine>().activeState)
                    {
                        //The two objects are not in the same state
                    }
                    else
                    {
                        //the two objects are in the same state
                        detectedDiscussion.Invoke();
                        other.GetComponent<StateMachine>().activeState.ExitToTransition(1); //Move to discuss transition
                    }
                }
            }
        }
    }
}
