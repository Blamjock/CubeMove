using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReturnMainMenu : MonoBehaviour
{
    public Canvas MainCanavas;

    public void ReturnOn()
    {
        MainCanavas.enabled = true;
    }

    public void LoadOn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnGUI()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

