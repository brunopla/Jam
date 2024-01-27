using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hablar : MonoBehaviour
{
    [SerializeField] GameObject prefabText;
    public float velocidadEscritura = 0.1f;    
    public List<string> dialogos;
    public void Decir(string _dialogo, TMP_Text _tMP_Text, Vector3 _pos)
        => StartCoroutine(_Decir(_dialogo, _tMP_Text, _pos));
        
    public IEnumerator _Decir( string dialogo,TMP_Text text,Vector3 pos)
    {
        var msj = Instantiate(prefabText,pos,Quaternion.identity);
        msj.transform.DOPunchScale(Vector3.one / 4, 1);
            foreach( char letra in dialogo)
            {
                 text.text += letra;
                yield return new WaitForSeconds(velocidadEscritura);
            }
        msj.transform.DOMoveY(msj.transform.position.y + 500, 10);
        Destroy(msj,10);  
    }
}
