using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public abstract class ItemBase : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _moviendose = true;
    Vector3 posicionDestino;
    public abstract void Interaccion();
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if(_rb == null)
        {
            Debug.LogError("Rigidbody NULL");
        }
        posicionDestino = Player.instance.transform.position;
        StartCoroutine(DejarDeMoverse());
    }

    void Update()
    {
        if(_moviendose)
        {
            _rb.AddForce((posicionDestino - this.transform.position) * 2);
        }
    }

    IEnumerator DejarDeMoverse()
    {
        yield return new WaitForSeconds(0.2f);
        _moviendose = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

                //AudioSystem.instance.PonerSonido("choqueItemPlayer");
            if (_moviendose)
            {
                Player.instance._animator.SetTrigger("ataqueRecibido");
                Player.instance.transform.DOShakePosition(.35f, strength: .5f);
            }
            Interaccion();
            Destroy(gameObject);
        }
        
    }
    
}
