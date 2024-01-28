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
        colaDeMensajes = new Queue<string>();
    }
    public void UpdateUI()
    {
        barraHumorFill.fillAmount = GameLoop.instance.humorActual / GameLoop.instance.maxHumor / 100; 
        barraHumorFill.fillAmount = GameLoop.instance.seriedadActual/ GameLoop.instance.seriedadActual /100; 
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
            print("msj ui");
            string _msj =  colaDeMensajes.Dequeue();
            textFeedback.text = _msj;
            textFeedback.DOColor(new Color(0, 0, 0, 1), .6f);
            yield return new WaitForSecondsRealtime(_msj.Length * .35f);
            print($"duracion del mensaje:  {_msj.Length * .35f}");
            textFeedback.DOColor(new Color(0, 0, 0, 0), .6f);
            yield return new WaitForSeconds(.6f);
            textFeedback.text = "";
        }
    }
}
