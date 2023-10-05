using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ClimbCollider : MonoBehaviour
{

        [Tooltip("Right Hand?")]
        public bool rightHand = false;

    public ThirdPersonController controller;
    void Awake()
    {
        // bulletRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    void OnTriggerEnter(Collider hit)
    {
        //Output the Collider's GameObject's name
        if(hit.gameObject.name == "PlayerArmature" || hit.gameObject.name == "Player")
            return;
            
        // controller.TriggerClimb(hit);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision); 
        controller.TriggerClimb(collision, rightHand);

        // if (collision.relativeVelocity.magnitude > 2)
        //     audioSource.Play();
    }
}
