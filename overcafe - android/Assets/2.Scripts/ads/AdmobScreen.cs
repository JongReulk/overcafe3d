using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobScreen : MonoBehaviour
{
    public static AdmobScreen instance
    {
        get
        {
            if (S_instance == null)
            {
                S_instance = FindObjectOfType<AdmobScreen>();

            }

            return S_instance;
        }
    }

    private static AdmobScreen S_instance;

    private readonly string unitID = "ca-app-pub-4697644976729834/2036571677";
    private readonly string test_unitID = "ca-app-pub-3940256099942544/1033173712";

    private readonly string test_deviceID = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd screenAd;


    private void Awake()
    {
        InitAd();
        //Invoke("Show", 0.1f);
    }
    private void InitAd()
    {
        string id = unitID;

        screenAd = new InterstitialAd(id);

        AdRequest request = new AdRequest.Builder().Build();

        screenAd.LoadAd(request);
        screenAd.OnAdClosed += (sender, e) => Debug.Log("광고가 닫힘");
        screenAd.OnAdLoaded += (sender, e) => Debug.Log("광고가 로드됨");
    }

    public void Show()
    {
        StartCoroutine("ShowScreenAd");
    }

    private IEnumerator ShowScreenAd()
    {
        while (!screenAd.IsLoaded())
        {
            yield return null;

        }
        screenAd.Show();
    }
}
