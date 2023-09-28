using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static Bootstrap Instance { get; private set; }
    public static AdsInitializer adsInitializer { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
                    DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // create an instance and add to root of scene
        adsInitializer = gameObject.AddComponent<AdsInitializer>();
    }
}