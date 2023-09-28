using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ClimbCollider : MonoBehaviour
{
    public ThirdPersonController controller;
    void Awake()
    {
        // bulletRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Start()
    {
    }
    void OnTriggerEnter(Collider hit)
    {
        //Output the Collider's GameObject's name
        controller.TriggerClimb(hit);
    }
}
