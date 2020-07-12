using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int foodCount = 5;
    public GameObject food;
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && foodCount > 0)
        {
            Instantiate(food,cam.position,cam.rotation);
            foodCount--;
        }
    }
}
