using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerRisa : ItemBase
{
    [SerializeField] private float _cantidad = 10;
    public override void Interaccion()
    {
        _cantidad += Random.Range(0, 30);
        print("efecto power risa");
    }


}
