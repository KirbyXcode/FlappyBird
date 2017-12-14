using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PipesAndLandTrigger : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Facade.Instance.SendNotification(Define.Reg_EndGameCommand);
        }
    }
}
