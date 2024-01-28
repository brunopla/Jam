using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerSeriedad : ItemBase
{
    private int _cantidad = 10;

    public override void Interaccion()
    {
        _cantidad += Random.Range(0, 30);
        GameLoop.instance.IncrementarSeriedad(_cantidad);
        Debug.Log("Item Powerup Seriedad");
        Player.instance.capa.SetActive(true);
        UISystem.instance.MandarMensajeFeedback("Item seriedad obtenido");
    }
}
