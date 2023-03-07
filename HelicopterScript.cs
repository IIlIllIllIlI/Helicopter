using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterScript : MonoBehaviour
{
    public float takingoffSpeed = 15;
    private float ascentRatio = 5f;
    private float descendRatio = 10f;

    private bool isFlying;
    private Vector3 verticalVelocity;
    private Vector3 horizontalVelocity;
    private float horizontalMoveAngle = 10;
    private float rotateSpeed = 30;
    private float forwardSpeed = 15;
    private float backwardSpeed = 1;


    public GameObject mainRotor;
    private MainRotorScript mainRotorScript;
    

    // Start is called before the first frame update
    void Start()
    {
        verticalVelocity = Vector3.zero;
        horizontalVelocity = Vector3.zero;
        isFlying = false;
        mainRotorScript = mainRotor.GetComponent<MainRotorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        checkVerticalStatus();

        if (isFlying)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
            } 
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }


            moveHorizontally();
            
        }
        



        transform.Translate(verticalVelocity * Time.deltaTime);
        transform.Translate(horizontalVelocity * Time.deltaTime);
    }


    private void moveHorizontally()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(Vector3.right * horizontalMoveAngle);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            horizontalVelocity = Vector3.forward * forwardSpeed;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.Rotate(Vector3.left * horizontalMoveAngle);
            horizontalVelocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(Vector3.left * horizontalMoveAngle);
        }

        if (Input.GetKey(KeyCode.S))
        {
            horizontalVelocity = Vector3.back * backwardSpeed;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.Rotate(Vector3.right * horizontalMoveAngle);
            horizontalVelocity = Vector3.zero;
        }

    }

    private void checkVerticalStatus()
    {
        float rotationSpeed = mainRotorScript.getRotationSpeed();
        if (!isFlying && rotationSpeed > takingoffSpeed)
        {
            takingOff();
        } else if (isFlying)
        {
            if (rotationSpeed > takingoffSpeed)
            {
                ascent(rotationSpeed - takingoffSpeed);
            } else
            {
                descend(takingoffSpeed - rotationSpeed);
            }
        }
        Debug.Log(rotationSpeed);
    }

    private void takingOff()
    {
        Debug.Log("起飞");
        isFlying = true;
    }

    private void ascent(float deltaSpeed)
    {
        Debug.Log("上升");
        verticalVelocity = Vector3.up * deltaSpeed * ascentRatio;
    }

    private void descend(float deltaSpeed)
    {
        Debug.Log("下降");
        verticalVelocity = Vector3.down * deltaSpeed * descendRatio;

        if (this.transform.position.y < 0.2)
        {
            Debug.Log("着陆");
            transform.position = 
                new Vector3(transform.position.x, 0, transform.position.z);
            verticalVelocity = Vector3.zero;
            isFlying = false;
        }
    }
}
