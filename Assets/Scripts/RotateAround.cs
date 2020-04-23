using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = -speed;
        }
    }

    void FixedUpdate()
    {
        transform.RotateAround(target.position, zAxis, -speed);
    }
}
