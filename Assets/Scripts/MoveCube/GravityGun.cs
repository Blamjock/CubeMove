using UnityEngine;
using System.Collections;

public class GravityGun : MonoBehaviour {

    public float rootSpeed = 0.0f;
    private Transform target;
    RaycastHit hit;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, Vector3.up, -rotSpeed * Time.deltaTime);

        }
        if {Input.GetKey (Key)
                
        }
	}
}
