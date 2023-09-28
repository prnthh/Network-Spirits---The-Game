using UnityEngine;
using UnityEngine.Advertisements;
 
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId = "5430598";
    [SerializeField] string _iOSGameId = "5430599";
    [SerializeField] bool _testMode = true;
    private string _gameId;
 
    void Awake()
    {
        InitializeAds();
    }
 
    public void InitializeAds()
    {

    #if UNITY_IOS
            _gameId = _iOSGameId;
    #elif UNITY_ANDROID
            _gameId = _androidGameId;
    #elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
    #endif
                Debug.Log($"Unity Ads initialization begun. {Advertisement.isInitialized} {Advertisement.isSupported}");

        if (Advertisement.isSupported)
        {
            if(!Advertisement.isInitialized)
                Advertisement.Initialize(_gameId, _testMode, this);
            else
                OnInitializationComplete();
        }
    }

 
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        InterstitialAd ad = gameObject.AddComponent<InterstitialAd>();
        InterstitialAd.Instance.LoadAd();
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}