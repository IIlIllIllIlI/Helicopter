using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraScript : MonoBehaviour
{
    public GameObject helicopter;
    private Vector3 deltaPosition;
    // Start is called before the first frame update
    void Start()
    {
        deltaPosition = new Vector3(0, 40, -60);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(helicopter.transform.position);
        transform.position = helicopter.transform.position + deltaPosition;       
    }
}
