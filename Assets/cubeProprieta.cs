using UnityEngine;
using System.Collections;

public class cubeProprieta : MonoBehaviour
{
    public Color coloreBase;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CAMBIA COLORE IN BASE AL RAGGIO CHE LANCIA

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        //SE IL RAGGIO TOCCA QUALCOSA A SINISTRA! SONO GIALLO 
        if (Physics.Raycast(transform.position, fwd, 1))
        {
            print("There is something in front of the object!");
            //cambia il colore del cubo quando lo hai in mano
            coloreBase = transform.GetComponent<Renderer>().materials[0].color;
            transform.GetComponent<Renderer>().materials[0].color = new Color(1.0f, 0.92f, 0.016f, 1.0f);
        }
        else
        //ALTRIMENTI SONO BLU
        {
            print("There is something in front of the object!");
            //cambia il colore del cubo quando lo hai in mano
            coloreBase = transform.GetComponent<Renderer>().materials[0].color;
            //Solid blue. RGBA is (0, 0, 1, 1).
            transform.GetComponent<Renderer>().materials[0].color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }
    }
}
