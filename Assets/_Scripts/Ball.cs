﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float bounceVariance;
    
    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 startDir = new Vector2(Random.Range(1f, -1f), 1f).normalized;
        rb.velocity = speed * startDir;
	}

    public void Bounce(float variance)
    {
        //Vector2 newVel = rb.velocity;
        //newVel += new Vector2(Random.Range(-bounceVariance, bounceVariance), 
        //                     Random.Range(-bounceVariance, bounceVariance));
        //Vector2 dir = Vector2.Lerp(Vector2.left, Vector2.right, variance).normalized;
        Vector2 dir = new Vector2(Mathf.Lerp(-1, 1, variance), 0.5f).normalized;
        rb.velocity = speed * dir;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.Play("boing");
    }
}
