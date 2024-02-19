using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObstacleScript : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rb.IsSleeping())
            rb.WakeUp();
    }
}
