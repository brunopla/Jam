using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public abstract class ItemBase : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _moviendose = true;
    public abstract void Interaccion();
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if(_rb == null)
        {
            Debug.LogError("Rigidbody NULL");
        }
        StartCoroutine(DejarDeMoverse());
    }

    void Update()
    {
        if(_moviendose)
        {
            _rb.AddForce((Player.instance.transform.position - this.transform.position) * 2);
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
            Interaccion();
            Destroy(gameObject);
        }
        
    }
    
}
