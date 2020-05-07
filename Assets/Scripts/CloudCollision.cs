using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Cloud hit!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
