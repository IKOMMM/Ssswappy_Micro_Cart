using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarHandler : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    private int steerValue;

        
    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;//Speed Increase

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f); //Car Rotation

        transform.Translate(Vector3.forward * speed * Time.deltaTime);    
    }

    public void Steer(int value)
    {
        steerValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))//other.CompaerTag("Enenemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}
