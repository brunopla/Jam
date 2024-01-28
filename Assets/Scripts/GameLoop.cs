using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
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

    public bool tieneSalvavidas; // el item lo activa
    public Image panelPerder;
    public  Publico publico;
    private void Awake()
    {
        instance = this;
        
    }
    public IEnumerator Start()
    {
        publico.GenerarPublico(10);
        List<NPC> npcsEnEscena = new();
        publico.personasPublico.ForEach(x => npcsEnEscena.Add(x.GetComponent<NPC>()));
        Player.instance._velocidad = 0;
        yield return new WaitForSeconds(tiempoCinematica);
        Player.instance._velocidad = 5.4f;
        StartCoroutine(CicloOleadas());
        while (true)
        {
            yield return new WaitForSeconds(3);

            humorActual += humorMult; 

            seriedadActual += seriedadMult;

            npcsEnEscena.ForEach(e => e.CambiaDeExpresion());
            UISystem.instance.UpdateUI();
            if (seriedadActual >= maxSeriedad || humorActual >= maxHumor) StartCoroutine(Perder());
        }        
    }
    // determina la activacion de los miniuegos, ademas de los lanzamientos de items a escena
    public float tiempoEntreOleadas = 10;
    public int cantidadDeOleadas;
    private IEnumerator CicloOleadas()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(tiempoEntreOleadas);
            int r = UnityEngine.Random.Range(1, 4) + cantidadDeOleadas;
                for(int  i = 0; i < r; i++)
                {
                int r2 = UnityEngine.Random.Range(0, 10);
                if (r2 > 5) MinijuegosManager.Instance.MinijuegoCompletarLaMitad();
                //else MinijuegosManager.Instance.MinijuegoBarra();
                }
            publico._lanzarItemScr.Lanzar();
            cantidadDeOleadas++;
        }
    }

    public IEnumerator Perder()
    {
        if(tieneSalvavidas)
        {
            if (seriedadActual >= maxSeriedad)
            {
                seriedadActual -= maxSeriedad / 4;
            }
            else
            {
                humorActual -= maxHumor / 4;

            }
            // acercar la camara al jugador, detener al jugador
            for(float  i = 1; i > .25f; i-=.01f, Time.timeScale = i)
                yield return new WaitForSecondsRealtime(.01f);
            
                     yield return new WaitForSecondsRealtime(1);
                 
            for(float i = 0; i < 1; i+= 0.1f , Time.timeScale=i)
                yield return new WaitForSecondsRealtime(.01f);

            AudioSystem.instance.PonerSonido("sonidoSalvavidas");
            yield break;
        }
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
