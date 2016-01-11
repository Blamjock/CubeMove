using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Canvas MainCanavas;
 
    public void ReturnOn()
    {
        MainCanavas.enabled = true;
    }

    public void LoadOn()
    {
        Application.LoadLevel(1);
    }

    public void OnGUI()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
