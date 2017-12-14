using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDataProxy : Proxy 
{
    public new const string NAME = "GameDataProxy";
    private GameData data;

    public GameDataProxy() : base(NAME)
    {
        data = new GameData();

        data.BestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void InitGameData()
    {
        SendNotification(Define.Msg_DisplayGameInfo, data);
    }

    public void AddTime()
    {
        ++data.Time;
        SendNotification(Define.Msg_DisplayGameInfo, data);
    }

    public void UpdateScore()
    {
        ++data.Score;

        GetBestScore();
    }

    public int GetBestScore()
    {
        if(data.Score > data.BestScore)
        {
            data.BestScore = data.Score;
        }

        return data.BestScore;
    }

    public void SaveBestScore()
    {
        if (data.Score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", data.Score);
        }
    }
}
