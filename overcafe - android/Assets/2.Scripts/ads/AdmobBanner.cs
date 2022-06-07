using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobBanner : MonoBehaviour
{
    public static AdmobBanner instance
    {
        get
        {
            if (B_instance == null)
            {
                B_instance = FindObjectOfType<AdmobBanner>();
                
            }

            return B_instance;
        }
    }

    private static AdmobBanner B_instance;
    private readonly string unitID = "ca-app-pub-4697644976729834/5975816688";
    private readonly string test_unitID = "ca-app-pub-3940256099942544/6300978111";

    private readonly string test_deviceID = "ca-app-pub-3940256099942544/6300978111";

    private BannerView banner;

    public AdPosition position;
    //private string isbanner;
    private int getbanner;

    private void Awake()
    {

        InitAd();

    }

    private void Update()
    {

    }

    private void InitAd()
    {

        string id = unitID;

        banner = new BannerView(id, AdSize.SmartBanner, position);

        AdRequest request = new AdRequest.Builder().Build();
        
        banner.LoadAd(request);

        
    }

    public void ToggleAd(bool active)
    {
        if (active)
        {
            banner.Show();

        }
        else
        {
            banner.Hide();
        }
    }

    public void DestroyAd()
    {
        banner.Destroy();
    }
    
}
