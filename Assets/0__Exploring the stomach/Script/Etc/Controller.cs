using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Controller : MonoBehaviour
{
    public XRLever lever;
    public XRLever upLever;
    public XRKnob knob;

    public float forwardSpeed;
    public float sideSpeed;
    public float upSpeed;

    public bool isForward;
    public bool isUp;

    void Update()
    {
        
        float forwardVelocity = forwardSpeed * (lever.value ? 1:0);
        float sideVelocity = sideSpeed * (lever.value ? 1:0) * Mathf.Lerp(-1,1,knob.value);
        float upVelocity = upSpeed * (upLever.value ? 1:0);

        Vector3 velocity = new Vector3(forwardVelocity, upVelocity, sideVelocity);
        transform.position += velocity * Time.deltaTime;

        if(upLever.value) isUp = true;
        else isUp = false;

        if(lever.value) isForward = true;
        else isForward = false;
        
    }

}