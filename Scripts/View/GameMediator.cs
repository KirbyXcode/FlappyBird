using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SUIFW;
using PureMVC.Interfaces;

public class GameMediator : Mediator 
{
    public new const string NAME = "GameMediator";

    private Text mText_Time;
    private Text mText_TimeValue;

    private Text mText_Best;
    private Text mText_BestValue;

    private Text mText_Score;
    private Text mText_ScoreValue;

    public GameMediator():base(NAME)
    {

    }

    private void InitComponent()
    {
        GameObject uiRoot = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS);

        mText_Time = UnityHelper.GetChildComponent<Text>(uiRoot, "Time");
        mText_TimeValue = UnityHelper.GetChildComponent<Text>(uiRoot, "TimeValue");

        mText_Best = UnityHelper.GetChildComponent<Text>(uiRoot, "Best");
        mText_BestValue = UnityHelper.GetChildComponent<Text>(uiRoot, "BestValue");

        mText_Score = UnityHelper.GetChildComponent<Text>(uiRoot, "Score");
        mText_ScoreValue = UnityHelper.GetChildComponent<Text>(uiRoot, "ScoreValue");

        mText_Time.text = "时间：";
        mText_Best.text = "最高分：";
        mText_Score.text = "分数：";
    }

    public override IList<string> ListNotificationInterests()
    {
        IList <string> result = new List<string>();
        result.Add(Define.Msg_DisplayGameInfo);
        result.Add(Define.Msg_InitGameMediator);
        return result;
    }

    public override void HandleNotification(INotification notification)
    {
        GameData data = null;

        switch (notification.Name)
        { 
            case Define.Msg_InitGameMediator:
                InitComponent();
                break;
            case Define.Msg_DisplayGameInfo:
                data = notification.Body as GameData;
                if (data != null)
                {
                    if (mText_TimeValue && mText_BestValue && mText_ScoreValue) 
                    {
                        mText_TimeValue.text = data.Time.ToString();
                        mText_BestValue.text = data.BestScore.ToString();
                        mText_ScoreValue.text = data.Score.ToString();
                    }
                }
                break;
        }
    }
}
