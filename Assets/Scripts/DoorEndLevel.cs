using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorEndLevel : MonoBehaviour {
    public GameObject player;

    void OnTriggerEnter ()
    {
        if (player = GameObject.FindWithTag("Player"))
        {

            SceneManager.LoadScene("YouWinScene");
        }
    }

}
