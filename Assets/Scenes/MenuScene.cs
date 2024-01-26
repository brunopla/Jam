using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement; //libreria para usar funciones de sceneManager

public class MenuScene : MonoBehaviour
{
    public GameObject menu;  // Asegúrate de asignar tu objeto de menú en el inspector de Unity
    private string escenaActual;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menu.activeSelf)
        {
            escenaActual = SceneManager.GetActiveScene().name;
            menu.SetActive(true);
            SceneManager.LoadScene("menu principal");
        }
    }

    public void JugarJuego()
    {
        SceneManager.LoadScene("Escena principal");
    }

    public void Volver()
    {
        menu.SetActive(false);
        SceneManager.LoadScene(escenaActual);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
