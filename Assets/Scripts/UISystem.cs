using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
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
    
}
