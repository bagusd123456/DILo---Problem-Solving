﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;

    [SerializeField]
    public float force = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //direction = new Vector2(15f, 5f);
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * force, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var contactPoint = collision.contacts[0].point;
        Vector2 ballLocation = transform.position;
        var inNormal = (ballLocation - contactPoint).normalized;
        direction = Vector2.Reflect(direction, inNormal);
    }
}
