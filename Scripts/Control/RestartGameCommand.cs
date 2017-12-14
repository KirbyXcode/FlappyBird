using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using SUIFW;

public class RestartGameCommand : SimpleCommand 
{
    public override void Execute(INotification notification)
    {
        GameObject.FindGameObjectWithTag(Define.Player).GetComponent<BirdController>().StartGame();

        GameObject env = GameObject.Find("Env");

        UnityHelper.FindChild(env, "Landing").GetComponent<LandMovement>().StartGame();
        UnityHelper.FindChild(env, "PipesRoot").GetComponent<PipesMovement>().StartGame();

        env.GetComponent<TimeController>().StartGame();

        for (int i = 1; i <= 3; i++)
        {
            UnityHelper.GetChildComponent<ScoreTrigger>(env, "Pipe" + i + "_Trigger").StartGame();
        }
    }
}
