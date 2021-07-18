using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarHandler : MonoBehaviour
{
    [SerializeField] private float carSpeed = 10f;
    [SerializeField] private float carSpeedIncrease = 0.15f;

    [SerializeField] private int carSteerValue = 250;
    [SerializeField] private int steerValue = 250;


        
    void Update()
    {
        //Car Rotation
        transform.Rotate(0f, steerValue * carSteerValue * Time.deltaTime, 0f);

        //Speed Increase
        carSpeed += carSpeedIncrease * Time.deltaTime;
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);        
    }

    public void Steer(int value)
    {
        steerValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")//other.CompaerTag("Enenemy")
        {
            SceneManager.LoadScene(1);
        }
    }
}
