using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement; //libreria para usar funciones de sceneManager

public class MenuScene : MonoBehaviour
{
    public GameObject menu;  // Aseg�rate de asignar tu objeto de men� en el inspector de Unity
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
