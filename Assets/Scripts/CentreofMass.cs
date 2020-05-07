using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreofMass : MonoBehaviour
{
        public Transform tf;

    void Update()
    {
    GetComponent<Rigidbody>().centerOfMass = tf.localPosition;
    }
}
