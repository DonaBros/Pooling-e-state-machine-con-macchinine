using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCar : Car
{
    [SerializeField] private float basePlayerMovespeed;
    [SerializeField] private Vector3 startingPosition;

    private void Awake()
    {
        MoveCarInPosition(startingPosition);
        moveSpeed = basePlayerMovespeed;
    }

    void Update()
    {
        MoveCar(GetInputDirection());
    }

    private Vector3 GetInputDirection()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return new Vector3(1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return new Vector3(-1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return new Vector3(0, 1f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            return new Vector3(0, -1f, 0);
        }
        return new Vector3(0, 0, 0);
    }

}
