using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Boids : MonoBehaviour
{
    Flock boid_flock;
    public Flock BoidFlock { get { return boid_flock; } }

    Collider2D boid_collider;
    public Collider2D BoidCollider { get { return boid_collider; } }

    void Start()
    {
        boid_collider = GetComponent<Collider2D>();
    }
    public void Initialize(Flock flock)
    {
        boid_flock = flock;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
