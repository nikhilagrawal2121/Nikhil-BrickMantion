using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    private BannerView BannerAd;
    private InterstitialAd interstitial;

    public static AdManager instance; // creating the instance of the script to acess anywhere in other  script


    private void Awake()
    {
        if(instance == null) // check instance is null
        {
            instance = this; //if null then acess to this script
        }
        else
        {
            Destroy(this.gameObject); //if not null then distroy
            return;
        }
    }

    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { }); //initilization of mobile ads
        this.RequestBanner(); //calling request banner fuction
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-2764629101823709/7520230311"; //passing the unit id
        this.BannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top ); // initilizing the banner ad size id and position
        this.BannerAd.LoadAd(this.CreateAdRequest()); // loding the ad
    }

    public void RequestInterstitial()
    {
        string adUnitid = "ca-app-pub-2764629101823709/8822537842"; //this is testing id

        if (this.interstitial != null)
            this.interstitial.Destroy();

        this.interstitial = new InterstitialAd(adUnitid); // creating new interstitial ad

        this.interstitial.LoadAd(this.CreateAdRequest()); //loading the interstitial ad

    }

    public void showInterstitial() // to show inretiutial ad need to create the fun 
    {
        if(this.interstitial.IsLoaded()) // checking that interstitial ad is loaded
        {
            interstitial.Show(); // show the interstitial ad
        }
    }

}