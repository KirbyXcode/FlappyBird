using SUIFW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel
{
    private void Awake()
    {
        CurrentUIType.UIForms_ShowMode = UIFormsShowMode.HideOther;
    }
}
