using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    protected float moveSpeed;


    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void MoveCarInPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void MoveCar(Vector3 direction)
    {
        transform.position += direction * moveSpeed;
    }
}
