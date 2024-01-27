using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;
// los npc salen hasta el escenario
[RequireComponent(typeof(NavMeshAgent))]
public abstract class NPC : MonoBehaviour
{
    private NavMeshAgent agent;
    public EXPRESION expressionActual;
   // se mueve hacia una pos
    public void CambiaDeExpresion()
    {
        if(GameLoop.instance.humorActual > (GameLoop.instance.maxHumor/2 + GameLoop.instance.maxHumor/ 4 )) 
        expressionActual = EXPRESION.Riendo;
        else if(GameLoop.instance.seriedadActual > (GameLoop.instance.maxSeriedad / 2 + GameLoop.instance.maxSeriedad/4) 
            && GameLoop.instance.seriedadActual< GameLoop.instance.maxSeriedad ) expressionActual = EXPRESION.Serio;

        // instanciar emoticon con expresion
        print("expresion npc: "+ expressionActual);
    }
    public void MoverA(Transform posAMover)
    {
        agent.enabled = true;
        agent.destination = posAMover.position;
        agent.Move(Vector3.one);
    }
    private void Start()
    {
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