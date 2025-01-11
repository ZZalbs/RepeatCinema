using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GhostMovement : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position);
        var cos = Vector2.Dot(rb.velocity.normalized, direction.normalized);
        var force = direction * (speed * (1.5f - cos / 2) * direction.magnitude);
        rb.AddForce(force, ForceMode2D.Force);
    }
}
