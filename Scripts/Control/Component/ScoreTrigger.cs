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
    }

    public void StartGame()
    {
        dataProxy = Facade.Instance.RetrieveProxy(GameDataProxy.NAME) as GameDataProxy;
        isStartGame = true;
    }

    public void StopGame()
    {
        isStartGame = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dataProxy.UpdateScore();
        }
    }
}
