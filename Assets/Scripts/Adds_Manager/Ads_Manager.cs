using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ads_Manager : MonoBehaviour
{
    public Initialize_Adds initializeAds;
    public Banner_Ads bannerAds;
    public Interstitial_Ads interstitialAds;
    public Rewarded_Ads rewardedAds;

    public static Ads_Manager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        bannerAds.LoadBannerAd();
        interstitialAds.LoadInterstitialAd();
        rewardedAds.LoadRewardedAd();
    }
}
