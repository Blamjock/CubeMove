using UnityEngine;
using System.Collections;
//Script per la creazione delle sfere luminose dal player
public class LuceDown : MonoBehaviour {
	public GameObject stonePrefab;
	public Transform Spawn;


	
	// Update is called once per frame
	void Update () 
	{
			if (Input.GetKeyDown(KeyCode.F))
			{
			    stonePrefab = Instantiate(stonePrefab, Spawn.transform.position, Quaternion.identity) as GameObject;
			}
		}
		/* Codice non utilizzato ma possibilita' di riutilizzo
        if (Input.GetKey(KeyCode.E))
		{
		
			//public GameObject EnemyPrefab;
			//public Transform[] spawnPoint;
			//EnemyPrefab = Instantiate(EnemyPrefab, spawnPoint[range].position, EnemyPrefab.transform.rotation) as GameObject;

			stonePrefab = Instantiate(stonePrefab, Spawn.transform.position, stonePrefab.transform.rotation) as GameObject;
			
		}*/
	
	}




