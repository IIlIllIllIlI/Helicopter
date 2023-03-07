using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailRotorScript : MonoBehaviour
{
    public GameObject mainRotor;
    private MainRotorScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = mainRotor.GetComponent<MainRotorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = Vector3.right * script.getRotationSpeed();
        transform.Rotate(rotation);
    }
}
