using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerRisa : ItemBase
{
    public float cantidad=10;
    public override void Interaccion()
    {
        cantidad += Random.Range(0, 30); 
        print("efecto powe risa");
    }


}
