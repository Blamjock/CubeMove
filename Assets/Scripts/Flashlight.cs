using UnityEngine;
using System.Collections;
//ATTIVAZIONE E DISATTIVAZIONE DELLA LAMPADA DEL PG
public class Flashlight : MonoBehaviour
{
    Light flashlight;
    public bool on = false;
    // Use this for initialization
    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            on = !on;
        if (on)
            flashlight.enabled = true;
        else if (!on)
            flashlight.enabled = false;
    }
}