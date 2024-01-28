using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerRisa : ItemBase
{
    [SerializeField] private int _cantidad = 10;
    public override void Interaccion()
    {
        _cantidad += Random.Range(0, 30);
        GameLoop.instance.IncrementarHumor(_cantidad);
        print("efecto power risa");
        Player.instance.falda.SetActive(true);
        UISystem.instance.MandarMensajeFeedback("Item risa obtenido");
    }


}
