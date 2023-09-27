using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;    

    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Start()
    {
        float speed = 10f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // add momentum to the object we hit
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
        if(otherRigidbody != null)
        {
            otherRigidbody.AddForce(transform.forward * 5f, ForceMode.Impulse);
        }
            Destroy(gameObject);

    }
}
