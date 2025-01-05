using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Banner_Ads : MonoBehaviour
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

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }

    public void ShowBannerId()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = Bannershown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };

        Advertisement.Banner.Show(adUnitId, options);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
    #region Show Callback
    private void BannerHidden()
    {
        throw new NotImplementedException();
    }

    private void BannerClicked()
    {
        throw new NotImplementedException();
    }

    private void Bannershown()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Load Callback
    private void BannerLoadedError(string message)
    {
        throw new NotImplementedException();
    }

    private void BannerLoaded()
    {
        throw new NotImplementedException();
    }
    #endregion


}
