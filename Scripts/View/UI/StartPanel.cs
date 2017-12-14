using SUIFW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : BasePanel
{
    private void Awake()
    {
        RegisteButtonObjectEvent("Menu", p => ShowUIForms(UIPanelType.TutorialPanel.ToString()));
    }

    private void Start()
    {
        new ApplicationFacade();
    }
}
