﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterSpawn : MonoBehaviour
{
    public GameObject Rain;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Rainy!");
            Rain.GetComponent<ParticleSystem>().Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Stop Rainy!");
            Rain.GetComponent<ParticleSystem>().Stop();
        }
    }
}
