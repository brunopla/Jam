using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    private CharacterController _cc;
    private float _yInicial;
    public float _velocidad;
    [SerializeField] private float _velocidadRotacion;
    public  Animator _animator;

    void Start()
    {
        _yInicial = transform.position.y;

        instance = this;
        _cc = GetComponent<CharacterController>();
        if(_cc == null)
        {
            Debug.LogError("Character Controller NULL");
        }
    }

    void Update()
    {
        Movimiento();
    }
    void Movimiento()
    {
        Vector3 _inputVector = Vector3.zero;
       
        _inputVector.x = Input.GetAxis("Horizontal");
        _inputVector.z = Input.GetAxis("Vertical");


        if (_inputVector != Vector3.zero) _animator.SetBool("isRun", true);
        else _animator.SetBool("isRun", false);
                
        _cc.Move(_inputVector.normalized * _velocidad * Time.deltaTime);

        if(_inputVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_inputVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards
                (transform.rotation, toRotation, _velocidadRotacion * Time.deltaTime);
        }

        transform.position = new Vector3(transform.position.x, _yInicial, transform.position.z);
    }
}
