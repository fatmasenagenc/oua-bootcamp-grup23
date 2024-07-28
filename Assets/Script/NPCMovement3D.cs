using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement3D : MonoBehaviour
{
    public float moveSpeed = 2f; // Hareket hýzý
    public float moveDistance = 50f; // Hareket mesafesi arttýrýldý

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingToTarget = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.right * moveDistance;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (movingToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.10f)
            {
                movingToTarget = false;
                Flip();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPosition) < 0.100f)
            {
                movingToTarget = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        // Karakterin yüzünü döndür
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
