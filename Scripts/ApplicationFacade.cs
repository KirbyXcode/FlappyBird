using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;

public class ApplicationFacade : Facade 
{
    private GameObject env;

    public ApplicationFacade()
    {
        //RegisterCommand(Define.Reg_StartGameCommand, typeof(StartGameCommand));
        RegisterCommand(Define.Reg_RestartGameCommand, typeof(RestartGameCommand));
        RegisterCommand(Define.Reg_EndGameCommand, typeof(EndGameCommand));

        RegisterProxy(new GameDataProxy());
        RegisterMediator(new GameMediator());

        AddControllerScripts();
        AddTriggerScripts();
    }

    private void AddControllerScripts()
    {
        GameObject.FindGameObjectWithTag(Define.Player).AddComponent<BirdController>();
        env = GameObject.Find("Env");
        UnityHelper.AddChildComponent<LandMovement>(env, "Landing");
        UnityHelper.AddChildComponent<PipesMovement>(env, "PipesRoot");

        env.AddComponent<TimeController>();
    }

    private void AddTriggerScripts()
    {
        for (int i = 1; i <= 3; i++)
        {
            UnityHelper.AddChildComponent<PipesAndLandTrigger>(env, "Pipe" + i + "_Up");
            UnityHelper.AddChildComponent<PipesAndLandTrigger>(env, "Pipe" + i + "_Down");
            UnityHelper.AddChildComponent<PipesAndLandTrigger>(env, "Land" + i);
        }

        for (int i = 1; i <= 3; i++)
        {
            UnityHelper.AddChildComponent<ScoreTrigger>(env, "Pipe" + i + "_Trigger");
        }
    }
}
