using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using GooglePlayGames;

public class LobbyManager : MonoBehaviour
{
    public Text PlayerNickname;

    void Start()
    {
        PlayerNickname.text = Social.localUser.userName;
    }

    void Update()
    {
        
    }
}
