using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static Bootstrap Instance { get; private set; }
    public static AdsInitializer adsInitializer { get; private set; }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // create an instance and add to current gameObject
        adsInitializer = gameObject.AddComponent<AdsInitializer>();
    }
}