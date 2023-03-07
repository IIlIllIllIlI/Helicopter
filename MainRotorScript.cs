using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRotorScript : MonoBehaviour
{
    private float rotationSpeed;
    private float deceleration = 4;
    private float resistanceRation = 0.02f;
    private float acceleration = 6;

    // Start is called before the first frame update
    void Start()
    {
        //acceleration = 5;
        rotationSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            accelerate();
        } 
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            decelerate();
        }
        slowDown();

        Vector3 rotation = Vector3.up * rotationSpeed;
        transform.Rotate(rotation);
    }

    private void accelerate()
    {
        rotationSpeed += acceleration * Time.deltaTime;
        // Debug.Log(rotationSpeed);
    }

    private void decelerate()
    {
        if (rotationSpeed > 0)
        {
            rotationSpeed -= deceleration * Time.deltaTime;
            // Debug.Log(rotationSpeed);
        }
    }

    private void slowDown()
    {
        if (rotationSpeed > 0)
        {
            // 空气阻力与速度的平方成正比
            rotationSpeed -= resistanceRation * rotationSpeed 
                * rotationSpeed * Time.deltaTime;

            // Debug.Log(rotationSpeed);
        }
    }

    public float getRotationSpeed()
    {
        return rotationSpeed;
    }
}
