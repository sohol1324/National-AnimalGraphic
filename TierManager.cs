using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class TierManager : MonoBehaviour
{
    public int PlayerTierPoint;
    public Sprite[] Tiers;
    public Image TierImage;
    public Text TierText;

    void Start()
    {
        GetTierData();       
    }

    void Update()
    {
        SetTierImage();
    }

    public void SetTierData()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "TierPoint", Value = PlayerTierPoint},
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, (result) => print(""), (error) => print(""));
    }

    public void GetTierData()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(), (result) =>
            {
                foreach (var eachStat in result.Statistics)
                {
                    if(eachStat.StatisticName == "TierPoint")
                    {
                        PlayerTierPoint = eachStat.Value;
                    }
                }
            },
            (error) => print(""));
    }

    public void SetTierImage()
    {
        if(PlayerTierPoint <= 399)
        {
            TierImage.sprite = Tiers[0];
            TierText.text = "브론즈";
        }
        if(PlayerTierPoint >= 400 && PlayerTierPoint <= 799)
        {
            TierImage.sprite = Tiers[1];
            TierText.text = "실버";
        }
        if (PlayerTierPoint >= 800 && PlayerTierPoint <= 1199)
        {
            TierImage.sprite = Tiers[2];
            TierText.text = "골드";
        }
        if (PlayerTierPoint >= 1200 && PlayerTierPoint <= 1599)
        {
            TierImage.sprite = Tiers[3];
            TierText.text = "플레티넘";
        }
        if (PlayerTierPoint >= 1600 && PlayerTierPoint <= 1999)
        {
            TierImage.sprite = Tiers[4];
            TierText.text = "다이아";
        }
        if (PlayerTierPoint >= 2000)
        {
            TierImage.sprite = Tiers[5];
            TierText.text = "킹";
        }
    }
}
