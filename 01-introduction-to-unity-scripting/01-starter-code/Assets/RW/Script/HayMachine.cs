using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed = 4f;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    public float horizontalBoundary = 22;
    private float shootTimer;

    void Update()
    {
        PerformMovement();
        HandleShooting();
    }

    void PerformMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) 
            {
                transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
            }
            else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) 
            {
                transform.Translate(transform.right * movementSpeed * Time.deltaTime);
            }
    }

    void HandleShooting()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }
}


