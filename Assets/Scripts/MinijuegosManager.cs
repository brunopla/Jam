using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinijuegosManager : MonoBehaviour
{
    private static MinijuegosManager _instance;
    public static MinijuegosManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("MinijuegosManager NULL");
            }
            return _instance;
        }
    }
    [SerializeField] private RectTransform _winArea;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        if(_winArea == null)
        {
            Debug.LogError("Win Area Not Assigned");
        }

        MinijuegoBarra();
    }

    public void MinijuegoBarra()
    {
        //Se randomiza la posicion
        _winArea.localPosition = new Vector3(Random.Range(-100, 100), 0, 0);
        //Es necesario crear un puntero o linea que vaya avanzando por la barra
        //Si el usuario clickea, compara la posicion en x del puntero con la area de ganar para asegurarse de que este dentro del area
        //Asignar los puntos si el puntero esta dentro del winArea
    }
}
