using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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
            Debug.Log("Win Area Not Assigned");
        }

        MinijuegoBarra();
    }

    public void MinijuegoBarra()
    {
        //Se randomiza la posicion
        //_winArea.localPosition = new Vector3(Random.Range(-100, 100), 0, 0);
        //Es necesario crear un puntero o linea que vaya avanzando por la barra
        //Si el usuario clickea, compara la posicion en x del puntero con la area de ganar para asegurarse de que este dentro del area
        //Asignar los puntos si el puntero esta dentro del winArea
    }

    [SerializeField] GameObject prefabButtonSeleccionChiste;
    public List<Chiste> listaDeChistes;
    Chiste ultimoChiste;
    [SerializeField] Transform panelSeleccionChisteACompletar;
    public bool haSeleccionado;
  
    public void MinijuegoCompletarLaMitad()
    {
        Chiste  c = listaDeChistes.Where(c => c != ultimoChiste).FirstOrDefault();
        //limpiar panel de botones anteriores
        var btnsChistesEnEscena = GameObject.FindGameObjectsWithTag("btnChiste").ToList();
        btnsChistesEnEscena.ForEach(btn => Destroy(btn));
        // mostrar menu
        panelSeleccionChisteACompletar.DOScale(Vector3.one, .25f);

        //crear botones de seleccion
        for(int i =0; i< c.respuestasPosibles.Count;i++)
        {
            var btn = Instantiate(prefabButtonSeleccionChiste, panelSeleccionChisteACompletar.transform);
            btn.GetComponentInChildren<TMP_Text>().text = c.respuestasPosibles[i];

        }
        
            // asignar un tiempo de respuesta, pasado ese tiempo la barra se cierra y se aumenta la seriedad
    }
    

    [System.Serializable]
    public class Chiste
    {
        public string mitadPrincipal;
        public string mitadSecundariaCorrecta;
        public List<string> respuestasPosibles;
    }
}
