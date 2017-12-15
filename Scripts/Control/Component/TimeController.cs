using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour 
{
    private GameDataProxy dataProxy;

    private void Start()
    {
        dataProxy = Facade.Instance.RetrieveProxy(GameDataProxy.NAME) as GameDataProxy;
    }

    public void StartGame()
    {
        StartCoroutine("UpdateTime");
    }

    public void StopGame()
    {
        StopCoroutine("UpdateTime");
    }

    private IEnumerator UpdateTime()
    {
        dataProxy.InitGameData();
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (dataProxy != null) 
            {
                dataProxy.AddTime();
            }
        }
    }
}
