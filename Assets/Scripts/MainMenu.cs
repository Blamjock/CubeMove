using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        SceneManager.LoadScene("Level3");
    }

    public void OnGUI()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
