using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float minY;
    private float offset;

    private void Start()
    {
        minY = transform.position.y - target.position.y;
    }

    private void Update()
    {
        if (target.position.y < minY)
        {
            minY = target.position.y;
            transform.position = new Vector3(transform.position.x, minY + offset, transform.position.z);
        }
    }
}
