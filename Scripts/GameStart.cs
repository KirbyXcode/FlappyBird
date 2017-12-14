using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;

public class GameStart : MonoBehaviour 
{
    private void Start()
    {
        UIManager.Instance.ShowUIForms(UIPanelType.StartPanel.ToString());
    }
}
