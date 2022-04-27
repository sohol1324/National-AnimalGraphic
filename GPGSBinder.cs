using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Events;


public class GPGSBinder
{
    static GPGSBinder inst = new GPGSBinder();
    public static GPGSBinder Inst => inst;

    ISavedGameClient SavedGame =>
        PlayGamesPlatform.Instance.SavedGame;

    IEventsClient Events =>
        PlayGamesPlatform.Instance.Events;

    void Init()
    {
        var config = new PlayGamesClientConfiguration.Builder().RequestServerAuthCode(false).RequestIdToken().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }
}