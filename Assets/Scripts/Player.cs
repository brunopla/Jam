using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private CharacterController _cc;
    private Vector3 _inputVector;
    private float _yInicial;
    [SerializeField] private float _velocidad;
    [SerializeField] private float _velocidadRotacion;

    void Start()
    {
        _yInicial = transform.position.y;

        Instance = this;
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
        _inputVector.x = Input.GetAxis("Horizontal");
        _inputVector.z = Input.GetAxis("Vertical");

        _cc.Move(_inputVector * _velocidad * Time.deltaTime);

        if(_inputVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_inputVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _velocidadRotacion * Time.deltaTime);
        }

        transform.position = new Vector3(transform.position.x, _yInicial, transform.position.z);
    }
}
