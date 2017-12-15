using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoreTrigger : MonoBehaviour 
{
    private GameDataProxy dataProxy;
    private bool isStartGame;

    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        dataProxy = Facade.Instance.RetrieveProxy(GameDataProxy.NAME) as GameDataProxy;
    }

    public void StartGame()
    {
        isStartGame = true;
    }

    public void StopGame()
    {
        isStartGame = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isStartGame)
        {
            dataProxy.UpdateScore();
        }
    }
}
