using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake()
    {
        _instance = this;
    }

    public void MinijuegoBarra()
    {
        
    }
}
