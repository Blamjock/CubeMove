using UnityEngine;
using System.Collections;

public class LuceDown : MonoBehaviour {
	public GameObject stonePrefab;
	public Transform Spawn;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{


			if (Input.GetKeyDown(KeyCode.E))
			{
			stonePrefab = Instantiate(stonePrefab, this.transform.position, Quaternion.identity) as GameObject;

			}
		}
		/*if (Input.GetKey(KeyCode.E))
		{
		
			//public GameObject EnemyPrefab;
			//public Transform[] spawnPoint;
			//EnemyPrefab = Instantiate(EnemyPrefab, spawnPoint[range].position, EnemyPrefab.transform.rotation) as GameObject;

			stonePrefab = Instantiate(stonePrefab, Spawn.transform.position, stonePrefab.transform.rotation) as GameObject;
			
		}*/
	
	}




