using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Interstitial_Ads : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{ 
    [SerializeField] private string androidAddUnitId;
    [SerializeField] private string iosAddUnitId;

    private string adUnitId;

    private void Awake()
    {
#if Unity_IOS
    adUnitId = iosAddUnitId;
#elif Unity_ANDROID
     adUnitId = androidAddUnitId;
#endif
    }

    public void LoadInterstitialAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowInterstitialAd()
    {
        Advertisement.Show(adUnitId, this);
    }
    #region Interface
    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
