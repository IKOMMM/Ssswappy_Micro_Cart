using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    [SerializeField] private float carSpeed = 10f;
    [SerializeField] private float carSpeedIncrease = 0.15f;

    [SerializeField] private int carSteerValue = 250;
    [SerializeField] private int steerValue = 250;


        
    void Update()
    {
        //Speed Increase
        carSpeed += carSpeedIncrease * Time.deltaTime;
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
        //Car Rotation
        transform.Rotate(0f, steerValue * carSteerValue * Time.deltaTime, 0f);
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
