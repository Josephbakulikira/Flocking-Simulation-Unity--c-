using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockBehaviour behaviour;
    public Boids boidPrefab;
    List<Boids> boids = new List<Boids>();

    [Range(10, 500)]
    public int startingCount = 100;
    const float boid_density = 0.08f;

    [Range(1f, 200f)]
    public float acceleration = 10f;
    [Range(1f, 200f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusFactor = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get {return squareAvoidanceRadius; } } 

    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusFactor * avoidanceRadiusFactor;

        for (int i = 0; i < startingCount; i++)
        {
            Boids new_boid = Instantiate(boidPrefab, Random.insideUnitCircle * startingCount * boid_density,
                                        Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);

            new_boid.name = "Boid " + i;
            new_boid.Initialize(this);
            boids.Add(new_boid);
        }
    
    }
    private void Update()
    {
        foreach(Boids boid in boids)
        {
            List<Transform> context = GetNeighbors(boid);
            //boid.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            Vector2 move = behaviour.movement(boid, context, this);
            move *= acceleration;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            boid.Move(move);
        }
    }
    List<Transform> GetNeighbors(Boids boid)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextcolliders = Physics2D.OverlapCircleAll(boid.transform.position, neighborRadius);
        foreach(Collider2D other in contextcolliders)
        {
            if (other != boid.BoidCollider)
            {
                context.Add(other.transform);
            }
        }

        return context;
    }
}
