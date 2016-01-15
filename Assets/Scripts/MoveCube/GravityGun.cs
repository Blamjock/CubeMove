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
            transform.RotateAround(transform.position, Vector3.up, -rootSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, Vector3.up, rootSpeed * Time.deltaTime);

        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("you select the " + hit.transform.name);
                hit.transform.parent = transform;
                hit.transform.GetComponent<Rigidbody>().useGravity = false;
                float hitPosY = hit.transform.position.y + 2.0f;
                hit.transform.position = new Vector3(hit.transform.position.x, hitPosY, hit.transform.position.z);

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            hit.transform.parent = null;
            hit.transform.GetComponent<Rigidbody>().useGravity = true;

        }
    }
}
