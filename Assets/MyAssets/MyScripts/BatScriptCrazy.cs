﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScriptCrazy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
