using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement; //libreria para usar funciones de sceneManager

public class MenuScene : MonoBehaviour
{
    public void JugarJuego()
    {
        SceneManager.LoadScene("Escena principal");  
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}
