using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Hablar : MonoBehaviour
{
    [SerializeField] GameObject prefabText;
    public float velocidadEscritura = 0.1f;    
    public List<string> dialogos;
    public  string ultimoDialogo = null;
    public float coolDownDecir = 5,maxCooldown=5;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coolDownDecir >= 5 )
        {
            if(ultimoDialogo != "" )
            Decir(dialogos.Where(d => d != ultimoDialogo).First(),Player.instance.transform.position);
            else
                Decir(dialogos[Random.Range(0,dialogos.Count)],Player.instance.transform.position);
        }
        coolDownDecir += Time.deltaTime;
    }
    public void Decir(string _dialogo,  Vector3 _pos)
        => StartCoroutine(_Decir(_dialogo, _pos));

    public IEnumerator _Decir( string dialogo,Vector3 pos)
    {
        coolDownDecir = 0;
        var msj = Instantiate(prefabText,new Vector3(pos.x,pos.y+1,pos.z),Quaternion.Euler(0,0,0));
        //msj.transform.LookAt(Camera.main.transform);
        TMP_Text text= msj.transform.GetComponentInChildren<TMP_Text>();  
        msj.transform.DOPunchScale(Vector3.one / 4, 1);
            foreach( char letra in dialogo)
            {
                 text.text += letra;
                yield return new WaitForSeconds(velocidadEscritura);
            }
        GameLoop.instance.humorActual += 10;
        msj.transform.DOMoveY(msj.transform.position.y + 10, 7);
        Destroy(msj,10);  
    }
}
