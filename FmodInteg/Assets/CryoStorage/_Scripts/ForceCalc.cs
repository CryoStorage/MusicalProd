using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCalc : MonoBehaviour
{
    // Start is called before the first frame update
    FMODUnity.StudioEventEmitter emitter;
    Rigidbody rb;
    void Awake()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mappedForce = Mathf.InverseLerp(0,10 , rb.velocity.magnitude);
        emitter.SetParameter("Force", mappedForce);
    }

}
