using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform targetObject;
    public float speed = 6.0f; // Declare and initialize the 'speed' variable
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float stoppingDistance = 3.0f; // Define the stopping distance
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.position); // Calculate the distance to the target

        if (distanceToTarget > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObject.position, speed * Time.deltaTime);
        }
        
    }
}
