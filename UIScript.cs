using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    public Text rotationSpeed;
    public GameObject mainRotor;

    private MainRotorScript mainRotorScript;
    // Start is called before the first frame update
    void Start()
    {
        mainRotorScript = mainRotor.GetComponent<MainRotorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed.text = mainRotorScript.getRotationSpeed().ToString();
    }
}
