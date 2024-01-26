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
    public float maxHumor, maxSeriedad,seriedadActual,humorActual;
    public EXPRESION expressionActual;
   // se mueve hacia una pos
    public void CambiaDeExpresion()
    {
        if(humorActual > 70) 
        expressionActual = EXPRESION.Riendo;
        else if(seriedadActual > 70) expressionActual = EXPRESION.Serio;

        print("expresion npc: "+ expressionActual);
    }
    public void MoverA(Transform posAMover)
    {
        agent.destination = posAMover.position;
        agent.Move(Vector3.one);
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoverA(Player.Instance.transform);
    }
}
public enum EXPRESION
{
    Aburrido,
    Normal,
    Serio,
    Riendo
}