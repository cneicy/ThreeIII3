using Net.Client;
using Net.UnityComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=8f;
    public bool isLocalPlayer=false;
    void Start()
    {
    }
    void Update()
    {
        if (isLocalPlayer) Movement();;
    }
    void Movement()
    {
        rb.velocity = new Vector2(0, 0);
        float horizontalmove = Input.GetAxis("Horizontal");
        float verticalmove = Input.GetAxis("Vertical");
        if (horizontalmove != 0 || verticalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed);
        }
    }
}
