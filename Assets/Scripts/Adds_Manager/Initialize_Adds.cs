using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Initialize_Adds : MonoBehaviour, IUnityAdsInitializationListener
{

    [SerializeField] private string androidGameId;
    [SerializeField] private string iosGameId;
    [SerializeField] private bool isTesting;

    private string gameId;

    public void OnInitializationComplete()
    {
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
       
    }

    private void Awake()
    {
     #if UNITY_IOS
         gameId = iosGameId;

    #elif UNITY_ANDROID
         gameId = androidGameId;

    #elif UNITY_EDITOR
        gameId=androidGameId;

    #endif


        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTesting, this);
        }
    }

    
}