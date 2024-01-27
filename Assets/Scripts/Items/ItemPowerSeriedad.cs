using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerSeriedad : ItemBase
{
    private float _cantidad = 10;

    public override void Interaccion()
    {
        _cantidad += Random.Range(0, 30);
        Debug.Log("Item Powerup Seriedad");
    }
}
