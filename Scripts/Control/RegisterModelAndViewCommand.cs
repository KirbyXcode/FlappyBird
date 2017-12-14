using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;

public class RegisterModelAndViewCommand : SimpleCommand 
{
    public override void Execute(INotification notification)
    {
        Facade.RegisterProxy(new GameDataProxy());
        Facade.RegisterMediator(new GameMediator());
    }
}
