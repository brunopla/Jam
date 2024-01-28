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

    }
    [SerializeField] Slider sliderMinijeugoBarra;
    [SerializeField] bool haCliqueado;
    public void MinijuegoBarra(float _tiempo) => StartCoroutine(_MinijuegoBarra(_tiempo));
        IEnumerator _MinijuegoBarra(float tiempo)
        {
            for(float i = 0 ;i < 1; i += 0.01f)
            {
                yield return new WaitForSecondsRealtime(0.01f);
                   if(haCliqueado)
                   {
                       
                   }
                   else
                   {
                        
                   }
            }
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
