using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour 
{
    private GameDataProxy dataProxy;

    public void StartGame()
    {
        dataProxy = Facade.Instance.RetrieveProxy(GameDataProxy.NAME) as GameDataProxy;
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
