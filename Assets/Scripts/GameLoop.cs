using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public static GameLoop instance;
    public float tiempoCinematica;

    public float humorActual = 500, seriedadActual = 500;
    public float humorMult = 1, seriedadMult = 1;

    public  float maxHumor = 1000, maxSeriedad = 1000;
    public float multiplicadorRisa = 1, multiplicadorSeriedad=1;

    public Image panelPerder;
    [SerializeField] Publico publico;
    private void Awake()
    {
        instance = this;
        
    }
    public IEnumerator Start()
    {
        publico.GenerarPublico(10);
        yield return new WaitForSeconds(tiempoCinematica);
        //player.velocidad = 10;
        while (true)
        {
            yield return new WaitForSeconds(3);

            humorActual -= humorMult; 
            seriedadActual += seriedadMult;
            UISystem.instance.UpdateUI();
            if (seriedadActual >= maxSeriedad || humorActual >= maxHumor) StartCoroutine(Perder());
        }        
    }
    public IEnumerator Perder()
    {
        print("has perdido");
        // mostrar pantalla de perder 
        panelPerder.DOColor(new Color(1, 1, 1, 1), 1);

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
        yield break;
    }

    public void IncrementarHumor(int cantidad)
    {
        if((humorActual + cantidad) <= maxHumor)
        {
            humorActual += cantidad;
        }
        else
        {
            humorActual = maxHumor;
        }
    }

    public void IncrementarSeriedad(int cantidad)
    {
        if((seriedadActual + cantidad) <= maxSeriedad)
        {
            seriedadActual += cantidad;
        }
        else
        {
            seriedadActual = maxSeriedad;
        }
    }
}
