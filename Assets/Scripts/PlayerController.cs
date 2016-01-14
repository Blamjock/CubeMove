/*using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public string playerForward;
	public string playerStrafeRight;
	public string playerStrafeLeft;
	public string playerBackward;
	public string playerJump;
	public float playerMovementSpeed;
	public float playerRotationSpeed;
	
	// Use this for initialization
	void Start () {
		playerForward = "w";
		playerStrafeRight = "d";
		playerStrafeLeft = "a";
		playerBackward = "s";
		playerJump = "space";
		playerMovementSpeed = 5.0f;
		playerRotationSpeed = 15.0f;
	}
	
	// Update is called once per frame
	void Update () {
		playerNavigation ();
	}
	
	// funzioni varie
	//
	// muove il giocatore secondo XZ partendo da tasti customizabili (default WASD)
	void playerNavigation (){
		if (Input.GetKey(playerForward)) {
			transform.Translate (0, 0, playerMovementSpeed * Time.deltaTime, Space.Self);
			Debug.Log ("w");	
		} else if(Input.GetKey(playerStrafeRight)) {
			transform.Translate (playerMovementSpeed * Time.deltaTime, 0, 0, Space.Self);
			Debug.Log ("d");			
		} else if (Input.GetKey(playerStrafeLeft)) {
			transform.Translate (-playerMovementSpeed * Time.deltaTime, 0, 0, Space.Self);
			Debug.Log ("a");			
		} else if (Input.GetKey(playerBackward)) {
			transform.Translate (0, 0, -playerMovementSpeed * Time.deltaTime, Space.Self);
			Debug.Log ("s");		
		} else if (Input.GetKeyDown(playerJump)) {
			Debug.Log ("space");
		}
	}
}*/
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        /*GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);*/
    }
}