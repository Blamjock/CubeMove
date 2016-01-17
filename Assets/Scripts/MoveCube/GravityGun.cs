using UnityEngine;
using System.Collections;

public class GravityGun : MonoBehaviour {

    public float rootSpeed = 0.0f;
    public float PosY = 0.0f;
    public float DistanceRaycast = 10.0f;
    public Transform SpawnCube;
    public Transform HandCube;
    public float Power = 100.0f;
    public Transform player;
    

    private Transform target;
    private bool active= false;
    //Oggetto bersaglio indicato dal Raycast
    RaycastHit hit;
    RaycastHit hit2;
    RaycastHit hit3;


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

        //conrollo della posizione del player
        if (Input.GetKeyDown(KeyCode.I) )
        {
            Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray3, out hit3, DistanceRaycast, 1 << 8))
            {
                Vector3 TObbiettivo = hit3.transform.position;
                Vector3 TPlayer = player.transform.position;
                Debug.Log("you select the " + hit3.transform.name);
                if (TPlayer.z > TObbiettivo.z)
                {
                    Debug.Log("PG A SINISTRA");
                }
                if (TPlayer.z<TObbiettivo.z )
                        {
                    Debug.Log("PG A DESTRA");
                }
                if (TPlayer.x > TObbiettivo.x )
                {
                    Debug.Log("PG DIETRO");
                }
                if (TPlayer.x < TObbiettivo.x )
                {
                    Debug.Log("PG DAVANTI");
                }
                Debug.Log("COORDINATE PLAYER "+ player.transform.position+" coordinate obbiettivo " + hit3.transform.position);
                

            }
            Debug.Log("----------------------------------------------");
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
                active = true;
            } else
                Debug.Log("L active is: " + active);
        }

        //CLIC MOUSE DESTRO
        if (Input.GetMouseButtonDown(1) && active == true)
        {
            
            Debug.Log("PREMUTO MOUSE DESTRO " +active);
           
            // --- attiva l'opzione use gravity nel rigitbody dell'oggetto agganciato ---
          //  hit.transform.GetComponent<Rigidbody>().useGravity = true;


            // --- Posiziona il cubo in una zona predefinita ---
            //hit.transform.position = new Vector3(SpawnCube.transform.position.x, SpawnCube.transform.position.y, SpawnCube.transform.position.z);

            // --- sparare il cubo con una forza ---
            //hit.transform.GetComponent<Rigidbody>().AddForce(Vector3.right * Power);

            // --- Muovere un ogetto verso un altro 

            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray2, out hit2, DistanceRaycast, 1 << 8))
            {
                active = false;
                Debug.Log("trovato oggetto che serve");
                
                Debug.Log(hit.transform.name + " position" + hit.transform.position);
                Debug.Log(hit2.transform.name+" position" + hit2.transform.position);

                hit.transform.parent = null;
 
                // --- attiva l'opzione use gravity nel rigitbody dell'oggetto agganciato ---
                //hit.transform.GetComponent<Rigidbody>().useGravity = true;
       
                Vector3 hit2T = hit2.transform.position;
                hit2T.z += 1.0f;
                Debug.Log("HIT2T position" + hit2T);
                // --- Muovi il cubo verso il bersaglio ---

                // hit.transform.position = Vector3.MoveTowards(hit.transform.position, hit2T, Power*Time.deltaTime);
                hit.transform.position =  hit2T;

                // --- scala il cubo quando lo prende ---
                hit.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                hit.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
                Debug.Log("OGGETTO NON TROVATO ");
            Debug.Log("you select HIT position FINAL " + hit.transform.position);
        }
    }
}
