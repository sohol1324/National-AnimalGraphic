using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using GooglePlayGames;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public Text test;

    void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        GoogleLogin();
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void GoogleLogin()
    {
        Social.localUser.Authenticate((bool sucess) =>
        {
            if(sucess)
            {
                test.text = Social.localUser.id + " + 구글 로그인 성공\n" + Social.localUser.userName;
                PlayFabLogin();
            }
            else
            {
                test.text = "실패";
            }
        });
    }

    public void PlayFabLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = Social.localUser.id + "@rand.com", Password = Social.localUser.id };
        PlayFabClientAPI.LoginWithEmailAddress(request, (result) => { test.text = "플레이팹 로그인 성공\n" + Social.localUser.userName; SceneManager.LoadScene("LobbyScene"); }, (error) => PlayFabRegister());
    }

    public void PlayFabRegister()
    {
        var request = new RegisterPlayFabUserRequest { Email = Social.localUser.id + "@rand.com", Password = Social.localUser.id, Username = Social.localUser.userName };
        PlayFabClientAPI.RegisterPlayFabUser(request, (result) => { test.text = "플레이팹 회원가입 성공"; PlayFabLogin(); NewUserSetting(); }, (error) => test.text = "플레이팹 회원가입 실패");
    }

    void NewUserSetting()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "TierPoint", Value = 0},
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, (result) => print(""), (error) => print(""));
    }
}
