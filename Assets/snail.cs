using UnityEngine;
using System.Collections.Generic;

public class Snail : MonoBehaviour
{
    public Transform path;
    List<Vector3> targets = new List<Vector3>(); 
    private int currentTargetIndex = 0;

    // Speed of snail
    public float speed = 2.0f;

    // Rotation speed of snail
    public float rollSpeed = 100.0f;

    void Start()
    {
        targets.Add(new Vector3(4, -4, 0));  
        targets.Add(new Vector3(6, 3, 0));
        targets.Add(new Vector3(-7, -1, 0));
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Vector3 currentTarget = targets[currentTargetIndex]; 

        // Calculate direction to current target
        Vector3 direction = (currentTarget - transform.position).normalized;

        // Move snail towards current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Calculate angle of rotation based on movement direction
        Quaternion rotation = Quaternion.FromToRotation(Vector3.right, direction);
        float angle = rotation.eulerAngles.z;
        // Rotate snail along its forward axis (rolling motion)
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Check if snail has reached the current target
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
        }
    }
}