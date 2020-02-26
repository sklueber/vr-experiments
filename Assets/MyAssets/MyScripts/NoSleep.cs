using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSleep : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
