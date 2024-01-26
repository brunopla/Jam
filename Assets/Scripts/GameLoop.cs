using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public float tiempoCinematica;
    public const float maxHumor = 100, maxSeriedad = 100;
    public float humorActual = 50, seriedadActual = 50;
    public Image panelPerder;
    [SerializeField] Publico publico;
    public IEnumerator Start()
    {
        publico.GenerarPublico(10);
        yield return new WaitForSeconds(tiempoCinematica);
        //player.velocidad = 10;
        while (true)
        {
            yield return new WaitForSeconds(3);
            humorActual--;
            seriedadActual++;
            if (seriedadActual <= maxSeriedad || humorActual >= maxHumor) StartCoroutine(Perder());
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
}
