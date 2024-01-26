using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement; //libreria para usar funciones de sceneManager

public class MenuScene : MonoBehaviour
{
    public GameObject menu;  // Asegúrate de asignar tu objeto de menú en el inspector de Unity
    private string escenaActual;


    public void JugarJuego()
    {
        SceneManager.LoadScene(1);
    }


    public void SalirJuego()
    {
        Application.Quit();
    }
}
