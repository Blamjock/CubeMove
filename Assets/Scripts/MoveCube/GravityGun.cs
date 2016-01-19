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
    public float CubeAngle = 90.0f;

    private Transform target;
    private bool active= false;
    //Oggetto bersaglio indicato dal Raycast
    RaycastHit hit;
    RaycastHit hit2;
    RaycastHit hit3;
    RaycastHit hitBlink;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        /********************************************
         ********************* AZIONI PLAYER ********
        *********************************************/
        //TASTO E
        if (Input.GetKey(KeyCode.E) && active == false)
        {
            Ray ray4 = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray4, out hitBlink, DistanceRaycast, 1 << 8))
            {
                Vector3 TObbiettivo = hitBlink.transform.position;
                Vector3 TPlayer = player.transform.position;
                player.transform.position = TObbiettivo;
                hitBlink.transform.position = TPlayer;
                Debug.Log("you select the " + hitBlink.transform.name);
            }
        }
        //TASTO Mouse ScrollWheel 
        //ROTAZIONE DEL CUBO IN MANO AVANTI INDIETRO
        if (active == true)
        {
            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f)
            {
                Debug.Log("scrolla su");
                // scroll up
                hit.transform.Rotate(Vector3.forward, CubeAngle);
                Debug.Log("scrolla di "+ CubeAngle);
            }
            else if (d < 0f)
            {
                // scroll down
                Debug.Log("scrolla giu");
                hit.transform.Rotate(Vector3.forward, -CubeAngle);
                Debug.Log("scrolla di " + CubeAngle);
            }
        }
        if (active == false)
        {
            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f)
            {
                Debug.Log("scrolla su");
                // scroll up
                Ray rayMoveCube = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayMoveCube, out hit3, DistanceRaycast, 1 << 8))
                {
                    hit3.transform.position = new Vector3(hit3.transform.position.x - 1f, hit3.transform.position.y, hit3.transform.position.z);
                }
            }
            else if (d < 0f)
            {
                // scroll down
                Debug.Log("scrolla giu");
                Ray rayMoveCube = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayMoveCube, out hit3, DistanceRaycast, 1 << 8))
                {
                    hit3.transform.position = new Vector3(hit3.transform.position.x + 1f, hit3.transform.position.y, hit3.transform.position.z);
                }
            }
        }

        //TASTO O
        if (Input.GetKey(KeyCode.O) && active == false)
        {
            Ray rayMoveCube = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayMoveCube, out hit3, DistanceRaycast, 1 << 8))
            {
                hit3.transform.position = new Vector3(hit3.transform.position.x - 1f, hit3.transform.position.y, hit3.transform.position.z);
            }
              
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

        //TASTO I 
        //conrollo della posizione del player
        if (Input.GetKeyDown(KeyCode.I) )
        {
            Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray3, out hit3, DistanceRaycast, 1 << 8))
            {
                Vector3 TObbiettivo = hit3.transform.position;
                Vector3 TPlayer = player.transform.position;
                Debug.Log("you select the " + hit3.transform.name);             

                if (TPlayer.z > TObbiettivo.z+1.0f)
                {
                    Debug.Log("PG A SINISTRA");
                }
                if (TPlayer.z < TObbiettivo.z -1.0f)
                        {
                    Debug.Log("PG A DESTRA");
                }
                if (TPlayer.x > TObbiettivo.x + 1.0f)
                {
                    Debug.Log("PG DIETRO");
                }
                if (TPlayer.x < TObbiettivo.x - 1.0f)
                {
                    Debug.Log("PG DAVANTI");
                }
                if (TPlayer.y > TObbiettivo.y + 1.0f)
                {
                    Debug.Log("PG ALTO");
                }
                if (TPlayer.y < TObbiettivo.y - 1.0f)
                {
                    Debug.Log("PG BASSO");
                }
                Debug.Log("COORDINATE PLAYER "+ player.transform.position+" coordinate obbiettivo " + hit3.transform.position);
                // --- Modifica il colore del'oggetto selezionato con il recast
                hit3.transform.GetComponent<Renderer>().materials[0].color=new Color(1.0f,1.0f,1.0f,1.0f);
                
                
                //Debug.Log("MATERIALE "+a);

              //  hit.transform.GetComponent<Rigidbody>().useGravity = true;
            }
            Debug.Log("----------------------------------------------");
        }

        /********************************************
         **********ANCORAGGIO E SBLOCCO CUBO ********
        *********************************************/

        //CLIC MOUSE SINISTRO
        if (Input.GetMouseButtonDown(0) && active==false)
        {
            
            //Debug.Log("PREMUTO MOUSE sinistro");
            Debug.Log("PREMUTO MOUSE sinistro ****************** Active " + active);
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
                hit.transform.GetComponent<Renderer>().materials[0].color = new Color(5.0f, 5.0f, 5.0f, 5.0f);
                active = true;
            } else
                Debug.Log("L active is: " + active);
        }

        /*---------------------------------
        CLIC MOUSE DESTRO 
        RILASCIO DEL CUBO VERSO UNA DIREZIONE
        ------------------------------------
        */
        if (Input.GetMouseButtonDown(1) && active == true)
        {
            
            Debug.Log("Ripremuto tasto sinistro ************************ " + active);
           
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
                //****************************************
                //INDIVIDUARE POSIZIONE DEL PLAYER e ANCORAGGIO CUBO
                        Vector3 TObbiettivo = hit2.transform.position;
                        Vector3 TPlayer = player.transform.position;
                        Debug.Log("you select the " + hit2.transform.name);

                        if (TPlayer.z > TObbiettivo.z + 1.0f)
                        {
                            Debug.Log("PG A SINISTRA");
                            Vector3 hit2T = TObbiettivo;
                            hit2T.z += 1.0f;
                            hit.transform.position = hit2T;
                        }
                        if (TPlayer.z < TObbiettivo.z - 1.0f)
                        {
                            Debug.Log("PG A DESTRA");
                            Vector3 hit2T = TObbiettivo;
                            hit2T.z -= 1.0f;
                            hit.transform.position = hit2T;
                            Debug.Log("*Coordinate finali cubo *" + hit.transform.position);
                }
                        if (TPlayer.x > TObbiettivo.x + 1.0f)
                        {
                            Debug.Log("PG DIETRO");
                            Vector3 hit2T = TObbiettivo;
                            hit2T.x += 1.0f;
                            hit.transform.position = hit2T;
                            Debug.Log("*Coordinate finali cubo *"+ hit.transform.position);
                }
                        if (TPlayer.x < TObbiettivo.x - 1.0f)
                        {
                            Debug.Log("PG DAVANTI");
                            Vector3 hit2T = TObbiettivo;
                            hit2T.x -= 1.0f;
                            hit.transform.position = hit2T;
                            Debug.Log("*Coordinate finali cubo *" + hit.transform.position);
                }
                      /*  if (TPlayer.y > TObbiettivo.y + 1.0f)
                        {
                            Debug.Log("PG ALTO");
                            Vector3 hit2T = TObbiettivo;
                            hit2T.y -= 1.0f;
                            hit.transform.position = hit2T;
                            Debug.Log("*Coordinate finali cubo *" + hit.transform.position);
                }
                        if (TPlayer.y < TObbiettivo.y - 1.0f)
                        {
                            Debug.Log("PG BASSO");
                            Vector3 hit2T = TObbiettivo;
                            hit2T.y -= 1.0f;
                            hit.transform.position = hit2T;
                            Debug.Log("*Coordinate finali cubo *" + hit.transform.position);
                }
                */
                //****************************************

                // --- attiva l'opzione use gravity nel rigitbody dell'oggetto agganciato ---
                //hit.transform.GetComponent<Rigidbody>().useGravity = true;

               // Vector3 hit2T = hit2.transform.position;
               // hit2T.z += 1.0f;
               // Debug.Log("HIT2T position" + hit2T);
                // --- Muovi il cubo verso il bersaglio ---

                // hit.transform.position = Vector3.MoveTowards(hit.transform.position, hit2T, Power*Time.deltaTime);
               // hit.transform.position =  hit2T;

                // --- scala il cubo quando lo prende ---
                hit.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                // --- porta gli assi di rotazione a 0
                hit.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
                Debug.Log("OGGETTO NON TROVATO ");
            Debug.Log("you select HIT position FINAL " + hit.transform.position);
        }
    }
}
