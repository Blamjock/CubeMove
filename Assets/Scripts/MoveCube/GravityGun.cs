using UnityEngine;
using System.Collections;

public class GravityGun : MonoBehaviour {

    public float rootSpeed = 0.0f;
    public float PosY = 0.0f;
    public float DistanceRaycast = 10.0f;
    public Transform SpawnCube;
    public Transform HandCube;

    private Transform target;
    private bool active= false;
    //Oggetto bersaglio indicato dal Raycast
    RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //TASTO K
        if (Input.GetKey(KeyCode.K) && active==true)
        {
            hit.transform.Rotate(Vector3.down, 10.0f);
            Debug.Log("PREMUTO K");
        }
        //TASTO O
        if (Input.GetKey(KeyCode.O) && active == true)
        {
            hit.transform.Rotate(Vector3.forward, 10.0f);
            Debug.Log("PREMUTO O");
        }
        //TASTO K
        if (Input.GetKey(KeyCode.L) && active==true)
        {
            hit.transform.Rotate(Vector3.up, 10.0f);
           // hit.transform.RotateAround(hit.transform.localPosition, Vector3.up, rootSpeed * Time.deltaTime);
           // hit.transform.GetComponent<Transform>().RotateAround(hit.transform.position, Vector3.up, rootSpeed * Time.deltaTime);
            Debug.Log("PREMUTO L");
            Debug.Log("Trasform position assoluto oggetto nel target"+ hit.transform.position);
            Debug.Log("Trasform position locale oggetto nel target" + hit.transform.localPosition);
        }

/* 
        --- ANCORAGGIO E SBLOCCO 
*/

        //CLIC MOUSE SINISTRO
        if (Input.GetMouseButtonDown(0) && active==false)
        {
            
            Debug.Log("PREMUTO MOUSE sinistro");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, DistanceRaycast, 1 << 8))
            {
                Debug.Log("you select the " + hit.transform.name);
                active = true;
                Debug.Log("L active is: "+ active);
                //  --- il cubo diventa figlio di Hit (Main Camera) ---
                hit.transform.parent = transform;
                hit.transform.GetComponent<Rigidbody>().useGravity = false;
                float hitPosY = hit.transform.position.y + PosY;

                //hit.transform.position = new Vector3(hit.transform.position.x, hitPosY, hit.transform.position.z);
                // --- modificare la posizione del oggetto indicato dal mouse ---
                //hit.transform.position = new Vector3(hit.transform.position.x, hitPosY, hit.transform.position.z);
                hit.transform.position = new Vector3(HandCube.transform.position.x, HandCube.transform.position.y, HandCube.transform.position.z);

            //  --- scala il cubo quando lo prende ---
                hit.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            } else
                Debug.Log("L active is: " + active);
        }
        //CLIC MOUSE DESTRO
        if (Input.GetMouseButtonDown(1) && active == true)
        {
            active = false;
            Debug.Log("PREMUTO MOUSE DESTRO");
            hit.transform.parent = null;
            // --- attiva l'opzione use gravity nel rigitbody dell'oggetto agganciato ---
            hit.transform.GetComponent<Rigidbody>().useGravity = true;
            // --- scala il cubo quando lo prende ---
            hit.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            hit.transform.position = new Vector3(SpawnCube.transform.position.x, SpawnCube.transform.position.y, SpawnCube.transform.position.z);

        }
    }
}
