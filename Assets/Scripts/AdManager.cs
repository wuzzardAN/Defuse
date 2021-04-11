using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour
{
    private int rewardCoin;
    private BannerView bannerAd;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    public string appID = "ca-app-pub-1838583868978866~5754097749";
    public string interstitialID = "ca-app-pub-1838583868978866/9694160992";
    public string bannerID = "ca-app-pub-1838583868978866/5271716164";
    public string rewardedID = "ca-app-pub-1838583868978866/5982980848";
    public AdPosition position;

    public void Start() {
      rewardCoin = PlayerPrefs.GetInt("Coin");
      MobileAds.Initialize(appID);
      Banner();
      InterstitialAD();
      RewardedAD();
    }

    public void RewardedAD() {
      rewardedAd = new RewardedAd(rewardedID);
      // Called when an ad request has successfully loaded.
      this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
      // Called when an ad request failed to load.
      this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
      // Called when an ad is shown.
      this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
      // Called when an ad request failed to show.
      this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
      // Called when the user should be rewarded for interacting with the ad.
      this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
      // Called when the ad is closed.
      this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

      AdRequest newAdRewarded = new AdRequest.Builder().Build();
      rewardedAd.LoadAd(newAdRewarded);
    }

    public void Rewarded() {
      if(rewardedAd.IsLoaded()) {
        rewardedAd.Show();
        Debug.Log("Ad Open");
        Debug.Log("Reward");

      }
      else {
        Debug.Log("Ad Not Open Need Internet Connection");
      }
    }

    public void Banner() {
      bannerAd = new BannerView(bannerID, AdSize.Banner, position);
      Debug.Log("Banner Created");

      AdRequest newAdBanner = new AdRequest.Builder().Build();
      Debug.Log("Banner Request");

      bannerAd.Show();
      Debug.Log("Banner Show");
    }
    public void InterstitialAD() {
      interstitialAd = new InterstitialAd(interstitialID);
      // Called when an ad request has successfully loaded.
      this.interstitialAd.OnAdLoaded += HandleOnAdLoaded;
   // Called when an ad request failed to load.
      this.interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
   // Called when an ad is shown.
      this.interstitialAd.OnAdOpening += HandleOnAdOpened;
   // Called when the ad is closed.
      this.interstitialAd.OnAdClosed += HandleOnAdClosed;
   // Called when the ad click caused the user to leave the application.
      this.interstitialAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;

      AdRequest newAdInterstitial = new AdRequest.Builder().Build();
      interstitialAd.LoadAd(newAdInterstitial);
    }

    public void Interstitial() {
      if(interstitialAd.IsLoaded()) {
        interstitialAd.Show();
        Debug.Log("Ad Open");
      }
      else {
        Debug.Log("Ad Not Open Need Internet Connection");
      }
    }
//Interstitial ad Handler
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
      MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
      MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                      + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
      MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
      MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

//Rewarded ad Handler

public void HandleRewardedAdLoaded(object sender, EventArgs args)
  {
      Debug.Log("Rewarded Ad Load");
  }

  public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void HandleRewardedAdOpening(object sender, EventArgs args)
  {
      Debug.Log("Rewarded Ad Open");

  }

  public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void HandleRewardedAdClosed(object sender, EventArgs args)
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void HandleUserEarnedReward(object sender, Reward args)
  {
      Debug.Log("Reward 100 Coin");
      rewardCoin = rewardCoin + 200;
      PlayerPrefs.SetInt("Coin", + rewardCoin);
  }
}
