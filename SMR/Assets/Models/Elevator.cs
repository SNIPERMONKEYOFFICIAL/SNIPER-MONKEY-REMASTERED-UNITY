using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveUpDistance = 5f;
    public float moveDownDistance = 5f;
    public float moveDownSpeed = 1f;
    public float delayTime = 2f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool movingUp = true;
    private float delayTimer = 0f;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector3.up * moveUpDistance;
    }

    void Update()
    {
        if (movingUp) // If elevator is moving up
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                delayTimer += Time.deltaTime;
                if (delayTimer >= delayTime)
                {
                    movingUp = false;
                    targetPosition = initialPosition + Vector3.down * moveDownDistance;
                    delayTimer = 0f;
                }
            }
        }
        else // If elevator is moving down
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDownSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                delayTimer += Time.deltaTime;
                if (delayTimer >= delayTime)
                {
                    movingUp = true;
                    targetPosition = initialPosition + Vector3.up * moveUpDistance;
                    delayTimer = 0f;
                }
            }
        }
    }
}
