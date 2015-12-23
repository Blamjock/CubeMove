using UnityEngine;
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
}