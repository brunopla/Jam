using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;
// los npc salen hasta el escenario
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public abstract class NPC : MonoBehaviour
{
    private NavMeshAgent agent;
    public Animator animator;
    public AudioSource audioSource;
    public EXPRESION expressionActual;
    public AudioClip clipRisa;
   /// <summary>
   /// Usar en GameLoop.cs para actualizar el estado de animo de los npc
   /// </summary>
    public virtual void CambiaDeExpresion()
    {
        if(GameLoop.instance.humorActual > (GameLoop.instance.maxHumor/2 + GameLoop.instance.maxHumor/ 4 )) 
        expressionActual = EXPRESION.Riendo;
        else if(GameLoop.instance.seriedadActual > (GameLoop.instance.maxSeriedad / 2 + GameLoop.instance.maxSeriedad/4) 
            && GameLoop.instance.seriedadActual< GameLoop.instance.maxSeriedad ) expressionActual = EXPRESION.Serio;

        // instanciar emoticon con expresion
       // print("expresion npc: "+ expressionActual);

        // cambiar animacion 
        switch (expressionActual)
        {
            case EXPRESION.Riendo: animator.Play("risa"); audioSource.PlayOneShot(clipRisa) ;break;
                case EXPRESION.Serio: animator.Play("enojo") ;break;
            case EXPRESION.Normal: animator.Play("idle"); break;
            case EXPRESION.Aburrido: animator.Play("tirar");
                GameLoop.instance.publico._lanzarItemScr.Lanzar();
                break; 
        }
        
    }
    public void MoverA(Transform posAMover)
    {
        agent.enabled = true;
        agent.destination = posAMover.position;
        agent.Move(Vector3.one);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.LookAt(Camera.main.transform.position);
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        //MoverA(Player.Instance.transform);
    }
}
public enum EXPRESION
{
    Aburrido,
    Normal,
    Serio,
    Riendo
}