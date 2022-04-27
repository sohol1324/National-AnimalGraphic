using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class RankManager : MonoBehaviour
{
    public Text PlayerRank_Text;
    public Image[] PlayerRanking_FlagImage;

    void Start()
    {
        InvokeRepeating("GetLeaderboard", 0.0f, 5.0f);
    }

    void Update()
    {

    }

    void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "TierPoint", MaxResultsCount = 20, ProfileConstraints = new PlayerProfileViewConstraints() { ShowLocations = true, ShowDisplayName = true } };
        PlayFabClientAPI.GetLeaderboard(request, (result) =>
        {
            PlayerRank_Text.text = "";
            for (int i = 0; i < result.Leaderboard.Count; i++)
            {
                var curBoard = result.Leaderboard[i];
                PlayerRank_Text.text += i+1 + "위 / " + curBoard.Profile.Locations[0].CountryCode.Value + " / " + curBoard.DisplayName + " / 포인트 : " + curBoard.StatValue + "\n";
                PlayerRanking_FlagImage[i].gameObject.SetActive(true);
                PlayerRanking_FlagImage[i].sprite = Resources.Load<Sprite>(curBoard.Profile.Locations[0].CountryCode.Value.ToString().ToLower());
            }
        },
        (error) => print(""));
    }
}
