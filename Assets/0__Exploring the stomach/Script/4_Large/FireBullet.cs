using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spwanPoint;
    public float fireSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireB);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FireB(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spwanPoint.transform.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spwanPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5f);

    }

}

