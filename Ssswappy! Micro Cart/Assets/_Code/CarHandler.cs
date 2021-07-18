using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    [SerializeField] private float carSpeed = 10f;
    [SerializeField] private float carSpeedIncrease = 0.15f;

        
    void Update()
    {
        carSpeed += carSpeedIncrease * Time.deltaTime;

        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
    }
}
