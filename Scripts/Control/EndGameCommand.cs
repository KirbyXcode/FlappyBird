using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using SUIFW;

public class EndGameCommand : SimpleCommand 
{
    public override void Execute(INotification notification)
    {
        StopScriptsRuning();

        CloseGamePanel();

        SaveBestScore();

        ResetData();
    }

    private void StopScriptsRuning()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>().StopGame();

        GameObject env = GameObject.Find("Env");

        UnityHelper.FindChild(env, "Landing").GetComponent<LandMovement>().StopGame();
        UnityHelper.FindChild(env, "PipesRoot").GetComponent<PipesMovement>().StopGame();

        env.GetComponent<TimeController>().StopGame();

        for (int i = 1; i <= 3; i++)
        {
            UnityHelper.GetChildComponent<ScoreTrigger>(env, "Pipe" + i + "_Trigger").StopGame();
        }
    }

    private void CloseGamePanel()
    {
        UIManager.Instance.CloseOrReturnUIForms(UIPanelType.GamePanel.ToString());
    }

    private void SaveBestScore()
    {
        GameDataProxy dataProxy = Facade.RetrieveProxy(GameDataProxy.NAME) as GameDataProxy;
        dataProxy.SaveBestScore();
    }

    private void ResetData()
    {
        GameDataProxy dataProxy = Facade.RetrieveProxy(GameDataProxy.NAME) as GameDataProxy;
        dataProxy.ResetData();
    }
}
