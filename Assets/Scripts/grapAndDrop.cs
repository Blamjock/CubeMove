using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class grapAndDrop : MonoBehaviour
{

    GameObject grabbedObject;
    float grabbedObjectSize;
    public int range_grap = 10;
    public GameObject cubo;

    void Update()
    {

        GameObject pippo = transform.FindChild("pippo").gameObject;

        //Debug.DrawLine(transform.position, pippo.transform.position, Color.green);

        RaycastHit ray;
        if (Physics.Raycast(transform.position, pippo.transform.position - transform.position, Mathf.Infinity, 1 << 8))
        {
            Debug.Log("true");
            if (Input.GetKey("right"))
            {
                cubo.transform.position = new Vector3(cubo.transform.position.x - 1f, cubo.transform.position.y, cubo.transform.position.z);
            }
            else if (Input.GetKey("left"))
            {
                cubo.transform.position = new Vector3(cubo.transform.position.x + 1f, cubo.transform.position.y, cubo.transform.position.z);
            }
            else if (Input.GetMouseButton(1))
            {
                cubo.transform.position = new Vector3(cubo.transform.position.x, cubo.transform.position.y, cubo.transform.position.z+1f);
            }
            else if (Input.GetMouseButton(0))
            {
                cubo.transform.position = new Vector3(cubo.transform.position.x, cubo.transform.position.y, cubo.transform.position.z-1f);
            }
            
        }



    }
}
