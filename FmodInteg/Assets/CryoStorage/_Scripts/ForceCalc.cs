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
        emitter.SetParameter("Force", RemapForce(rb.velocity.magnitude));
        Debug.Log(RemapForce(rb.velocity.magnitude));
    }
    
    float RemapForce(float force)
    {
        var eForce = Mathf.Lerp(0, 1, force);
        if (eForce >= 1)
        {
            return 1;
        }
        else { return eForce; }

        

    }
}
