using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ClimbCollider : MonoBehaviour
{
    [Tooltip("Right Hand?")]
    public bool rightHand = false;

    public ThirdPersonController controller;
    private Renderer cubeRenderer; // Renderer variable to change the color
    private HashSet<Collision> currentCollisions; // HashSet to store current collisions

    void Awake()
    {
        cubeRenderer = GetComponent<Renderer>(); // Initialize the renderer
        currentCollisions = new HashSet<Collision>(); // Initialize the HashSet
    }

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        cubeRenderer.material.color = Color.red; // Set initial color to red
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.name == "PlayerArmature" || hit.gameObject.name == "Player")
            return;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision); 
        controller.TriggerClimb(collision, rightHand);
        currentCollisions.Add(collision); // Add the collision to the HashSet
        UpdateColor();
    }


    void OnCollisionExit(Collision collision)
    {
        currentCollisions.Remove(collision); // Remove the collision from the HashSet
        StartCoroutine(DelayedUpdateColor());
    }

    IEnumerator DelayedUpdateColor()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        UpdateColor();
    }

    void UpdateColor()
    {
        if (currentCollisions.Count == 0)
        {
            cubeRenderer.material.color = Color.red; // Set color to red if no collisions
        }
        else
        {
            cubeRenderer.material.color = Color.green; // Set color to green if there are collisions
        }
    }
}
