using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool state = false;

    public enum objectType
    {
        Door,
        Light,
        Micro,
        TV,
    }
    public objectType type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        state = !state;
        switch (type)
        {
            case objectType.Door:
                rotateDoor(state);
                break;
            case objectType.Light:
                manageLight(state);
                break;
            default:
                break;
        }
    }

    void rotateDoor(bool state)
    {
        float xOffset = 0.25f;
        float zOffset = 0.4f;
        float rotation = 90;

        if (state)
        {
            transform.SetPositionAndRotation(new Vector3(xOffset, transform.position.y, zOffset), Quaternion.identity);
            transform.Rotate(new Vector3(0, rotation, 0));
        } else
        {
            transform.SetPositionAndRotation(new Vector3(0f, transform.position.y, 0f), Quaternion.identity);
            transform.Rotate(new Vector3(0, 0, 0));
        }
    }

    void manageLight(bool state)
    {
        transform.GetChild(0).gameObject.SetActive(state);
    }
}
