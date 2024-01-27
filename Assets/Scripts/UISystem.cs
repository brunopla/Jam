using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
   public static UISystem instance;
    [SerializeField] Image barraHumorFill,barraSeriedadFill;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void UpdateUI()
    {
        barraHumorFill.fillAmount = GameLoop.instance.humorActual / GameLoop.instance.maxHumor; 
        barraHumorFill.fillAmount = GameLoop.instance.seriedadActual/ GameLoop.instance.seriedadActual; 
    }
    public void PunchBarra(Image image, float force) => image.transform.DOPunchScale(new Vector3(force, force, force), .25f)
        .OnComplete(() => { image.transform.DOScale(Vector3.one, 0); });

    Queue<string> colaDeMensajes;
    [SerializeField] TMP_Text textFeedback;
    public void _MandarMensajeFeedback(string _msj) => StartCoroutine(MandarMensajeFeedback(_msj));
     public IEnumerator MandarMensajeFeedback(string msj)
    {
        colaDeMensajes.Enqueue(msj);
        if (colaDeMensajes.Count > 1) yield break;
        while(colaDeMensajes.Count > 0 )
        {
            textFeedback.text = msj;
            yield return new WaitForSecondsRealtime(msj.Length * .35f);
            print($"duracion del mensaje:  {msj.Length * .35f}");
        }
    }
}
