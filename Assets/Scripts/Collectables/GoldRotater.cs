using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldRotater : MonoBehaviour
{
    public float rotationSpeed = 50.0f;

    void Update()
    {
        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f, Space.World);
    }
}
