using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour 
{
    public float upPower = 3f;
    private Rigidbody2D rb;
    private Vector3 originalPos;
    private bool life;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = transform.position;
        rb.isKinematic = true;
    }

    public void StartGame()
    {
        life = true;
        rb.isKinematic = false;
        transform.position = originalPos;
    }

    public void StopGame()
    {
        life = false;
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (life)
        {
            if (Input.GetButton("Fire1"))
            {
                rb.velocity = Vector2.up * upPower;
            }
        }
    }
}
