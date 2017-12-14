using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameCommand : MacroCommand 
{
    protected override void InitializeMacroCommand()
    {
        AddSubCommand(typeof(RegisterModelAndViewCommand));
        AddSubCommand(typeof(RestartGameCommand));
    }
}
