using System.Collections.Generic;
using UnityEngine;

public class ClimbManager : MonoBehaviour
{
    public static ClimbManager Instance { get; private set; }

    private Dictionary<GameObject, int> hitObjects = new Dictionary<GameObject, int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ObjectHit(GameObject hitObject)
    {
        if (hitObjects.ContainsKey(hitObject))
        {
            hitObjects[hitObject]++;
        }
        else
        {
            hitObjects[hitObject] = 1;
        }
    }

    public void ObjectExited(GameObject hitObject)
    {
        if (hitObjects.ContainsKey(hitObject))
        {
            hitObjects[hitObject]--;
        }
    }

    public int GetHitCount(GameObject hitObject)
    {
        return hitObjects.ContainsKey(hitObject) ? hitObjects[hitObject] : 0;
    }
}