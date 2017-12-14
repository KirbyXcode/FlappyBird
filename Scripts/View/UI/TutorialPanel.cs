using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;
using System;
using PureMVC.Patterns;

public class TutorialPanel : BasePanel
{
    private void Awake()
    {
        CurrentUIType.UIForms_ShowMode = UIFormsShowMode.HideOther;

        RegisteButtonObjectEvent("StartButton", GameInit);
    }

    private void GameInit(GameObject go)
    {
        ShowUIForms(UIPanelType.GamePanel.ToString());
        Facade.Instance.SendNotification(Define.Reg_StartGameCommand);
    }
}
