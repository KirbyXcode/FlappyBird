﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMovement : MonoBehaviour 
{
    public float moveSpeed = 1f;
    private Vector3 originalPos;
    private bool isStartGame;

    void Start()
    {
        originalPos = transform.position;
    }

    public void StartGame()
    {
        isStartGame = true;
    }

    public void StopGame()
    {
        isStartGame = false;
        transform.position = originalPos;
    }

    void Update()
    {
        if (!isStartGame) return;

        if(transform.position.x < -5f)
        {
            transform.position = originalPos;
        }

        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }
}
