using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public abstract class ItemBase : MonoBehaviour
{
    public abstract void Interaccion();

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Interaccion();
            Destroy(gameObject);
        }
        
    }
    
}
