using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerSalvador : ItemBase
{
    public override void Interaccion()
    {
        GameLoop.instance.humorActual = GameLoop.instance.maxHumor / 2;
        GameLoop.instance.seriedadActual = GameLoop.instance.maxSeriedad / 2;
        Debug.Log("Item Power Salvador");
    }
}
