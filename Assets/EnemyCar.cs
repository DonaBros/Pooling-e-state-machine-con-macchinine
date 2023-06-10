using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : Car
{
    void Update()
    {
        MoveCar(new Vector3(-1f, 0, 0));
        DestroyIfOutOfRoad();
    }

    private void DestroyIfOutOfRoad()
    {
        if(transform.position.x <= -11f)
        {
            gameObject.SetActive(false);
        }
    }
}
