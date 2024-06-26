using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolMeteo : MonoBehaviour
{
    public ParticleSystem particles;

    public LayerMask layerMask;
    public Transform shooutSource;
    public float distance = 10f;

    private bool rayActivate = false;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShout());
        grabInteractable.deactivated.AddListener(x => StopShout());
    }

    // Update is called once per frame
    void Update()
    {
        if(rayActivate)
        {
            RayCastCheck();
        }
    }

    public void StartShout()
    {
        particles.Play();
        rayActivate = true;

    }

    public void StopShout()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;

    }

    void RayCastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shooutSource.position, shooutSource.forward, out hit, distance, layerMask);
        if(hasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
